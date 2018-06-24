using System;

namespace ChainOfResponsibilityPattern
{
    public sealed class AskLeaveRequest
    {
        /// <summary>
        /// 请假人
        /// </summary>
        /// <returns></returns>
        public string Name{get;set;}
        /// <summary>
        /// 请假天数
        /// </summary>
        /// <returns></returns>
        public double Days{get;set;}

        public AskLeaveRequest(string name,double days)
        {
            Name=name;
            Days=days;
        }
    }
    //抽象审批人,Handler---相当于“抽象处理者角色”
      public abstract class Approver
      {
          //下一位审批人，由此形成一条链
          public Approver NextApprover { get; set; }
  
          //审批人的名称
          public string Name { get; set; }
  
          public Approver(string name)
          {
              this.Name = name;
          }
  
          //处理请求
          public abstract void ProcessRequest(AskLeaveRequest request);
      }
      //部门经理----相当于“具体处理者角色” ConcreteHandler
     public sealed class Manager : Approver
      {
          public Manager(string name): base(name){ }
   
          public override void ProcessRequest(AskLeaveRequest request)
          {
              if (request.Days <= 3.0)
              {
                  Console.WriteLine("{0} 部门经理批准了{1}的请假！", this.Name, request.Name);
              }
              else if (NextApprover != null)
              {
                  NextApprover.ProcessRequest(request);
              }
          }
      }
       public sealed class HR : Approver
      {
          public HR(string name): base(name){ }
   
          public override void ProcessRequest(AskLeaveRequest request)
          {
              if (request.Days <= 3.0)
              {
                  Console.WriteLine("{0} 人力资源批准了{1}的请假！", this.Name, request.Name);
              }
              else if (NextApprover != null)
              {
                  NextApprover.ProcessRequest(request);
              }
          }
      }
    class Program
    {
        static void Main(string[] args)
        {
            AskLeaveRequest request1 = new AskLeaveRequest("李江",1.0);
            Approver manager = new Manager("mrs陈");
            Approver Hr = new HR("mr张");
            manager.NextApprover=Hr;
            manager.ProcessRequest(request1);
            Console.WriteLine("Hello World!");
        }
    }
}
