using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.原型模式
{
  public class Student : ICloneable
  {
    public string Name { get; set; }

    public int Age { get; set; }

    public object Clone()
    {
      return this.MemberwiseClone();
    }

    public override string ToString()
    {
      return $"{this.Name}-{this.Age}";
    }
  }

  class Starter : IStart
  {
    public void Run()
    {
      var s = new Student();
      s.Name = "Jim";
      s.Age = 12;
      var t = s.Clone();
      Console.WriteLine(s);
      Console.WriteLine(t);
    }
  }
}
