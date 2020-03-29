using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilderPattern
{
    class SipleBilder : IBilder
    {
        private  HTMLPage _html= new HTMLPage();

        public HTMLPage GetHtmlPage()
        {
            return _html;
        }

        public IBilder setBody()
        {
            _html.Body = "<p>это боди ура ура</p>";
            return this;
        }

        public IBilder setFutter()
        {
            _html.Footer = "<p>это футтер</p>";
            return this;
        }

        public IBilder setHeader()
        {
            _html.Head = "<p>это header</p>";
            return this;
        }
    }
}
