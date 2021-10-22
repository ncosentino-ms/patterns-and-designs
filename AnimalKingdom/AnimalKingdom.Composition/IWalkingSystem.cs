using System;

namespace AnimalKingdom.Composition
{
    public interface IWalkingSystem
    {
        Tuple<int, int> Walk(int direction);
    }
}