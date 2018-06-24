using System;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            FacadeStartUpCompunter computer=new FacadeStartUpCompunter();
            computer.Start();
            Console.WriteLine("Hello World!");
        }
    }
    public class StartUpCPU
    {
       public void Start()
       {
           Console.WriteLine("启动cpu");
       }
    }
    public class StartUpMemory
    {
       public void Start()
       {
           Console.WriteLine("启动内存");
       }
    }
    public class StartUpDisk
    {
       public void Start()
       {
           Console.WriteLine("启动硬盘");
       }
    }

    public class FacadeStartUpCompunter
    {
        private StartUpCPU cpu;
        private StartUpMemory memory;
        private StartUpDisk disk;
        public FacadeStartUpCompunter()
        {
            cpu= new StartUpCPU();
            memory= new StartUpMemory();
            disk=new StartUpDisk();
        } 
        public void Start()
        {
            cpu.Start();
            memory.Start();
            disk.Start();
        }
    }
}
