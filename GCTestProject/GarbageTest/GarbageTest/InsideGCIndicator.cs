using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageTest
{
    class InsideGCIndicator
    {
        private static int Flag = 0;
        public static int Status { get; set; }

        public static void StartWatch()
        {
            Flag = 0;
            Generator();
        }
        public static void StopWatch()
        {
            Flag = 1;
        }

        ~InsideGCIndicator()
        {
            Console.WriteLine($"Пришел сборщик мусора статус {Status}");

            if (Flag == 1)
            {
                GC.SuppressFinalize(this);
            }
            else {
                Status = 0;
                Generator();
            }
        }

        private static void Generator()
        {
            var MUSOR = new InsideGCIndicator();
        }
    }
}
