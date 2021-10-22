using System;

namespace AnimalKingdom.Composition
{
    public sealed class LocationProvider : ILocationProvider
    {
        public Tuple<int, int> Location { get; set; }
    }
}
