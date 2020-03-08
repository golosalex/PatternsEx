using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// пример написан на основе видио https://www.youtube.com/watch?v=ANlcc2p9kCU&list=PLwcDaxeEINactCC4mly7RQon5juIpH-Q3&index=3
namespace FasadePatternConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Power pow = new Power();
            pow.On();
            DVDRom dvd = new DVDRom();
            dvd.Load();

            HDD hdd = new HDD();
            hdd.CopyFromDVD(dvd);
        }
    }
    
    class Power
    {
        public void On()
        {
            Console.WriteLine("включение питания");

        }
        public void Off()
        {
            Console.WriteLine("Выключение питания");
        }
    }
    class DVDRom
    {
        private bool data = false;
        public bool Data
        {
            get
            {
                return data;
            }
            
        }

        public void Load()
        {
            data = true;
        }

        public void Unload()
        {
            data = false;
        }
    }

    class HDD
    {
        public void CopyFromDVD(DVDRom dvd)
        {
            if (dvd.Data)
            {
                Console.WriteLine("Данные скопированы");
            }
            else
            {
                Console.WriteLine("Нет диска в дисководе");
            }
        }
    }
}
