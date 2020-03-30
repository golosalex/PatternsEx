using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bridge
{
    class Implementation2:IImplemator
    {
        public int Model { get; set; }
        public void Operation1()
        {
            Console.WriteLine($"this is other implamentation{Model} method1");
        }

        public void Operation2()
        {
            Console.WriteLine($"this is other implamentation{Model} method2");
        }

        public void Operation3()
        {
            Console.WriteLine($"this is other implamentation{Model} method3");
        }
    }
}
