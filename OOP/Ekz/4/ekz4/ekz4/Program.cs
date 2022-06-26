using System;
using System.Collections.Generic;
using System.Linq;

namespace ekz4
{
    //Создайте обобщённый класс Box, имеющий ограничение параметра на значение.
    //Box содержит List параметризированных объектов и макс-ю вместимость (целое число, которое опред макс число эл-в списка).
    //Для Box создайте методы: Add – добавления объекта в список, при этом необходимо проверять, превышена ли макс-я вместительность, если да генерируйте исключение;
    //Delete (удаление из списка), Print (вывода содержимого коробки). О
    //пределите 3 объекта типа Present (пользовательский тип и содержит имя и описание). Разместите их в коробке (Box).
    public class Box<T> where T: Present
    {
        List<T> Example = new List<T>(5);
        public void AddElement(T el)
        {
            try
            {
                if (Example.Count() >= 3)
                {
                    throw new Exception("Превышена максимальная вместимость");
                }
                else
                {
                    Example.Add(el);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteElement(T el)
        {
            Example.Remove(el);
        }
        public void Print()
        {
            foreach(var pr in Example)
            {
                Console.WriteLine("Имя: " + pr.Name + " " + "Описание: " + pr.Description);
            }
        }
    }
    public class Present
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Present(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
        public void Info()
        {
            Console.WriteLine("Имя: " + Name + " " + "Описание: " + Description + " ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Box<Present> box = new Box<Present>();
            Present present1 = new Present("Present1", "DescriptionP1");
            Present present2 = new Present("Present2", "DescriptionP2");
            Present present3 = new Present("Present3", "DescriptionP3");
            Present present4 = new Present("Present4", "DescriptionP4");

            box.AddElement(present1);
            box.AddElement(present2);
            box.AddElement(present3);
            box.AddElement(present4);

            Console.WriteLine("Коробка после добавления элементов: ");

            box.Print();

            box.DeleteElement(present2);

            Console.WriteLine("Коробка после удаления элементов: ");

            box.Print();
        }
    }
}
