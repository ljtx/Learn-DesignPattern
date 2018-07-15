using System;

namespace IteratorPattern
{
    /// <summary>
    /// 抽象聚合类
    /// </summary>
    public interface IAggregate
    {
        Iterator GetIterator();
    }
 
    // 迭代器抽象类
    public interface Iterator
    {
        bool MoveNext();
        Object GetCurrent();
        void Next();
        void Reset();
    }
    public sealed class ConcreteAggregate:IAggregate
    {
        private string[] collection;

        public ConcreteAggregate()
        {
            collection = new string[] { "白羊","金牛","双子","巨蟹" };
        }
 
        public Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }
 
        public int Length
        {
            get { return collection.Length; }
        }
 
        public string GetElement(int index)
        {
            return collection[index];
        }
    }
  // 具体迭代器类
    public sealed class ConcreteIterator : Iterator
    { 
        private ConcreteAggregate _list;
        private int _index;
 
        public ConcreteIterator(ConcreteAggregate list)
        {
            _list = list;
            _index = 0;
        }
 
        public bool MoveNext()
        {
            if (_index < _list.Length)
            {
                return true;
            }
            return false;
        }
 
        public Object GetCurrent()
        {
            return _list.GetElement(_index);
        }
 
        public void Reset()
        {
            _index = 0;
        }
 
        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }
 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Iterator iterator;
            IAggregate list = new ConcreteAggregate();
            iterator = list.GetIterator();
 
            while (iterator.MoveNext())
            {
                string ren = (string)iterator.GetCurrent();
                Console.WriteLine(ren);
                iterator.Next();
            }
 
            Console.ReadKey();
        }
    }
}
