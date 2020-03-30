using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction a = new Abstraction() {Imp1 = new Implementation()};
            a.Op1();
            a.Op2();
            a.Op3();

            a.Imp1 = new Implementation2();
            a.Op1();
            a.Op2();
            a.Op3();
        }
    }
}
