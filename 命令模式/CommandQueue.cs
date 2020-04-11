using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.命令模式
{
  public abstract class Command
  {
    public abstract void Execute(int value);
    public abstract void Undo();
  }

  class CommandQueue
  {
    private List<Command> _commands = new List<Command>();

    public void AddCommand(Command command)
    {
      _commands.Add(command);
    }

    public void RemoveCommand(Command command)
    {
      _commands.Remove(command);
    }

    public void Execute(int value)
    {
      _commands.ForEach(command => command.Execute(value));
    }
  }

  class Invoker
  {
    private CommandQueue _commandQueue;

    public Invoker(CommandQueue commandQueue)
    {
      _commandQueue = commandQueue;
    }

    public void SetCommandQueue(CommandQueue commandQueue)
    {
      _commandQueue = commandQueue;
    }

    public void Call(int value)
    {
      _commandQueue.Execute(value);
    }
  }
}
