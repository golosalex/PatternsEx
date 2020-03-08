using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IComponent c1 = new Circle();
            IComponent c2 = new Circle();
            IComponent s1 = new Square();
            Triangle t1 = new Triangle();
            IComponent s2 = new Square();

            Plane pl1 = new Plane();
            pl1.AddComponent(c1);
            pl1.AddComponent(c2);
            pl1.AddComponent(s1);
            pl1.AddComponent(t1);

            
            Plane pl3 = new Plane();
            pl3.AddComponent(pl1);
            pl3.AddComponent(s2);
            pl3.Drow();
        }
    }

    interface IComponent
    {
        void Drow();
    }
    interface ICompozite:IComponent
    {
        void AddComponent(IComponent component);
        void DeleteComponent(IComponent component);
    }

    class Circle : IComponent
    {
        public void Drow()
        {
            Console.WriteLine("я круг!");
        }
    }
    class Triangle : IComponent
    {
        public void Drow()
        {
            Console.WriteLine("я треугольник");
        }
    }
    class Square : IComponent
    {
        public void Drow()
        {
            Console.WriteLine("я квадрат");
        }
    }

    class Plane : ICompozite
    {
        private List<IComponent> ComponentList = new List<IComponent>();
        public void AddComponent(IComponent component)
        {
            ComponentList.Add(component);
        }

        public void DeleteComponent(IComponent component)
        {
            ComponentList.Remove(component);
        }

        public void Drow()
        {
            Console.WriteLine("привет я плоскость внутри у меня:");
            foreach(IComponent com in ComponentList)
            {
                Console.Write("\t");
                com.Drow();
            }
            Console.WriteLine("конец плоскости");
        }
    }
}
