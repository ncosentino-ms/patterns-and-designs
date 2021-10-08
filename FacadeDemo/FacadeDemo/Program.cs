using System;
using System.Collections.Generic;
using System.Linq;

namespace FacadeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup
            var getDataFacade = new GetDataFacade(new Dictionary<Type, IGetsData>()
            {
                [typeof(EntityAbc)] = new AbcDataGetter(),
            });

            var doWorkFacade = new DoWorkFacade();
            doWorkFacade.Register(x => x is IEntityAbc, new DoesWorkAbc());
            doWorkFacade.Register(x => x is IEntityAbc, new DoesWorkAbcUpper());

            var system = new TheSystem(
                getDataFacade,
                doWorkFacade);

            // Execute
            var entity = new EntityAbc();
            system.Run(entity);

            Console.ReadLine();
        }
    }

    #region The Core - We shouldn't need to touch this stuff :)
    public sealed class TheSystem
    {
        private readonly IGetsData _getDataFacade;
        private readonly IDoesWorkFacade _doesWorkFacade;

        public TheSystem(IGetsData getDataFacade, IDoesWorkFacade doesWorkFacade)
        {
            _getDataFacade = getDataFacade;
            _doesWorkFacade = doesWorkFacade;
        }

        public void Run(IEntity entity)
        {
            var dataResult = _getDataFacade.GetData(entity);
            Console.WriteLine("GET DATA:");
            Console.WriteLine(dataResult);

            Console.WriteLine("DO WORK:");
            _doesWorkFacade.DoWork(entity);
        }
    }

    public sealed class GetDataFacade : IGetsData
    {
        private readonly IDictionary<Type, IGetsData> mapping;

        public GetDataFacade(IDictionary<Type, IGetsData> mapping)
        {
            this.mapping = mapping;
        }

        public string GetData(IEntity entity)
        {
            // this facade will throw if we cant find a handler for this entity.
            // we could have default handling or something else, but this 
            // example throws instead
            if (!this.mapping.TryGetValue(
                entity.GetType(),
                out var dataGetter))
            {
                throw new NotSupportedException($"Entity type '{entity.GetType()}' is not supported!");
            }

            var result = dataGetter.GetData(entity);
            return result;
        }
    }

    public sealed class DoWorkFacade : IDoesWorkFacade
    {
        private readonly List<Tuple<Func<IEntity, bool>, Action<IEntity>>> mapping;

        public DoWorkFacade()
        {
            this.mapping = new List<Tuple<Func<IEntity, bool>, Action<IEntity>>>();
        }
        
        public void Register<TEntity>(
            Func<IEntity, bool> matcher,
            IDoesWork<TEntity> doesWork)
            where TEntity : IEntity
        {
            // this registration allows us to use a delegate to match if we 
            // can handle or not. another benefit of this approach is the 
            // casting IN the facade and not in each implementation
            mapping.Add(Tuple.Create<Func<IEntity, bool>, Action<IEntity>>(
                matcher,
                o => doesWork.DoWork((TEntity)o)));
        }

        public void DoWork(IEntity input)
        {
            // unlike the other facade, we can allow multiple-matching here 
            // and we'll not complain if we can't find a single match
            var matches = mapping
                .Where(x => x.Item1(input))
                .Select(x => x.Item2);
            foreach (var match in matches)
            {
                // we can consider if we want exception handling or something 
                // here... PER match or maybe one fail fails the rest?
                match.Invoke(input);
            }
        }
    }
    #endregion

    #region Our APIs to Work With
    public interface IEntity
    {
    }

    public interface IGetsData
    {
        string GetData(IEntity entity);
    }

    public interface IDoesWork
    {
    }

    public interface IDoesWork<TEntity> : IDoesWork
        where TEntity : IEntity
    {
        void DoWork(TEntity input);
    }

    public interface IDoesWorkFacade : IDoesWork
    {
        void DoWork(IEntity input);
    }
    #endregion

    #region ABC Specific Things
    public sealed class EntityAbc : IEntityAbc
    {
        public string PropertyOnlyVisibleOnAbc { get; } =
            "This property is only visible when you know you have an instance " +
            "of a IEntityAbc. Otherwise, it's 'hidden' by IEntity because it's " +
            "not defined on that interface. We could have just as well";
    }

    public interface IEntityAbc : IEntity
    {
        string PropertyOnlyVisibleOnAbc { get; }
    }

    public sealed class AbcDataGetter : IGetsData
    {
        public string GetData(IEntity entity)
        {
            // this casting is pretty gross. this isn't the ideal way we do 
            // this, but if we know our configuration to set things up and 
            // register to the facade can ONLY give us this type, this cast 
            // is 100% safe. the downside is EVERY entity implementation 
            // needs to do this cast
            var casted = (IEntityAbc)entity;
            return casted.PropertyOnlyVisibleOnAbc;
        }
    }

    public sealed class DoesWorkAbc : IDoesWork<IEntityAbc>
    {
        public void DoWork(IEntityAbc input)
        {
            Console.WriteLine(input.PropertyOnlyVisibleOnAbc.ToLower());
        }
    }

    public sealed class DoesWorkAbcUpper : IDoesWork<IEntityAbc>
    {
        public void DoWork(IEntityAbc input)
        {
            Console.WriteLine(input.PropertyOnlyVisibleOnAbc.ToUpper());
        }
    }
    #endregion
}
