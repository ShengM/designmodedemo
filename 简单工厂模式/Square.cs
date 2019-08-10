using System;

namespace designmodedemo.简单工厂模式
{
  public class Square : Shape
  {
    public override void Draw()
    {
      Console.WriteLine("[Square]绘制一个正方形");
    }

    public override void Erase()
    {
      Console.WriteLine("[Square]擦除一个正方形");
    }
  }
}