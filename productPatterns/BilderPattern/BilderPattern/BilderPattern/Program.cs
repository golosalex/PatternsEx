using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IBilder bilder = new SipleBilder();
            bilder.setBody().setFutter().setHeader();
            Console.WriteLine(bilder.GetHtmlPage());
        }
    }
}
