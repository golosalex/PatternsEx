using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            InsideGCIndicator.StartWatch();

            for(int i = 0; i < 100000000; i++)
            {
                InsideGCIndicator.Status=i;
                MusorMaker.CreateMusor();
            }

            InsideGCIndicator.StopWatch();
            
        }
    }
}
