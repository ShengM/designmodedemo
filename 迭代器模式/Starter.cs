using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.迭代器模式
{
  class Starter : IStart
  {
    public void Run()
    {
      var l = new List<object>();
      l.Add("小米");
      l.Add("小明");
      l.Add("小红");
      var pl = new ProductList(l);
      var i = pl.CreateIterator();

      while (!i.IsLast())
      {
        Console.WriteLine(i.GetNextItem());
        i.Next();
      }

      while (!i.IsFirst())
      {
        Console.WriteLine(i.GetPreviousItem());
        i.Previous();
      }
    }
  }
}
