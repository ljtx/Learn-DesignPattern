using System;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个代理对象并发出请求
            Person proxy = new Friend();
            proxy.Buy();
            Console.WriteLine("Hello World!");
        }
    }
    public abstract class Person
    {
        public abstract void Buy();
    }

    public class NeedApplePerson:Person
    {
        public override void Buy()
        {
            Console.WriteLine("帮忙买一个苹果电脑");
        }
    }

    public class Friend:Person
    {
        NeedApplePerson needApplePerson;
        public override void Buy()
        {
            Console.WriteLine("代理方法开始");
            if(needApplePerson==null)
            {
                needApplePerson = new NeedApplePerson();

            }
            this.PreBuyProduct();
            // 调用真实主题方法
            needApplePerson.Buy();
            this.PostBuyProduct();
        }
        // 代理角色执行的一些操作
        public void PreBuyProduct()
        {
            // 可能不知一个朋友叫这位朋友带东西，首先这位出国的朋友要对每一位朋友要带的东西列一个清单等
            Console.WriteLine("我怕弄糊涂了，需要列一张清单，张三：要带相机，李四：要带Iphone...........");
        }
         // 买完东西之后，代理角色需要针对每位朋友需要的对买来的东西进行分类
        public void PostBuyProduct()
        {
            Console.WriteLine("终于买完了，现在要对东西分一下，相机是张三的；Iphone是李四的..........");
        }
    }
}
