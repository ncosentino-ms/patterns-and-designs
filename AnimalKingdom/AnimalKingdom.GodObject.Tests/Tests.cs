using System;
using Xunit;

namespace AnimalKingdom.GodObject.Tests
{
    public class Tests
    {
        [Fact]
        private void Walk_DogWalkNorth_Moves2Units()
        {
            var animal = new Animal("dog");
            var newPosition = animal.Walk(1);
            Assert.Equal(new Tuple<int, int>(0, 2), newPosition);
        }

        [Fact]
        private void Walk_BirdWalkNorth_Moves2Units()
        {
            var animal = new Animal("bird");
            var newPosition = animal.Walk(1);
            Assert.Equal(new Tuple<int, int>(0, 1), newPosition);
        }
    }
}
