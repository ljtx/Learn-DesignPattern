using System;

namespace MediatorPattern
{
     //抽象中介者角色
    public interface Mediator
    {
        void Command(Department department);
    }
    //总经理--相当于具体中介者角色
    public sealed class President : Mediator
    {
        //总经理有各个部门的管理权限
        private Financial _financial;
        private Market _market;
        private Development _development;

        public void SetFinancial(Financial financial)
        {
            this._financial = financial;
        }
        public void SetDevelopment(Development development)
        {
            this._development = development;
        }
        public void SetMarket(Market market)
        {
            this._market = market;
        }

        public void Command(Department department)
        {
            if (department.GetType() == typeof(Market))
            {
                _financial.Process();
            }
        }
    }
    //同事类的接口
    public abstract class Department
    {
        //持有中介者(总经理)的引用
        private Mediator mediator;

        protected Department(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public Mediator GetMediator
        {
            get { return mediator; }
            private set { this.mediator = value; }
        }

        //做本部门的事情
        public abstract void Process();

        //向总经理发出申请
        public abstract void Apply();
    }
     //开发部门
    public sealed class Development : Department
    {
        public Development(Mediator m) : base(m) { }

        public override void Process()
        {
            Console.WriteLine("我们是开发部门，要进行项目开发，没钱了，需要资金支持！");
        }

        public override void Apply()
        {
            Console.WriteLine("专心科研，开发项目！");
        }
    }
     //财务部门
    public sealed class Financial : Department
    {
        public Financial(Mediator m) : base(m) { }

        public override void Process()
        {
            Console.WriteLine("汇报工作！没钱了，钱太多了！怎么花?");
        }

        public override void Apply()
        {
            Console.WriteLine("数钱！");
        }
    }
    //市场部门
    public sealed class Market : Department
    {
        public Market(Mediator mediator) : base(mediator) { }

        public override void Process()
        {
            Console.WriteLine("汇报工作！项目承接的进度，需要资金支持！");
            GetMediator.Command(this);
        }

        public override void Apply()
        {
            Console.WriteLine("跑去接项目！");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            President mediator = new President();
            Market market = new Market(mediator);
            Development development = new Development(mediator);
            Financial financial = new Financial(mediator);

            mediator.SetFinancial(financial);
            mediator.SetDevelopment(development);
            mediator.SetMarket(market);

            market.Process();
            market.Apply();
            Console.WriteLine("Hello World!");
        }
    }
}
