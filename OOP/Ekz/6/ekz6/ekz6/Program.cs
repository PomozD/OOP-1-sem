using System;
using System.Collections.Generic;

namespace ekz6
{
    //опред-ть класс Location со св-ми X и Y. Опред класс DayPath(путь). Он содержит коллекцию точек Location.
    //В классе опред методы добавления точек адд, удаления делит, очистки клеар, перегрузите оператор == сравн-я 2-х путей по длине.
    //Метод countLocation подсчит-т кол-во одинаковых точек.

    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public static bool operator ==(Location loc1, Location loc2)
        {
            if ((loc1.X == loc2.X) && (loc1.Y == loc2.Y))
            {
                return true;
            }
            else
            {
                return false;
            }   

        }
        public static bool operator !=(Location loc1, Location loc2)
        {
            if ((loc1.X != loc2.X) && (loc1.Y != loc2.Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CountLocation(Location other)
        {
            if (this.X == other.X && this.Y == other.Y)
            {
                Console.WriteLine("Точки одинаковые");
                return 0;
            }
            else
            {
                Console.WriteLine("Точки неодинаковые");
                return 1;
            }
        }
    }
    public class DayPath<T> where T : Location
    {
        List<T> ex = new List<T>();
        public void Add(T el)
        {
            ex.Add(el);
        }
        public void Del(T el)
        {
            ex.Remove(el);
        }
        public void Clear()
        {
            ex.Clear();
        }
        public void Print()
        {
            foreach (var pr in ex)
            {
                Console.WriteLine("X: " + pr.X + " " + "Y: " + pr.Y);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DayPath<Location> dayPath = new DayPath<Location>();
            Location location1 = new Location(1, 1);
            Location location2 = new Location(2, 1);
            Location location3 = new Location(1, 1);
            Location location4 = new Location(2, 2);

            dayPath.Add(location1);
            dayPath.Add(location2);
            dayPath.Add(location3);
            dayPath.Add(location4);

            Console.WriteLine("Добавленные элементы: ");
            dayPath.Print();

            location1.CountLocation(location2);
            location1.CountLocation(location3);

            if(location1 == location3)
            {
                Console.WriteLine("Пути 1 и 3 равны");
            }
            else
            {
                Console.WriteLine("Пути 1 и 3 неравны");
            }

            dayPath.Del(location4);

            Console.WriteLine("Элементы после удаления: ");
            dayPath.Print();

            dayPath.Clear();
            Console.WriteLine("Элементы после очистки: ");
            dayPath.Print();
        }
    }
}
