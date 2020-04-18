using System;

namespace designmodedemo.状态模式
{
  public class Account
  {
    private string _owner;
    private StateBase _state;

    public double Balance { get; set; }

    public Account(string owner, double balance)
    {
      _owner = owner;
      this.Balance = balance;
      _state = new NormalState(this);
      Console.WriteLine($"{_owner}开户，初始金额为{this.Balance}");
      Console.WriteLine("----------------------------------");
    }

    public void SetState(StateBase state)
    {
      _state = state;
    }

    public void Deposit(double amount)
    {
      Console.WriteLine($"{_owner}存款{amount}");
      _state.Deposit(amount);
      Console.WriteLine($"当前账户余额：{this.Balance}");
      Console.WriteLine($"当前账户状态：{_state}");
      Console.WriteLine("-----------------------------");
    }

    public void Withdraw(double amount)
    {
      Console.WriteLine($"{_owner}取款{amount}");
      _state.Withdraw(amount);
      Console.WriteLine($"当前账户余额：{this.Balance}");
      Console.WriteLine($"当前账户状态：{_state}");
      Console.WriteLine("-----------------------------");
    }

    public void ComputeInterest()
    {
      _state.ComputeInterest();
    }
  }

  public abstract class StateBase
  {
    protected Account _acc;

    public StateBase(Account acc)
    {
      _acc = acc;
    }

    public abstract void Deposit(double amount);
    public abstract void Withdraw(double amount);
    public abstract void ComputeInterest();
    public abstract void CheckState();
  }

  public class NormalState : StateBase
  {
    public NormalState(Account acc)
      : base(acc)
    {
    }

    public override void CheckState()
    {
      var balance = _acc.Balance;
      if (balance > -2000 && balance <= 0)
      {
        _acc.SetState(new OverdraftState(_acc));
      }
      else if (balance == -2000)
      {
        _acc.SetState(new RestrictedState(_acc));
      }
      else if (balance < -2000)
      {
        Console.WriteLine("操作受限");
      }
    }

    public override void ComputeInterest()
    {
      Console.WriteLine("正常状态，无须支付利息");
    }

    public override void Deposit(double amount)
    {
      _acc.Balance += amount;
      this.CheckState();
    }

    public override void Withdraw(double amount)
    {
      _acc.Balance -= amount;
      this.CheckState();
    }

    public override string ToString()
    {
      return "正常状态";
    }
  }

  public class OverdraftState : StateBase
  {
    public OverdraftState(Account acc)
      : base(acc)
    {
    }

    public override void CheckState()
    {
      var balance = _acc.Balance;
      if (balance > 0)
      {
        _acc.SetState(new NormalState(_acc));
      }
      else if (balance == -2000)
      {
        _acc.SetState(new RestrictedState(_acc));
      }
      else if (balance < -2000)
      {
        Console.WriteLine("操作受限");
      }
    }

    public override void ComputeInterest()
    {
      Console.WriteLine("计算利息");
    }

    public override void Deposit(double amount)
    {
      _acc.Balance += amount;
      this.CheckState();
    }

    public override void Withdraw(double amount)
    {
      _acc.Balance -= amount;
      this.CheckState();
    }

    public override string ToString()
    {
      return "透支状态";
    }
  }

  public class RestrictedState : StateBase
  {
    public RestrictedState(Account acc)
      : base(acc)
    {
    }

    public override void CheckState()
    {
      var balance = _acc.Balance;
      if (balance > 0)
      {
        _acc.SetState(new NormalState(_acc));
      }
      else if (balance > -2000)
      {
        _acc.SetState(new OverdraftState(_acc));
      }
    }

    public override void ComputeInterest()
    {
      Console.WriteLine("计算利息");
    }

    public override void Deposit(double amount)
    {
      _acc.Balance += amount;
      this.CheckState();
    }

    public override void Withdraw(double amount)
    {
      Console.WriteLine("账户受限，取款失败");
    }

    public override string ToString()
    {
      return "受限状态";
    }
  }


}
