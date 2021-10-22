using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AnimalKingdom.Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public abstract class Animal
    {
        public abstract Tuple<int, int> Walk(int direction);

        public abstract Tuple<int, int> Swim(int direction);

        public abstract void Eat(Animal animalToEat);

        public virtual IEnumerable<string> GetPossibleColors()
        {
            using (File.OpenRead("default_universal_colors.txt"))
            {
                // **********************************************************************************
                // it would be great to have some tests on here to prove we can parse the file format
                // ....... something to think about :)
                // **********************************************************************************

                // pretend we're reading in the colors from the file
                yield return "solid black";
                yield return "solid white";
                yield return "solid brown";
            }
        }
    }

    public class Dog : Animal
    {
        private Tuple<int, int> position;

        public Dog()
        {
            this.position = new Tuple<int, int>(0, 0);
        }

        public override Tuple<int, int> Swim(int direction)
        {
            throw new NotSupportedException();
        }

        public override Tuple<int, int> Walk(int direction)
        {
            this.position = new Tuple<int, int>(this.position.Item1, this.position.Item2 + 2);
            return this.position;
        }

        public override void Eat(Animal animalToEat)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> GetPossibleColors()
        {
            return base.GetPossibleColors().Concat(new[]
            {
                "white with black spots",
                "black with white spots",
                "white with brown spots",
            });
        }
    }

    public class Fish : Animal
    {
        public override Tuple<int, int> Swim(int direction)
        {
            throw new NotImplementedException();
        }

        public override Tuple<int, int> Walk(int direction)
        {
            throw new NotSupportedException();
        }

        public override void Eat(Animal animalToEat)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> GetPossibleColors()
        {
            // no base colors... we do our own thing here!
            return new string[]
            {
                "rainbow scales",
                "grey scales",
                "blue scales",
            };
        }
    }

    public class Bird : Animal
    {
        private Tuple<int, int> position;

        public Bird()
        {
            this.position = new Tuple<int, int>(0, 0);
        }

        public override Tuple<int, int> Swim(int direction)
        {
            throw new NotSupportedException();
        }

        public override Tuple<int, int> Walk(int direction)
        {
            this.position = new Tuple<int, int>(this.position.Item1, this.position.Item2 + 100);
            return this.position;
        }

        public override void Eat(Animal animalToEat)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> GetPossibleColors()
        {
            // we want to get some bird patterns from the internet...
            var rawString = new WebClient().DownloadString("some site that has bird patterns for us :)");

            // pretend we parse this string here and have lots of results...
            yield return "... all of the cool bird patterns!!!";
        }
    }

    public class Snake : Animal
    {
        public override Tuple<int, int> Swim(int direction)
        {
            throw new NotImplementedException();
        }

        public override Tuple<int, int> Walk(int direction)
        {
            throw new NotImplementedException();
        }

        public override void Eat(Animal animalToEat)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> GetPossibleColors()
        {
            // ***********************************************************
            // NOTE: THIS IS THE EXACT SAME AS THE BIRD ONE BUT FOR SNAKES
            // ***********************************************************

            // we want to get some snake patterns from the internet...
            var rawString = new WebClient().DownloadString("some site that has snake patterns for us :)");

            // pretend we parse this string here and have lots of results...
            yield return "... all of the cool snake patterns!!!";
        }
    }
}
