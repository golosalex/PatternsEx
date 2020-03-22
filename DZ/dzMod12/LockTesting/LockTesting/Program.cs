using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LockTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Node N1 = new Node();
            Node N2 = new Node();

            Thread t = new Thread(() => N1.Print1());
            t.Start();
            Thread.Sleep(10);

            N1.Print2();

            

        }

        
    }
}
