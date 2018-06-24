using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton a=   Singleton.GetInstance();
            int b = a.a;
            Console.WriteLine($"Hello World!{b}",b);
        }
    }
}
