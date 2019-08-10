using System;

namespace designmodedemo.简单工厂模式
{
  public class UnSupportedShapeException : Exception
  {
    public UnSupportedShapeException(string msg)
      : base(msg)
    {
    }
  }
}
