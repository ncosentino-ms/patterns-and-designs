using Moq;
using Xunit;

namespace AnimalKingdom.Composition.Tests
{
    public class ExtraColorProviderTests
    {
        private readonly ExtraColorProvider extraColorProvider;
        private readonly MockRepository mockRepository;
        private readonly Mock<IColorProvider> defaultColorProvider;

        public ExtraColorProviderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.defaultColorProvider = this.mockRepository.Create<IColorProvider>();
            this.extraColorProvider = new ExtraColorProvider(
                defaultColorProvider.Object,
                new[]
                {
                    "123",
                    "abc",
                    "xyz"
                });
        }

        [Fact]
        private void GetPossibleColors_IncludesDefaultBeforeDogSpecificColors()
        {
            this.defaultColorProvider
                .Setup(x => x.GetPossibleColors())
                .Returns(new string[]
                {
                    "simulated default color"
                });

            var colors = this.extraColorProvider.GetPossibleColors();

            Assert.Equal(
                new string[]
                {
                    "simulated default color",
                    "123",
                    "abc",
                    "xyz"
                },
                colors);
            this.mockRepository.VerifyAll();
        }
    }
}
