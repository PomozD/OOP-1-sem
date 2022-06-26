using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ekz5
{
    public class SomeString
    {
        public StringBuilder str;
        public int length;
        public SomeString(string s)
        {
            str = new StringBuilder(s.Substring(0, length));
        }
        public int GetCount(string str)   //подсчет количества элементов
        {
            int strLen = str.Length;
            return strLen;
        }
        public void Print()
        {
            Console.WriteLine($"строка: {str}");
        }
    }
    public static class StaticClass
    {
        public static int CountProbel(this string str)  //подсчет пробелов
        {
            string[] st1 = str.Split(' ');
            return (st1.Length - 1);
        }
        public static string DeleteZnaki(this string str)  //удаление знаков припинания
        {
            string[] st2 = str.Split(',');
            string s = null;
            foreach (string _str in st2)
            {
                s += _str;
            }
            return s;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            SomeString str = new SomeString("Hello World, I'am Daniel");
            Console.WriteLine(str.ToString(), str.length);
            Console.WriteLine("Количество пробелов: ", StaticClass.CountProbel(str.ToString()));
            Console.WriteLine("Без знаков припинания: ", StaticClass.DeleteZnaki(str.ToString()));



        }
    }
}
