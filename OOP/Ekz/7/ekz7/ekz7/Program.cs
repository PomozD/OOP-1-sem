using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace ekz7
{

    //Создайте класс ShoppingList, хранящий List<Item> и методы DeleteF — удаление первого эл-та списка,
    //DeleteL — удаление последнего, Add — добавление + исключение, если Item уже существует,
    //Count — возвращает кортеж: число пунктов и сумму всех Item в списке; WriteListToFile — метод записи в тектовый файл

    public class Items
    {
        public string Name;
        public int id;
        public Items(int id, string Name)
        {
            this.Name = Name;
            this.id = id;
        }
    }
    public class ShoppingList<Item> where Item : Items
    {
        List<Item> items = new List<Item>();

        public void Add(Item el)
        {
            try
            {
                items.Add(el);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteF(Item el) // удаление первого элемента
        {
            items.RemoveAt(0);
        }
        public void DeleteL(Item el) // удаление последнего элемента
        {
            items.RemoveAt(items.Count - 1);
        }

        public void Count()
        {
            var sum = 0;
            foreach(var i in items)
            {
                sum += i.id;
            }
            Console.WriteLine("Количество пунктов: " + items.Count + " " + "Сумма всех пунктов в списке: " + sum);
        }
        public void Print()
        {
            foreach (var pr in items)
            {
                Console.WriteLine("ID: " + pr.id + " " + "Название: " + pr.Name);
            }
        }

        public void SerializeAndSave(string path, List<Item> data)
        {
            var serializer = new XmlSerializer(typeof(List<Item>));
            using (var writer = new StreamWriter("file.txt"))
            {
                serializer.Serialize(writer, data);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingList<Items> item = new ShoppingList<Items>();

            Items item1 = new Items(1, "item1");
            Items item2 = new Items(2, "item2");
            Items item3 = new Items(3, "item3");
            Items item4 = new Items(4, "item4");

            item.Add(item1);
            item.Add(item2);
            item.Add(item3);
            item.Add(item4);
            Console.WriteLine("Добавленные пункты: ");
            item.Print();

            item.Count();

            item.SerializeAndSave("file.txt", item);
        }
    }
}
