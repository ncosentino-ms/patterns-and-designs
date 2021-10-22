using System;
using System.Collections.Generic;

namespace AnimalKingdom.Composition
{
    public sealed class Animal
    {
        private readonly IWalkingSystem walkingSystem;
        private readonly IColorProvider colorProvider;

        public Animal(
            IWalkingSystem walkingSystem,
            IColorProvider colorProvider)
        {
            this.walkingSystem = walkingSystem;
            this.colorProvider = colorProvider;
        }

        public Tuple<int, int> Walk(int direction) => 
            this.walkingSystem.Walk(direction);

        public Tuple<int, int> Swim(int direction)
        {
            throw new NotImplementedException("... we'd do the same thing here with a swimming system!");
        }

        public IEnumerable<string> GetPossibleColors() => 
            this.colorProvider.GetPossibleColors();
    }
}
