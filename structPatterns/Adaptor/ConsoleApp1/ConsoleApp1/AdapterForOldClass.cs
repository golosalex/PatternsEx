using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class AdapterForOldClass : IHelloClass
    {
        OldClass a = new OldClass();
        public void HelloWord()
        {
            a.GoodOldMethod();
        }
    }
}
