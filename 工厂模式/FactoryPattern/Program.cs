using System;
using System.Collections.Generic;

namespace FactoryPattern
{
    /// <summary>
    /// 房屋抽象类
    /// </summary>
    public abstract class House
    {
        public abstract void buy();
    }
    public class BigHouse:House
    {
        public override void buy()
        {
            Console.WriteLine("买大房子");
        }
    }
    public class SmallHouse:House
    {
        public override void buy()
        {
            Console.WriteLine("买小房子");
        }
    }
    public abstract class Factory
    {
        public abstract House Create();
    }
    public class BigFactory:Factory
    {
        public override House Create()
        {
            return new BigHouse();
        }
    }
    public class SmallFactory:Factory
    {
        public override House Create()
        {
            return new SmallHouse();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Factory bigf = new BigFactory();
            House bigh= bigf.Create();
            bigh.buy();
            Factory smallf = new SmallFactory();
            House smallh = smallf.Create();
            smallh.buy();
            Console.WriteLine("Hello World!");
        }
    }
}
