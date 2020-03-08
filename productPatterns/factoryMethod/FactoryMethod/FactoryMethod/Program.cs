using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    
    class Program
    {
        static void Main(string[] args)
        {
            DigitalWhatch w1 = new DigitalWhatch();
            w1.ShowTime();

            RomeWhatch w2 =new RomeWhatch();
            w2.ShowTime();

            IWhatchMaker maker = new RomeWhatchMaker();
            IWhatch w3 = maker.MakeWatch();
            w3.ShowTime();
        }
    }
    interface IWhatch
        {
            void ShowTime();
        }
    class DigitalWhatch : IWhatch
    {
        public void ShowTime()
        {
            Console.WriteLine($"time is {DateTime.Now}");
        }
    }
    class RomeWhatch : IWhatch
    {
        public void ShowTime()
        {
            Console.WriteLine($"thime is {DateTime.Now.ToLongDateString()}");
        }
    }

    interface IWhatchMaker
    {
        IWhatch MakeWatch();
    }
    class DigitalWhatchMaker : IWhatchMaker
    {
        public IWhatch MakeWatch()
        {
            return new DigitalWhatch();
        }
    }
    class RomeWhatchMaker : IWhatchMaker
    {
        public IWhatch MakeWatch()
        {
            return new RomeWhatch();
        }
    }
}
