using System;
using System.Collections.Generic;
namespace observerPattern
{
    /// <summary>
    /// 游戏订阅类
    /// </summary>
    public abstract class GameSteam
    {
        private List<IObserver> observers = new List<IObserver>();
        public string Symbol{get;set;}
        public string Info{get;set;}
        public GameSteam(string Symbol,string Info)
        {
            this.Symbol=Symbol;
            this.Info = Info;
        }

        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }
        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }
        public void Update()
         {
             // 遍历订阅者列表进行通知
             foreach (IObserver ob in observers)
             {
                 if (ob != null)
                 {
                     ob.ReceiveAndTell(this);
                }
             }
         }
    }
    public interface IObserver
    {
        void ReceiveAndTell(GameSteam tenxun);
    }
    // 具体的订阅者类
     public class Subscriber : IObserver
     {
         public string Name { get; set; }
         public Subscriber(string name)
         {
             this.Name = name;
         }
 
         public void ReceiveAndTell(GameSteam tenxun)
         {
             Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
         }
     }
      // 具体订阅号类
     public class TenXunGame : GameSteam
     {
         public TenXunGame(string symbol, string info) 
             : base(symbol, info) 
         { 
         }
     }
    class Program
    {
        static void Main(string[] args)
        {
            GameSteam tenXun = new TenXunGame("TenXun Game", "Have a new game published ....");
 
             // 添加订阅者
             tenXun.AddObserver(new Subscriber("Learning Hard"));
             tenXun.AddObserver(new Subscriber("Tom"));
 
             tenXun.Update();
 
             Console.ReadLine();
        }
    }
}
