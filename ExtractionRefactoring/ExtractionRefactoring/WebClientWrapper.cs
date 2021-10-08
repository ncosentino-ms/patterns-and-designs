using System.Net;

namespace ExtractionRefactoring
{
    public sealed class WebClientWrapper : IWebClient
    {
        public string DownloadString(string url) => new WebClient().DownloadString(url);
    }
}
