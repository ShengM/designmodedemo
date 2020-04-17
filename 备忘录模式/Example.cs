using System;
using System.Collections;

namespace designmodedemo.备忘录模式
{
  public class Chessman
  {
    public string Label { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public Chessman(string label, int x, int y)
    {
      this.Label = label;
      this.X = x;
      this.Y = y;
    }

    public ChessmanMemento Save()
    {
      return new ChessmanMemento(this.Label, this.X, this.Y);
    }

    public void Restore(ChessmanMemento m)
    {
      this.Label = m.Label;
      this.X = m.X;
      this.Y = m.Y;
    }

    public void Display()
    {
      Console.WriteLine($"棋子{this.Label}当前位置为：第{this.X}行第{this.Y}列");
    }
  }

  public class ChessmanMemento
  {
    public string Label { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public ChessmanMemento(string label, int x, int y)
    {
      this.Label = label;
      this.X = x;
      this.Y = y;
    }
  }

  public class MementoCaretaker
  {
    private const int MEMENTO_LENGTH = 5;
    private ChessmanMemento[] _mementos = new ChessmanMemento[MEMENTO_LENGTH];
    private int _caret = -1;

    public void AddMemento(ChessmanMemento m)
    {
      _caret++;
      if (_caret == MEMENTO_LENGTH)
      {
        _caret = 0;
      }

      _mementos[_caret] = m;
    }

    public ChessmanMemento Redo()
    {
      _caret++;
      if (_caret == MEMENTO_LENGTH)
      {
        return null;
      }

      return _mementos[_caret];
    }

    public ChessmanMemento Undo()
    {
      _caret--;
      if (_caret == -1)
      {
        return null;
      }

      return _mementos[_caret];
    }
  }
}
