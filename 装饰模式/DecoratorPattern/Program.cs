using System;

namespace DecoratorPattern
{
    public abstract class House
    {
          //房子的装修方法--该操作相当于Component类型的Operation方法
        public abstract void Renovation();
    }
     public abstract class DecorationStrategy:House //关键点之二，体现关系为Is-a，有这这个关系，装饰的类也可以继续装饰了
     {
         protected House _house;

         protected DecorationStrategy(House house)
         {
             this._house=house;
         }

         public override void Renovation()
         {
             if(this._house!=null)
             {
                 this._house.Renovation();
             }
         }
     }
     public sealed class MyHouse:House
     {
         public override void Renovation()
         {
             Console.WriteLine("装修我的房子");
         }
     }
      /// <summary>
     /// 具有安全功能的设备，可以提供监视和报警功能，相当于ConcreteDecoratorA类型
     /// </summary>
     public sealed class HouseSecurityDecorator:DecorationStrategy
     {
         public  HouseSecurityDecorator(House house):base(house){}
 
         public override void Renovation()
         {
             base.Renovation();
             Console.WriteLine("增加安全门禁系统");
         }
    }
   
     public sealed class AirConditionDecorator:DecorationStrategy
     {
         public  AirConditionDecorator(House house):base(house){}
 
         public override void Renovation()
         {
             base.Renovation();
             Console.WriteLine("安装空调");
         }
    }
    class Program
    {
        static void Main(string[] args)
        {
            House myselfHouse=new MyHouse();
            DecorationStrategy securityHouse=new HouseSecurityDecorator(myselfHouse);
            //securityHouse.Renovation();
            DecorationStrategy securityAndWarmHouse=new AirConditionDecorator(securityHouse);
             securityAndWarmHouse.Renovation();
            Console.WriteLine("Hello World!");
        }
    }
}
