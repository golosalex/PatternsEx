using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageTest
{
    class MusorMaker
    {
        public static void CreateMusor()
        {
            var a = new Musor(100);
        }
        class Musor
        {
            int A { get; set; }
            public Musor(int a)
            {
                this.A = a;
            }
        }
    }
}
