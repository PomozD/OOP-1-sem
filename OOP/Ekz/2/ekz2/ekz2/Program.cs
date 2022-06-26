using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ekz2
{
    ///создайте класс phone содержит 2 номера телефона. создацте класс контак содержит имя , обзект пхон. реализуйте тольок необходимые
    //методы для работы с классами пхон и контакт в контексте данной задчи
    //создайте класс контактлист который содержит dictionary<char, contact>(ключ соответсвует первой букве имени объекта контакт)
    //и методы для добавлления и удаления и просмотра словаря, а также метод getbykey(char)(тип возвращаемоего значени определнить самостоятельно), который
    //возвраащет(не выводит на консоль) последовательность коонтактов с заданым ключом(буквой)
    //напишите демонстрацию работы метода гетбаййкей

    public class Phone
    {
        public string number1 { get; set; }
        public string number2 { get; set; }

        public Phone(string number1, string number2)
        {
            this.number1 = number1;
            this.number2 = number2;
        }
    }
    public class Contact : Phone
    {
        public string Name { get; set; }
        public Phone phone { get; set; }

        public Contact(string Name, string number1, string number2):base(number1, number2)
        {
            this.Name = Name;
            this.phone = new Phone(number1, number2);
        }
        public char GetFirstLetter()
        {
            char letter;
            letter = Convert.ToChar(Name.Substring(4,1));
            return letter;
        }
        public override string ToString()
        {
            return ("Имя: " + this.Name.ToString() + " " + "Первый номер: " + this.number1.ToString() + " " + "Второй номер: " + this.number2.ToString());
        }
    }

    public class Contactlist<T> where T: Contact
    {
        public Dictionary<char, Contact> dict = new Dictionary<char, Contact>();
        public void AddDictionary(Contact item)
        {
            /*if(dict.Count >= 6)
            {
                Console.WriteLine("Превышена максимальная вместимость");
            }
            else
            {
                dict.Add(item.GetFirstLetter(), item);
            }*/
            dict.Add(item.GetFirstLetter(), item);
        }
        public void DeleteDictionary(Contact item)
        {
            dict.Remove(item.GetFirstLetter());
        }
        public void ShowDictionary()
        {
            foreach(var item in dict)
            {
                Console.WriteLine(item);
            }
        }
        public void GetByKey(char c)
        {
            foreach(var itemByKey in dict)
            {
                if (c == itemByKey.Key)
                {
                    Console.WriteLine(itemByKey);
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Contactlist<Contact> contactlist = new Contactlist<Contact>();
            Contact contact1 = new Contact("Name1", "123", "1234");
            Contact contact2 = new Contact("Name2", "123", "12344");
            Contact contact3 = new Contact("Name3", "123", "123455");
            Contact contact4 = new Contact("Name4", "123", "123466");

            contactlist.AddDictionary(contact1);
            contactlist.AddDictionary(contact2);
            contactlist.AddDictionary(contact3);
            contactlist.AddDictionary(contact4);

            Console.WriteLine("Словарь до удаления");
            
            contactlist.ShowDictionary();

            contactlist.DeleteDictionary(contact2);
            contactlist.DeleteDictionary(contact3);

            Console.WriteLine("Словарь после удаления");

            contactlist.ShowDictionary();

            Console.WriteLine("Введите ключ для поиска: ");
            char KeyToSearch = Convert.ToChar(Console.ReadLine());
            contactlist.GetByKey(KeyToSearch);

        }
    }
}
