using System.Collections.Generic;
using System.IO;

namespace AnimalKingdom.Composition
{
    public sealed class DefaultColorProvider : IColorProvider
    {
        public IEnumerable<string> GetPossibleColors()
        {
            using (File.OpenRead("default_universal_colors.txt"))
            {
                // **********************************************************************************
                // it would be great to have some tests on here to prove we can parse the file format
                // ... Is it easier to test this now that we have a dedicated class for it?
                // ... (let's assume we can do better than the static File.OpenRead() call)
                // **********************************************************************************

                // pretend we're reading in the colors from the file
                yield return "solid black";
                yield return "solid white";
                yield return "solid brown";
            }
        }
    }
}
