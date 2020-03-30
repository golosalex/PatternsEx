using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bridge
{
    class Abstraction
    {
        public IImplemator Imp1 { get; set; }

        public void Op1()
        {
            Imp1.Operation1();
        }

        public void Op2()
        {
            Imp1.Operation2();
        }

        public void Op3()
        {
            Imp1.Operation3();
        }
    }
}
