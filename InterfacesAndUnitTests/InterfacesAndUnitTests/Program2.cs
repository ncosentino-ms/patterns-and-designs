using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndUnitTests
{
    class Program2
    {
        static void Main(string[] args)
        {
            var webClient = new MyWebClient(new WebClient());
            var fileWriter = new FileWriter();
            var pageSaver = new PageSaver2(
                webClient,
                fileWriter);
            pageSaver.SavePage("google.ca", "google.html");
        }
    }

    public sealed class PageSaver2
    {
        private IWebClient _webClient;
        private IFileWriter _fileWriter;

        public PageSaver2(
            IWebClient webClient,
            IFileWriter fileWriter)
        {
            _webClient = webClient;
            _fileWriter = fileWriter;
        }

        public void SavePage(string url, string filePath)
        {
            if (url == null)
            {
                throw new InvalidOperationException();
            }

            if (filePath == null)
            {
                throw new InvalidOperationException();
            }

            if (!url.StartsWith("http://"))
            {
                url = "http://" + url;
            }

            // TODO: maybe we want some input checking here...
            // - valid URL?
            // - valid output path?
            // - does our output path exist?
            // this is something we could write unit tests for

            // EXAMPLE: new-ing up concrete dependencies inside your class/method
            //var client = new WebClient();
            //var contents = client.DownloadString(url);
            var contents = _webClient.DownloadString(url);

            // EXAMPLE: calling static methods
            //File.WriteAllText(filePath, contents);
            _fileWriter.WriteAllText(filePath, contents);
        }
    }

    public interface IWebClient
    {
        string DownloadString(string url);
    }

    public sealed class MyWebClient : IWebClient
    {
        private readonly WebClient _wrappedWebClient;

        public MyWebClient(WebClient webClientToWrap)
        {
            _wrappedWebClient = webClientToWrap;
        }

        public string DownloadString(string url) =>
            _wrappedWebClient.DownloadString(url);
    }

    public interface IFileWriter
    {
        void WriteAllText(string filePath, string contents);

        void AppendAllLines(string filePath, IEnumerable<string> contents);
    }

    public sealed class FileWriter : IFileWriter
    {
        public void WriteAllText(string filePath, string contents) =>
            File.WriteAllText(filePath, contents);

        public void AppendAllLines(string filePath, IEnumerable<string> contents) =>
            File.AppendAllLines(filePath, contents);
    }
}
