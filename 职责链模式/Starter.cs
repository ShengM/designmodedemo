using System;

namespace designmodedemo.职责链模式
{
  abstract class Approver
  {
    protected Approver _nextApprover;

    public void SetNextApprover(Approver nextApprover)
    {
      this._nextApprover = nextApprover;
    }

    public abstract void HandleAskForLeave(string name, int days);
  }

  class Director : Approver
  {
    public override void HandleAskForLeave(string name, int days)
    {
      if (days < 3)
      {
        Console.WriteLine($"主任已经批准{name}的{days}天假期");
      }
      else
      {
        this._nextApprover.HandleAskForLeave(name, days);
      }
    }
  }

  class Manager : Approver
  {
    public override void HandleAskForLeave(string name, int days)
    {
      if (days >= 3 && days < 10)
      {
        Console.WriteLine($"经理已经批准{name}的{days}天假期");
      }
      else
      {
        this._nextApprover.HandleAskForLeave(name, days);
      }
    }
  }

  class GeneralManager : Approver
  {
    public override void HandleAskForLeave(string name, int days)
    {
      if (days >= 10 && days < 30)
      {
        Console.WriteLine($"总经理已经批准{name}的{days}天假期");
      }
      else
      {
        Console.WriteLine($"{days}天假期时间过长，拒绝申请");
      }
    }
  }

  class Starter : IStart
  {
    public void Run()
    {
      var director = new Director();
      var manager = new Manager();
      var gManager = new GeneralManager();
      director.SetNextApprover(manager);
      manager.SetNextApprover(gManager);

      director.HandleAskForLeave("小明", 2);
      director.HandleAskForLeave("小红", 5);
      director.HandleAskForLeave("小丽", 15);
      director.HandleAskForLeave("小二", 100);
    }
  }
}
