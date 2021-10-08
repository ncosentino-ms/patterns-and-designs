namespace ExtractionRefactoring
{
    public interface IFileIO
    {
        string ReadAllText(string path);

        void WriteAllText(string path, string contents);
    }
}
