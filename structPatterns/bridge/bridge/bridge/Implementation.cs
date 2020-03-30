using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bridge
{
    class Implementation:IImplemator
    {
        public int Model { get; set; }
        public void Operation1()
        {
            Console.WriteLine($"this is op1 model ={Model}");
        }

        public void Operation2()
        {
            Console.WriteLine($"this is op2 model ={Model}");
        }

        public void Operation3()
        {
            Console.WriteLine($"this is op3 model ={Model}");
        }
    }
}
