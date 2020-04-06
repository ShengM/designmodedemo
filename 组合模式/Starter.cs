using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.组合模式
{
  abstract class Control
  {
    public abstract void Paint();

    public virtual void Add(Control c)
    {
      throw new NotSupportedException();
    }

    public virtual void Remove(Control c)
    {
      throw new NotSupportedException();
    }

    public virtual Control GetChild(int i)
    {
      throw new NotSupportedException();
    }
  }

  class Container : Control
  {
    protected List<Control> _children = new List<Control>();

    public override void Add(Control c)
    {
      _children.Add(c);
    }

    public override void Remove(Control c)
    {
      _children.Remove(c);
    }

    public override Control GetChild(int i)
    {
      return _children[i];
    }

    public override void Paint()
    {
      Console.WriteLine("这是一个容器");
      _children.ForEach(child => child.Paint());
    }
  }

  class Button : Control
  {
    public override void Paint()
    {
      Console.WriteLine("这是一个按钮");
    }
  }

  class Text : Control
  {
    public override void Paint()
    {
      Console.WriteLine("这是一个文本");
    }
  }

  class Starter : IStart
  {
    public void Run()
    {
      var c = new Container();
      c.Add(new Button());
      c.Add(new Text());
      var c1 = new Container();
      c1.Add(new Button());
      c1.Add(new Text());
      c.Add(c1);
      c.Paint();
    }
  }
}
