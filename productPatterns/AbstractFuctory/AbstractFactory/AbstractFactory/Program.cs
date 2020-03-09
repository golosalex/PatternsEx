using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    interface IMouse
    {
        void Click();
        void Dbclick();
        void Scroll(int direction);
    }
    interface IKeyboard
    {
        void Print();
        void PrintLn();
    }
    interface ITouchPad
    {
        void Track(int deltaX, int deltaY);
    }

    class RuMouse : IMouse
    {
        public void Click()
        {
            Console.WriteLine("клик");
        }

        public void Dbclick()
        {
            Console.WriteLine("даблклик");
        }

        public void Scroll(int direction)
        {
            Console.WriteLine("скролится");
        }
    }
    class RuKeyboard : IKeyboard
    {
        public void Print()
        {
            Console.WriteLine("просто вывод");
        }

        public void PrintLn()
        {
            Console.WriteLine("вывод в стоку");
        }
    }
    class RuTouchPad : ITouchPad
    {
        public void Track(int deltaX, int deltaY)
        {
            Console.WriteLine($"передвинулись на {deltaX} вбок и на {deltaY} вверх");
        }
    }

    class EnMouse : IMouse
    {
        public void Click()
        {
            Console.WriteLine("click!");
        }

        public void Dbclick()
        {
            Console.WriteLine("dblClick");
        }

        public void Scroll(int direction)
        {
            Console.WriteLine("scroool");
        }
    }
    class EnKeyboard : IKeyboard
    {
        public void Print()
        {
            Console.WriteLine("print");
        }

        public void PrintLn()
        {
            Console.WriteLine("printinline");
        }
    }
    class EnTouchPad : ITouchPad
    {
        public void Track(int deltaX, int deltaY)
        {
            Console.WriteLine($"goto {deltaX} gorizontal{deltaY} vertical");
        }
    }

    interface IDeviceFactory
    {
        IMouse GetMouse();
        IKeyboard GetKeyboard();
        ITouchPad GetTouchPad();
    }
}
