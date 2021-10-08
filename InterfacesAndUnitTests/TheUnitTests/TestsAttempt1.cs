using InterfacesAndUnitTests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TheUnitTests
{
    public class TestsAttempt1
    {

        [Fact]
        public void SavePage_NullUrl_ThrowsException()
        {
            var pageSaver = new PageSaver1();
            Assert.Throws<InvalidOperationException>(() => pageSaver.SavePage(null, "validfile.html"));
        }

        [Fact]
        public void SavePage_NullPath_ThrowsException()
        {
            var pageSaver = new PageSaver1();
            Assert.Throws<InvalidOperationException>(() => pageSaver.SavePage("google.ca", null));
        }

        [Fact]
        public void SavePage_ValidInput_SuccessfullySaves()
        {
            var pageSaver = new PageSaver1();
            // FIXME:
            // - This requires an internet connection to run (i.e. need the environment configured a certainw way)
            // - This writes a file to disk (i.e. has a side effect of modifying the environment)
            pageSaver.SavePage("http://google.ca", "validfile.html");
            // FIXME: how do we assert anything here?!
            Assert.True(File.Exists("validfile.html"));
        }
    }
}
