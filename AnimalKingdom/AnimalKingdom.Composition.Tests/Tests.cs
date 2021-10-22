using Moq;
using System;
using Xunit;

namespace AnimalKingdom.Composition.Tests
{
    public class Tests
    {
        private readonly Animal animal;
        private readonly MockRepository mockRepository;
        private readonly Mock<IColorProvider> colorProvider;
        private readonly Mock<IWalkingSystem> walkingSystem;

        public Tests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.colorProvider = this.mockRepository.Create<IColorProvider>();
            this.walkingSystem = this.mockRepository.Create<IWalkingSystem>();
            this.animal = new Animal(
                this.walkingSystem.Object,
                this.colorProvider.Object);
        }

        // ******************************
        // LOOK HOW BORING THIS TEST IS!!
        // ...this is a good thing :)
        // ******************************
        [Fact]
        private void Walk_North_CallsWalkingSystemAsExpected()
        {
            this.walkingSystem
                .Setup(x => x.Walk(1))
                .Returns(new Tuple<int, int>(123, 456));

            var newPosition = this.animal.Walk(1);
            
            Assert.Equal(new Tuple<int, int>(123, 456), newPosition);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        private void GetPossibleColors_CallsColorProviderAsExpected()
        {
            this.colorProvider
                .Setup(x => x.GetPossibleColors())
                .Returns(new[]
                {
                    "test1",
                    "test2",
                });

            var colors = this.animal.GetPossibleColors();

            Assert.Equal(
                new[]
                {
                    "test1",
                    "test2",
                },
                colors);
            this.mockRepository.VerifyAll();
        }
    }
}
