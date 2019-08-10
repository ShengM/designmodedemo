using System;

namespace designmodedemo.简单工厂模式
{
  public class Triangle : Shape
  {
    public override void Draw()
    {
      Console.WriteLine("[Triangle]绘制一个三角形");
    }

    public override void Erase()
    {
      Console.WriteLine("[Triangle]擦除一个三角形");
    }
  }
}