using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            const int allFileVol = 1000000;
            const int max = 100000; // 100 000 персонов максимум в очереди: всего в фаил планируется залить 10 миллионов человек
            Console.WriteLine("введите размер порции. экспериментально рекомендованно от 1000 до 5000");
            Console.WriteLine("ожидаемое время записи 50 секунд два потока и 80 секунд 1 поток");
            int portion = int.Parse(Console.ReadLine()); // получили размер порции например 1000
            int lengthOfQueue = max / portion; // максимальная длина очереди
            MyQueue<Person[]> queue = new MyQueue<Person[]>(lengthOfQueue);

            PersonsProvider provider = new PersonsProvider(); // создаем экземпляр, который будет генерировать порции для очереди
            string directory = Directory.GetCurrentDirectory();
            string fullname = Path.Combine(directory, "big1.txt");
            Stopwatch timer=new Stopwatch();

            timer.Start();
            Thread thread1 = new Thread(() => AdderToQueue(queue, provider, allFileVol, portion));
            thread1.Start();

            using (StreamWriter sw = new StreamWriter(fullname))
            {
                Person[] persons;
                int waitTime = 0;
                int waitDelta = 200;
                while (true)
                {
                    //код для слежения за полнотой очереди.
                    //Console.WriteLine($"полнота очереди{1.0*queue.Vol/queue.MaxVol*100}%");// полнота очереди

                    persons = queue.Dequeue();
                    if (persons == null)
                    {
                        if (thread1.IsAlive)
                        {
                            waitTime += waitDelta;
                            Console.WriteLine($"при запись в файл спали {waitTime}мс");
                            Thread.Sleep(waitDelta);//на практике 200мс это примерное время заполнения очереди до 20%.
                            continue;
                        }
                        else
                        {
                            if (queue.Vol>0) continue;
                            break;
                        }
                    }

                    foreach (var person in persons)
                    {
                        sw.WriteLine(person);
                    }

                    waitTime = 0;
                }    
            }
            timer.Stop();
            Console.WriteLine($"запись в двухпоточном режиме {timer.ElapsedMilliseconds}");
            
            
            //однопоточный вариант
            Console.WriteLine("Запись в однопоточном режиме начата. примерное время ожидания в 1.5 больше чем у двухпоточного");
            timer = new Stopwatch();
            timer.Start();
            fullname = Path.Combine(directory, "big2.txt");
            using (StreamWriter sw = new StreamWriter(fullname))
            {
                
                int index = 0;
                while (index < allFileVol)
                {
                    Person[] p = provider.GetPersons(index + 1, portion);
                    foreach (var person in p)
                    {
                        sw.WriteLine(person);
                    }
                    //queue.Enqueue(provider.GetPersons(index + 1, portion));
                    index = index + portion;
                } 
            }
            timer.Stop();
            Console.WriteLine($"запись в однопоточном режиме {timer.ElapsedMilliseconds}");
            

        }

        private static void AdderToQueue(MyQueue<Person[]> queue, PersonsProvider provider, int allFileVol, int portion)
        {
            int index = 0;
            while (true)
            {
                if (index > allFileVol) throw new Exception("place extra person");
                if (index==allFileVol) break;
                if (index + portion > allFileVol) portion = allFileVol - index;

                bool success = false;
                for (int i = 0; i < 200; i++)
                {
                    if (queue.Vol >= queue.MaxVol)
                    {
                        Thread.Sleep(20);
                        Console.WriteLine($"при добавлении в полную очередь спали примерно {(i+1)*20} милисекунд");
                    }
                    else
                    {
                        queue.Enqueue(provider.GetPersons(index+1,portion));
                        index = index + portion;
                        success = true;
                        break;
                    }
                }
                if(!success)throw new Exception("очередь полна более четырех секунд");


            }
        }
    }
}