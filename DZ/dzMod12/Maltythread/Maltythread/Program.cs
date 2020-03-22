using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DAL;

namespace Maltythread
{
    class Program
    {


        static void Main(string[] args)
        {

            int Max = 100000; // 100 000 персонов: всего в фаил планируется залить 10 миллионов человек



            int Partion = int.Parse(Console.ReadLine()); // получили размер порции например 1000
            int LengthOfQueue = Max / Partion; // максимальная длина очереди

            

            PersonsProvider a = new PersonsProvider(); // создаем экземпляр, который будет генерировать порции для очереди

            //Console.WriteLine(LengthOfQuery);
            MyQueue queue = new MyQueue(LengthOfQueue); // создаем очередь ограниченной длинны

            Thread WriteThread = new Thread(() => ReadMethod(queue));
            WriteThread.Start(); // с этого момента 2 потока

            while (true)
            {
                if (queue.full)
                {
                    continue;
                }

                queue.push();
                // прервать цикл когда будет 10 000 000 человек в текстовом файле.
            }






        }

        private static void ReadMethod(MyQueue query)
        {
            throw new NotImplementedException();
        }
    }
}