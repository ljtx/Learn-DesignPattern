using System;
using System.Collections.Generic;
namespace VistorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //如果想执行新增加的操作
            ShapeVisitor visitor = new CustomVisitor();
            AppStructure app = new AppStructure(visitor);

            Shape shape = new Rectangle();
            shape.Draw();//执行自己的操作
            app.Process(shape);//执行新的操作


            shape = new Circle();
            shape.Draw();//执行自己的操作
            app.Process(shape);//执行新的操作


            shape = new Line();
            shape.Draw();//执行自己的操作
            app.Process(shape);//执行新的操作


            Console.ReadLine();
        }
    }

    //抽象图形定义---相当于“抽象节点角色”Element
    public abstract class Shape
    {
        //画图形
        public abstract void Draw();
        //外界注入具体访问者
        public abstract void Accept(ShapeVisitor visitor);
    }
     //抽象访问者 Visitor
    public abstract class ShapeVisitor
    {
        public abstract void Visit(Rectangle shape);

        public abstract void Visit(Circle shape);

        public abstract void Visit(Line shape);
    }
    //具体访问者 ConcreteVisitor
    public sealed class CustomVisitor : ShapeVisitor
    {
        //针对Rectangle对象
        public override void Visit(Rectangle shape)
        {
            Console.WriteLine("针对Rectangle新的操作！");
        }
        //针对Circle对象
        public override void Visit(Circle shape)
        {
            Console.WriteLine("针对Circle新的操作！");
        }
        //针对Line对象
        public override void Visit(Line shape)
        {
            Console.WriteLine("针对Line新的操作！");
        }
    }
    //矩形----相当于“具体节点角色” ConcreteElement
    public sealed class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("矩形我已经画好！");
        }

        public override void Accept(ShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    //圆形---相当于“具体节点角色”ConcreteElement
    public sealed class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("圆形我已经画好！");
        }

        public override void Accept(ShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
     //直线---相当于“具体节点角色” ConcreteElement
    public sealed class Line : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("直线我已经画好！");
        }

        public override void Accept(ShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
      //结构对象角色
    internal class AppStructure
    {
        private ShapeVisitor _visitor;

        public AppStructure(ShapeVisitor visitor)
        {
            this._visitor = visitor;
        }

        public void Process(Shape shape)
        {
            shape.Accept(_visitor);
        }
    }
}
