using System.Collections.Generic;
using System.Linq;

namespace AnimalKingdom.Composition
{
    public sealed class ExtraColorProvider : IColorProvider
    {
        private readonly IColorProvider defaultColorProvider;
        private readonly IReadOnlyList<string> extraColors;

        public ExtraColorProvider(
            IColorProvider defaultColorProvider,
            IReadOnlyList<string> extraColors)
        {
            this.defaultColorProvider = defaultColorProvider;
            this.extraColors = extraColors;
        }

        public IEnumerable<string> GetPossibleColors()
        {
            return this.defaultColorProvider.GetPossibleColors().Concat(extraColors);
        }
    }
}
