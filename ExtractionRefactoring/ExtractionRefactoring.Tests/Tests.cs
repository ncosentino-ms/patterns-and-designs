using Moq;
using System;
using Xunit;

namespace ExtractionRefactoring.Tests
{
    public sealed class Tests
    {
        [Fact]
        public void GetMetaContent_LowerCaseWebContent_UpperCaseResult()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var webClient = mockRepository.Create<IWebClient>();

            webClient
                .Setup(x => x.DownloadString("https://www.google.ca"))
                .Returns("<meta content=\"lowercase text\"");

            var metaContentFetcher = new MetaContentFetcher(webClient.Object);

            var result = metaContentFetcher.GetMetaContent();
            Assert.Equal("lowercase text", result);
        }

        [Fact]
        public void GetMetaContent_UpperCaseWebContent_UpperCaseResult()
        {
            var mockRepository = new MockRepository(MockBehavior.Strict);
            var webClient = mockRepository.Create<IWebClient>();

            webClient
                .Setup(x => x.DownloadString("https://www.google.ca"))
                .Returns("<META CONTENT=\"lowercase text\"");

            var metaContentFetcher = new MetaContentFetcher(webClient.Object);

            var result = metaContentFetcher.GetMetaContent();
            Assert.Equal("lowercase text", result);
        }
    }
}
