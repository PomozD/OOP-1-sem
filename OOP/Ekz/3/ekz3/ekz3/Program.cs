using System;
using System.Collections.Generic;


//Создайте класс AdressBook, хранящий Dictonary<Char, Contact>, где Contact пользовательский тип по свойствами Name, Number(int).
//Класс AdressBook поддердивает интерфейс IUseable с методами Add (добавление элемента в словарь), Delete (удаление), Find (поиск контактов по букве).
//Там, где нужно предусмотрите обработку исключений.
namespace ekz3
{
    interface IUseable
    {
        public void Add(char key, Contact value);
        public void Delete(char key);
        public Contact Find(char key);
    }
    public class AdressBook : IUseable
    {

        Dictionary<Char, Contact> book = new Dictionary<char, Contact>();
        public void Add(char key, Contact value)
        {
            try
            {
                book.Add(key, value);
            }
            catch
            {
                Console.WriteLine("Произошла ошибка при добавлении");
            }
        }

        public void Delete(char key)
        {
            book.Remove(key);
        }

        public Contact Find(char key)
        {
            Contact result;
            if(book.ContainsKey(key))
            {
                result = book[key];
            }
            else
            {
                result = null;
            }
            return result;
        }
        public void Print()
        {
            foreach(var key in book.Keys)
            {
                Console.WriteLine(key.ToString() + book[key].Info());
            }
        }
        
    }
    public class Contact
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public Contact(string Name, int Number)
        {
            this.Name = Name;
            this.Number = Number;
        }
        public string Info()
        {
            return "Имя: " + Name + ", телефон: " + Number;
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            Contact contact1 = new Contact("Name1", 123);
            Contact contact2 = new Contact("Name2", 1234);
            Contact contact3 = new Contact("Name3", 1235);

            AdressBook adress = new AdressBook();
            adress.Print();
            Console.WriteLine("Добавление:");
            adress.Add('1', contact1);
            adress.Add('2', contact2);// Добавление по ключу, который уже есть -- Ошибка
            adress.Add('2', contact2);
            adress.Print();
            adress.Add('3', contact3);
            adress.Print();
            adress.Delete('a');
            Console.WriteLine("После удаления:");
            adress.Print();

            Console.WriteLine("Поиск:");
            Contact result = adress.Find('1');
            Console.WriteLine(result.Info());


            Console.Read();

        }
    }
}
