using System;

namespace designmodedemo.简单工厂模式
{
  public class Circle : Shape
  {
    public override void Draw()
    {
      Console.WriteLine("[Circle]绘制一个圆");
    }

    public override void Erase()
    {
      Console.WriteLine("[Circle]擦除一个圆");
    }
  }
}