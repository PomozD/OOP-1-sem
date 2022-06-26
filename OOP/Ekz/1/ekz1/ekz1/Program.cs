using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ekz1
{
    ///Создать класс User с закрытыми полями login и password. Добавьте свойства для изменения этих значений. 
    ///Переопределить в классе все public методы Object. Перегрузить метод CompareTo стандартного унаследованного интерфейса IComparable, 
    ///который сравнивает пользователей по login. Создать три пользователя и сравнить их. Создать LinkedList<User> с 5-ю пользователями. 
    ///Используя LINQ найдите в коллекции пользователей, у которых длина пароля меньше 6-и и содержит только цифры.

    public interface IComparable
    {
        int CompareTo(object comp);
    }

    public class User : IComparable<User>
    {
        private string login;
        private string password;

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public int CompareTo(User other)
        {
            if (this.login == other.login)
            {
                Console.WriteLine("Логины совпали");
                return 0;
            }
            else
            {
                Console.WriteLine("Логины не совпали");
                return 1;
            }
        }


        //переопределение методов класса Object, GetType() не переопределяется
        public override string ToString()
        {
            return ("login: " + this.login.ToString() + " " + "password: " + this.password.ToString());
        }
        public override bool Equals(object obj)
        {
            User user;
            if (obj == null || (user = obj as User) == null)
            {
                return false;
            }
            return this.login == user.login;
        }
        public override int GetHashCode()
        {
            int hashcode = string.IsNullOrEmpty(this.login) ? 0 : login.GetHashCode();
            hashcode = hashcode * 50;
            return hashcode;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("user1", "123");
            User user2 = new User("user2", "123");
            User user3 = new User("user3", "1234567");
            User user4 = new User("user3", "12345678");
            User user5 = new User("user3", "123456789");

            user1.CompareTo(user2);
            user3.CompareTo(user4);
            user4.CompareTo(user5);

            LinkedList<User> users = new LinkedList<User>();
            users.AddFirst(user1);
            users.AddFirst(user2);
            users.AddFirst(user3);
            users.AddFirst(user4);
            users.AddFirst(user5);

            string reg = @"^[0-9]";
            var search = users.Where(t => Regex.IsMatch(t.Password, reg) && t.Password.Length < 6);
            Console.WriteLine("Пользователей, у которых длина пароля меньше 6-и и содержит только цифры.");
            foreach (User us in search)
            {
                Console.WriteLine(us + " ");
            }
        }
    }
}
