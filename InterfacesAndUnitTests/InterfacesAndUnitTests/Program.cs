using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndUnitTests
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var pageSaver = new PageSaver1();
    //        pageSaver.SavePage("google.ca", "google.html");
    //    }
    //}

    public sealed class PageSaver1
    {
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

            // TODO: maybe we want some input checking here...
            // - valid URL?
            // - valid output path?
            // - does our output path exist?
            // this is something we could write unit tests for

            // EXAMPLE: new-ing up concrete dependencies inside your class/method
            var client = new WebClient();
            var contents = client.DownloadString(url);

            // EXAMPLE: calling static methods
            File.WriteAllText(filePath, contents);
        }
    }
}
