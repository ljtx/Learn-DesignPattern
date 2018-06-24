using System;
using System.Collections.Generic;


namespace FlyWeightPattern
{
    class Program
    {
        
        static string[] colors = new string[]{ "Red", "Green", "Blue", "White", "Black" };
        static Random rnd = new Random();
        static string getRandomColor()
        {
             return colors[(int)(rnd.Next(1)*colors.Length)];
        }
        static int getRandomX()
        {
            return (int)(rnd.Next(3)*100 );
        }
         static int getRandomY()
        {
            return (int)(rnd.Next(3)*100 );
        }
        static void Main(string[] args)
        {
            for(int i=0; i < 2; ++i) {
         Circle circle = 
            (Circle)ShapeFactory.getCircle(getRandomColor());
         circle.x=getRandomX();
         circle.y=getRandomY();
         circle.radius=100;
         circle.draw();
        }
        
    }
    public interface Shape
    {
        void draw();
    }
    public class  Circle:Shape
    {
        private string color;
        public int x{get;set;}
        public int y{get;set;}
        public int radius{get;set;}

        public Circle(string color)
        {
            this.color = color;
        }
        public void draw()
        {
            Console.WriteLine(string.Format("Circle:Draw()[Color:{0},x:{1},y{2},radius{3}]",this.color,this.x,this.y,this.radius));
        }
    }
    public class ShapeFactory {
    private static Dictionary<string, Shape> circleMap = new Dictionary<string,Shape>();

    public static Shape getCircle(string color) {
        Shape circle=null;
        circleMap.TryGetValue(color,out circle);

      if(circle == null) {
         circle = new Circle(color);
         circleMap.Add(color,circle);
         Console.WriteLine("Creating circle of color : " + color);
      }
      return circle;
   }
}
    }
}

