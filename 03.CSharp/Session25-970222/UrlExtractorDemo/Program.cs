using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UrlExtractorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            webClient.BaseAddress = "https://stackoverflow.com/";
            var webContent = webClient.DownloadString(string.Empty);
            //Console.WriteLine(webContent);
            Regex re = new Regex("href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))");
            var matches = re.Matches(webContent);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1]);
            }

            Console.ReadKey();
            
        }
    }
}
