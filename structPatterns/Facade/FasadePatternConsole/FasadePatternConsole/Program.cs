using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// пример написан на основе видио https://www.youtube.com/watch?v=ANlcc2p9kCU&list=PLwcDaxeEINactCC4mly7RQon5juIpH-Q3&index=3
namespace FacadePatternConsole
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

            // то же но через фасад
            ComputerFacade CF = new ComputerFacade
            {
                DVDOfComputer = new DVDRom(),
                PwOfComputer = new Power(),
                HDDOfComputer = new HDD()
            };
            CF.Copy();
        }
    }
    
    //класс - фасад
    class ComputerFacade
    {
        // комплектующие как составные фасада идут в поля класса
        public Power PwOfComputer { get; set; }
        public DVDRom DVDOfComputer { get; set; }
        public HDD HDDOfComputer { get; set; }  

        public void Copy()
        {
            PwOfComputer.On();
            DVDOfComputer.Load();
            HDDOfComputer.CopyFromDVD(DVDOfComputer);
        }

    }
    //рабочие класс
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
