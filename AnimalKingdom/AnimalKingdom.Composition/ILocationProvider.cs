using System;

namespace AnimalKingdom.Composition
{
    public interface ILocationProvider
    {
        Tuple<int, int> Location { get; set; }
    }
}