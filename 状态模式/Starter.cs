using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.状态模式
{
  class Starter : IStart
  {
    public void Run()
    {
      var acc = new Account("段誉", 0.0);
      acc.Deposit(1000);
      acc.Withdraw(2000);
      acc.Deposit(3000);
      acc.Withdraw(4000);
      acc.Withdraw(1000);
      acc.ComputeInterest();
    }
  }
}
