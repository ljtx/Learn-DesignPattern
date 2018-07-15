using System;

namespace StatePattern
{
     public sealed class Order
     {
        private State current;

        public Order()
        {
            current = new WaitForAcceptance();
            IsCancel = false;
        }
        public double Minute {get;set;}
        public bool IsCancel { get; set; }
        public bool TaskFinished{get;set;}
       
        public void SetState(State s)
        {
            current = s;
        }
        public void Action()
        {
            current.Process(this);
        }
    }
    public interface State
    {
        void Process(Order order);
    }
    public class WaitForAcceptance:State
    {
        public void Process(Order order)
        {
            Console.WriteLine("订单开始受理！");
            if (order.Minute < 30 && order.IsCancel)
            {
                Console.WriteLine("您有半个小时的时间可以取消订单！");
                order.SetState(new CancelOrder());
                order.Action();
            }
            order.SetState(new AcceptAndDeliver());
            order.TaskFinished = false;
            order.Action();
        }
    }
     public sealed class AcceptAndDeliver : State
    {
        public void Process(Order order)
        {
            if (order.Minute < 30 && order.IsCancel)
            {
                Console.WriteLine("您有半个小时的时间可以取消订单！");
                order.SetState(new CancelOrder());
                order.Action();
            }
            if (order.TaskFinished==false)
            {
                Console.WriteLine("我们货物已经准备好，可以发货了，不可以撤销订单！");
                order.SetState(new ConfirmationReceipt());
                order.Action();
            }
        }
    }
    public sealed class ConfirmationReceipt : State
    {
        public void Process(Order order)
        {
            Console.WriteLine("检查货物，没问题可以就可以签收！");
            order.SetState(new Success());
            order.TaskFinished = false;
            order.Action();
        }
    }

       
    public sealed class Success : State
    {
        public void Process(Order order)
        {
            Console.WriteLine("订单已经完成");
            order.TaskFinished = true;
        }
    }

       
    public sealed class CancelOrder : State
    {
        public void Process(Order order)
        {
            Console.WriteLine("检查货物，有问题，取消订单！");
            order.TaskFinished = true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            //可以取消订单
           // order.IsCancel = true;
            order.Minute = 20;
            order.Action();
           
            Console.WriteLine("Hello World!");
        }
    }
}
