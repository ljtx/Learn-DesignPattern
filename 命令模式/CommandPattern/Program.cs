using System;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoke i = new Invoke(c);
            i.ExecuteCommand();
            Console.WriteLine("Hello World!");
        }
    }
    public class Receiver
    {
        public void Run()
        {
            Console.WriteLine("所有士兵跑1万米");
        }
    }
    // 命令抽象类
    public abstract class Command 
    {
         // 命令应该知道接收者是谁，所以有Receiver这个成员变量
         protected Receiver _receiver;
 
         public Command(Receiver receiver)
         {
             this._receiver = receiver;
         }
 
         // 命令执行方法
         public abstract void Action();
    }
     // 教官，负责调用命令对象执行请求
      public class Invoke
      {
          public Command _command;
  
          public Invoke(Command command)
          {
              this._command = command;
          }
 
         public void ExecuteCommand()
         {
             _command.Action();
         }
     }
     // 
     public class ConcreteCommand :Command
     {
         public ConcreteCommand(Receiver receiver)
             : base(receiver)
         { 
         }
 
         public override void Action()
         {
             // 调用接收的方法，因为执行命令的是士兵
             _receiver.Run();
         }
     }
}
