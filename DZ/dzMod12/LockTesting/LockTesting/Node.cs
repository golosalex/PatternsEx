using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace LockTesting
{
    class Node
    {
        object a=new object();

        public void Print1()
        {
            lock (this)
            {
                while (true)
                {
                    Console.WriteLine("111-111");
                    Thread.Sleep(100);
                }
            }
        }

        public void Print2()
        {
            lock (this)
            {
                while (true)
                {
                    Console.WriteLine("22-22-22");
                    Thread.Sleep(100);
                }
            }
        }
    }
}
