using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;

namespace Maltythread
{
    public class MyQueue<T> where T: class
    {
        private Node Head { get; set; }
        private Node Tail { get; set; }

        public int MaxVol { get; set; }
        private volatile int _vol;
        public int Vol
        {
            get
            {
                return _vol;
            }
        }

        public MyQueue(int maxVol)
        {
            MaxVol = maxVol;
            Node EmptyElement = new Node();
            Head = Tail = EmptyElement; // в очереди всегда будет хотябы один пустой хлемент(Node.Data=null)
                                        // критерий пустоты очереди при dequeue это head = tail = null
        }

        public void Enqueue(T data)
        {
            Tail.Next = new Node() { Data = data }; // добавленный элемент пока недоступен считывающему потоку
            Interlocked.Increment(ref _vol); // атомарная операция инкремента чтобы Dequeue не испортил
            if(_vol>MaxVol) Console.WriteLine($"был превышен объем очереди на примерно {_vol-MaxVol} элементов, но точно больше чем на 1");
            //контроль максимального объема очереди надо проводить снаружи в вызывающем потоке
            Tail = Tail.Next; // атомарная операция теперь элемент полностью добавлен и доступен.
        }
        public T Dequeue()
        {
            if (Head == Tail)// если голова и хвост совпали то указатель головы не двигать. очередь пуста
            {
                // по логике тут всегда должно быть  Head.Data=null если нет, то эксепшин.
                if (Head.Data != null) throw new Exception("Dequeue uncorect result Loks like more then one thread can use Dequeue method");
                return null; 
            }
            //случай когда head не равно tail. в голове остался пустой элемент с момента инициализации или с прошлого Dequeue
            if (Head.Data == null)
            {
                Head = Head.Next;
                T Templ = Head.Data;
                Head.Data = null; //в голове остался пустой элемент
                Interlocked.Decrement(ref _vol);
                if (_vol < 0) throw new Exception("some problem with queue volume. it has negative value now");
                return Templ;
            }
            //если почему-то оказалось что в head не null то эксепшен. но по логике он возникнуть не может.
            throw new Exception("Loks like more then one thread can use Dequeue method");
        }


        private class Node
        {
            public Node Next { get; set; }
            public T Data { get; set; }
        }
    }
}
