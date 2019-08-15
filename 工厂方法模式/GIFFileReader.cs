using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.工厂方法模式
{
  public class GIFFileReader : ImageFileReader
  {
    public override void Read()
    {
      Console.WriteLine("读取GIF图片");
    }
  }
}
