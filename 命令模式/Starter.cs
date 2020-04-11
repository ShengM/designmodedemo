using System;

namespace designmodedemo.命令模式
{
public class AddCommand : Command
{
  private readonly Adder _adder = new Adder();
  private int _lastValue = 0;

  public override void Execute(int value)
  {
    var result = _adder.Add(value);
    _lastValue = value;
    Console.WriteLine("Add Result: {0}", result);
  }

  public override void Undo()
  {
    var result = _adder.Add(-_lastValue);
    Console.WriteLine("Undo Result: {0}", result);
  }
}

public class Adder
{
  private int _sum = 0;

  public int Add(int num)
  {
    _sum += num;
    return _sum;
  }
}

class Starter : IStart
{
  public void Run()
  {
    var c = new AddCommand();
    c.Execute(1);
    c.Undo();
    c.Execute(10);
    c.Execute(15);
  }
}
}

