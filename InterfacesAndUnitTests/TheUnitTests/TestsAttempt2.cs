using InterfacesAndUnitTests;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TheUnitTests
{
    public class TestsAttempt2
    {
        private readonly MockRepository _mockRepository;
        private readonly PageSaver2 _pageSaver;
        private readonly Mock<IWebClient> _webClient;
        private readonly Mock<IFileWriter> _fileWriter;

        public TestsAttempt2()
        {
            // for unit tests, we REALLY should use strict. otherwise, we are 
            // saying "we don't care who calls methods/properties on this"...
            // so then why do you have a "unit" test? :)
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _webClient = _mockRepository.Create<IWebClient>();
            _fileWriter = _mockRepository.Create<IFileWriter>();
            _pageSaver = new PageSaver2(
                _webClient.Object,
                _fileWriter.Object);
        }

        [Fact]
        public void SavePage_NullUrl_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _pageSaver.SavePage(null, "validfile.html"));
        }

        [Fact]
        public void SavePage_NullPath_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => _pageSaver.SavePage("google.ca", null));
        }

        [Fact]
        public void SavePage_ValidInput_SuccessfullySaves()
        {
            // few points on setting up mocks:
            // - mocks allow us to take full control of our dependencies 
            // - because we have full control, we're not actually exercising 
            //   real behavior in classes that the mocks are supposed to 
            //   represent (i.e. MyWebClient and FileWriter)
            // - excessive reliance on ONLY unit tests with mocked dependencies 
            //   can potentially leave you vulnerable to expected behavior 
            //   changing inside of real implementations and then tests 
            //   missing this coverage (i.e. pretend MyWebClient throws 
            //   exceptions on any Canadian domains because we don't like Nick... 
            //   these tests will still pass, which is good because you're not 
            //   exercising MyWebClient, but hopefully you have OTHER tests 
            //   that will cover that new behavior)
            _webClient
                .Setup(x => x.DownloadString("http://google.ca"))
                .Returns("the fake content");
            _fileWriter
                .Setup(x => x.WriteAllText("validfile.html", "the fake content"));

            _pageSaver.SavePage("http://google.ca", "validfile.html");

            // ... still no assertions?!
            // you're right. some people will say things along the lines of "
            // if there are no assertions, it's not actually a test", which in
            // general i agree with. no assertions is really just "exercising"
            // code and proving it doesn't throw.
            // !!BUT!! remember our strict mock behavior? using strict mocks
            // and then calling verify closes the loop on all of this and says
            // everything we setup was actually called as expected. without 
            // saying it in the method name directly, this asserts our 
            // dependencies were acted on as expected.
            _mockRepository.VerifyAll();
        }
    }
}
