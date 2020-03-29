using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilderPattern
{
    interface IBilder
    {
        IBilder setHeader();
        IBilder setBody();
        IBilder setFutter();

        HTMLPage GetHtmlPage();
    }
}
