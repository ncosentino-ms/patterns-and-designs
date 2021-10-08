using System;
using System.IO;
using System.Net;

namespace ExtractionRefactoring
{
    public static class ComplicatedStaticClass
    {
        public static void StartWork()
        {
            // **
            // Can we identify the things in this file that make unit testing more difficult?
            // **
            var webClient = new WebClientWrapper();
            var metaContentFetcher = new MetaContentFetcher(webClient);
            string metaContent = metaContentFetcher.GetMetaContent();

            string randomContent = GenerateRandomContent();

            // should look like:
            // <some random stuff>
            // <some stuff from the web>
            var initialContent = randomContent + "\r\n" + metaContent;

            ManipulateFile(initialContent);
        }

        private static string GenerateRandomContent()
        {
            var randomContent = Guid.NewGuid().ToString(); // XXX
            randomContent = randomContent.Replace("1", "");
            randomContent = randomContent.Replace("2", "");
            randomContent = randomContent.Replace("3", "");
            randomContent = DateTime.Now + " " + randomContent;
            return randomContent;
        }

        private static void ManipulateFile(string content)
        {
            File.WriteAllText("file1.txt", content);
            var file1Contents = File.ReadAllText("file1.xtx"); // XXX

            // triple up all the lowercase vowels
            var newFileContents = file1Contents.Replace("a", "aaa");
            newFileContents = newFileContents.Replace("e", "eee");
            newFileContents = newFileContents.Replace("i", "iii");
            newFileContents = newFileContents.Replace("o", "ooo");
            newFileContents = newFileContents.Replace("u", "uuu");
            File.WriteAllText("file1.txt", newFileContents);
        }
    }

    public interface IMetaContentFetcher
    {
        string GetMetaContent();
    }

    public sealed class MetaContentFetcher : IMetaContentFetcher
    {
        private IWebClient _webclient;

        public MetaContentFetcher(IWebClient webclient)
        {
            _webclient = webclient;
        }

        public string GetMetaContent()
        {
            var webContent = _webclient.DownloadString("https://www.google.ca");
            const string META_START_PHRASE = "<meta content=\"";
            var metaContentStartIndex = webContent.IndexOf(META_START_PHRASE, StringComparison.OrdinalIgnoreCase);
            var metaContentEndIndex = webContent.IndexOf("\"", metaContentStartIndex + META_START_PHRASE.Length + 1);
            var metaContent = webContent
                .Substring(
                    metaContentStartIndex + META_START_PHRASE.Length,
                    metaContentEndIndex - metaContentStartIndex - META_START_PHRASE.Length);
            return metaContent;
        }
    }
}
