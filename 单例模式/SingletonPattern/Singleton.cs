using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SingletonPattern
{
    public class Singleton
    {
        public static Singleton singleInstance;

        private static readonly object obj = new object();
        public int a=1;
        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if(singleInstance==null)
            {
                lock(obj)
                {
                    if(singleInstance==null)
                    {
                        singleInstance = new Singleton();
                    }
                }
            }
            return singleInstance;
        }
    }
}