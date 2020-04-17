using System;

namespace designmodedemo.备忘录模式
{
  class Starter : IStart
  {
    public void Run()
    {
      var mc = new MementoCaretaker();
      var c = new Chessman("车", 1, 1);
      mc.AddMemento(c.Save());
      c.Display();

      c.X = 2;
      mc.AddMemento(c.Save());
      c.Display();

      c.Y = 2;
      mc.AddMemento(c.Save());
      c.Display();

      c.Restore(mc.Undo());
      c.Display();

      c.Restore(mc.Undo());
      c.Display();

      c.Restore(mc.Redo());
      c.Display();

      c.Restore(mc.Redo());
      c.Display();
    }
  }
}
