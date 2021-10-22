using System;

namespace AnimalKingdom.Composition
{
    public sealed class WalkingSystem : IWalkingSystem
    {
        private readonly ILocationProvider locationProvider;
        private readonly int speed;

        public WalkingSystem(
            ILocationProvider locationProvider,
            int speed)
        {
            this.locationProvider = locationProvider;
            this.speed = speed;
        }

        public Tuple<int, int> Walk(int direction)
        {
            // TODO: obviously handle directions...
            this.locationProvider.Location = new Tuple<int, int>(
                this.locationProvider.Location.Item1,
                this.locationProvider.Location.Item2 + this.speed);
            return locationProvider.Location;
        }
    }
}
