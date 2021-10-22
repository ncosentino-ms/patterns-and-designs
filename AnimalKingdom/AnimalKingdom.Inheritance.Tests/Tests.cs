using System;
using System.Collections.Generic;
using Xunit;

namespace AnimalKingdom.Inheritance.Tests
{
    public class Tests
    {
        [Fact]
        private void Walk_DogWalkNorth_Moves2Units()
        {
            var animal = new Dog();
            var newPosition = animal.Walk(1);
            Assert.Equal(new Tuple<int, int>(0, 2), newPosition);
        }

        [Fact]
        private void Walk_BirdWalkNorth_Moves2Units()
        {
            var animal = new Bird();
            var newPosition = animal.Walk(1);
            Assert.Equal(new Tuple<int, int>(0, 1), newPosition);
        }
    }

    public class TestAnimal : Animal
    {
        public override void Eat(Animal animalToEat)
        {
            throw new NotImplementedException();
        }

        public override Tuple<int, int> Swim(int direction)
        {
            throw new NotImplementedException();
        }

        public override Tuple<int, int> Walk(int direction)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> GetPossibleColors() =>
            base.GetPossibleColors();
    }
}
