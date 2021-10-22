using System;

namespace AnimalKingdom.Composition
{
    public sealed class CannotWalkSystem : IWalkingSystem
    {
        public Tuple<int, int> Walk(int direction) =>
            throw new NotSupportedException("This animal cannot walk!");
    }
}
