using System;

namespace designmodedemo.工厂方法模式
{
  public class PNGFileReader : ImageFileReader
  {
    public override void Read()
    {
      Console.WriteLine("读取PNG图片");
    }
  }
}
