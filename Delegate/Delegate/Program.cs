using System;
using System.Collections.Generic;

namespace Delegate
{

    class Program
    {
        #region Delegate,Generic type delegate

        public delegate bool Check(int item);
        public delegate R ReturnTypeMethod<in T, out R>(T item);
        //public delegate void Print(string item);
        //public delegate void PrintInt(int item);
        //public delegate void PrintChar(char item);
        public delegate void Print<in T>(T item);
        public delegate bool Test<in T>(T item);
        #endregion

        static void Main(string[] args)
        {
            #region Delegate
            //Console.WriteLine(Sum(IsEven,1,2,3,4,5));
            //Console.WriteLine(Sum(IsOdd,1,2,3,4,5));
            //Console.WriteLine(Sum(n=>n>=3, 1,2,3,4,5));

            //Action<string> print = new Action<string>(Write);
            ////Print<string> print = new Print<string>(Write);
            ////Print print = Write;
            //print += FirstLetter;
            //print += LetterCount;
            ////lambda expression - anonimouse function
            //print += word => Console.WriteLine($"Upper word: {word.ToUpper()}");

            ////print += delegate (string word)
            ////  {
            ////      Console.WriteLine($"Lower word: {word.ToLower()}");
            ////  };
            //print += word => Console.WriteLine($"Lower word: {word.ToLower()}");

            //print -= Write;
            //print -= FirstLetter;
            //print -= word => Console.WriteLine($"Upper word: {word.ToUpper()}");
            //print("Kamran");
            //print.Invoke("Kamran");

            //Action<int> print1 = IntWrite;


            //Predicate<int> test = IsEven;
            //List<string> list = new List<string>();
            //list.Add("Ferid");
            //list.Add("Gulbahar");
            //list.Add("Nermin");
            //list.Add("Orkhan");

            //Console.WriteLine(list.Find(s=>s=="Ferid"));

            //Func<int> func = delegate() {
            //    return 5;
            //};

            //Func<int, string> func1 = n => $"Number:{n}";
            #endregion

            Student s1 = new Student("Sadiq Abdullayev", 65);
            Student s2 = new Student("Gulbahar Memmedova", 85);
            s1.Notify += score =>
            {
                if (score >= 65)
                {
                    Console.WriteLine("Sadiqden bir denedi!!!");
                    return;
                }
                Console.WriteLine("Biz Sadiqe layiq olmadiq");
            };

            s2.Notify += score =>
            {
                if (score >= 65)
                {
                    Console.WriteLine("Tebrikler!!!");
                    return;
                }
                Console.WriteLine("Teessuf");
            };

            s1.SendMessage();
            s2.SendMessage();
        }

        #region Delegate
        static int Sum(Check func, params int[] arr)
        {
            int result = 0;
            foreach (int item in arr)
            {
                if (func(item))
                    result += item;
            }
            return result;
        }

        static bool IsEven(int item)
        {
            return item % 2 == 0;
        }

        static bool IsOdd(int item)
        {
            return item % 2 != 0;
        }


        //static void IntWrite(int n)
        //{
        //    Console.WriteLine(n);
        //}
        //static void Write(string word)
        //{
        //    Console.WriteLine($"Word: {word}");
        //}

        //static void FirstLetter(string word)
        //{
        //    Console.WriteLine($"First Letter: {word[0]}");
        //}

        //static void LetterCount(string word)
        //{
        //    Console.WriteLine($"Letter Count: {word.Length}");
        //}


        #endregion
    }

    class Student
    {
        public string Fullname { get; set; }
        public int Score { get; set; }
        public event Action<int> Notify;

        public Student(string fulname,int score)
        {
            Fullname = fulname;
            Score = score;
        }

        public void SendMessage()
        {
            Notify(Score);
            //if (Score >= 65)
            //{
            //    Console.WriteLine("Tebrikler");
            //    return;
            //}
            //Console.WriteLine("Kesildiniz");
        }
    }
}
