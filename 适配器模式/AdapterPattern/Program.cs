using System;

namespace AdapterPattern
{
    public class ChinaHoleTarget
    {
        public virtual void Request()
        {
            Console.WriteLine("大陆的充电器专用");
        }
    }
    public class AmricanHoleTarget
    {
        public virtual void SRequest()
        {
            Console.WriteLine("美国的充电器专用");
        }
    }
    public class AmricanToChinaAdapter:ChinaHoleTarget
    {
        private AmricanHoleTarget usHole = new AmricanHoleTarget();
        public override void Request()
        {
            usHole.SRequest();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChinaHoleTarget zhHole = new AmricanToChinaAdapter();
            zhHole.Request();
            Console.WriteLine("Hello");
        }
    }
}
