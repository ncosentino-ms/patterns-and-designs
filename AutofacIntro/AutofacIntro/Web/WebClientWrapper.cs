using System.Net;

namespace AutofacIntro.Web
{
    public sealed class WebClientWrapper : IWebClient
    {
        private readonly WebClient webClient;

        public WebClientWrapper(WebClient webClient)
        {
            this.webClient = webClient;
        }

        public string DownloadString(string url) =>
            this.webClient.DownloadString(url);
    }
}
