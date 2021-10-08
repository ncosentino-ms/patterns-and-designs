using System.IO;

namespace ExtractionRefactoring
{
    public sealed class FileIO : IFileIO
    {
        public string ReadAllText(string path) => File.ReadAllText(path);

        public void WriteAllText(string path, string contents) => File.WriteAllText(path, contents);
    }
}
