using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    /// <summary>
      /// 这个类型才是组装的，Construct方法里面的实现就是创建复杂对象固定算法的实现，该算法是固定的，或者说是相对稳定的
      /// 也就是建造者模式中的指挥者
      /// </summary>
    public class Director
    {
          // 组装汽车
        public void Construct(Builder builder)
        {
            builder.BuildBikeChain();
            builder.BuildBikeWheel();
            builder.BuildBikeFrame();
        }
     }
    /// <summary>
    /// 自行车类
    /// </summary>
    public sealed class Bike
    {
        // 自行车部件集合
        private IList<string> parts = new List<string>();
  
          // 把单个部件添加到自行车车部件集合中
          public void Add(string part)
          {
              parts.Add(part);
          }
  
          public void Show()
          {
              Console.WriteLine("单车开始在组装.......");
              foreach (string part in parts)
             {
                  Console.WriteLine("组件" + part + "已装好");
              }
  
              Console.WriteLine("单车组装好了");
          }    
     }
     /// <summary>
     /// 抽象建造者
     /// </summary>
    public abstract class Builder
    {
         // 创建车链
          public abstract void BuildBikeChain();
         // 创建车轮
          public abstract void BuildBikeWheel();
          //创建车架
          public abstract void BuildBikeFrame();
          // 当然还有部件，大灯、方向盘等，这里就省略了
  
          // 获得组装好的汽车
          public abstract Bike GetBike();
    }
    public sealed class MoBikeBuilder:Builder
    {
        Bike bike1 = new Bike();
        public override void BuildBikeChain()
        {
            bike1.Add("摩拜的车链子");
        }
        public override void BuildBikeWheel()
        {
            bike1.Add("摩拜的车轮");
        }
        public override void BuildBikeFrame()
        {
            bike1.Add("摩拜的车架");
        }
        public override Bike GetBike()
        {
            return bike1;
        }
    
    }
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            Builder mobikeBuiler1 = new MoBikeBuilder();
            director.Construct(mobikeBuiler1);
            Bike mobobike = mobikeBuiler1.GetBike();
            mobobike.Show();
        }
    }
}
