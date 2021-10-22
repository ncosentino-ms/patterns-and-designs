using System.Collections.Generic;

namespace AnimalKingdom.Composition
{
    public interface IColorProvider
    {
        IEnumerable<string> GetPossibleColors();
    }
}