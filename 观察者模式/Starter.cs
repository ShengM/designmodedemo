using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.观察者模式
{
  public class Starter : IStart
  {
    public void Run()
    {
      var war = new War();
      var s1 = new Soldier("许三多");
      var s2 = new Soldier("吴哲");
      var s3 = new Soldier("史今");
      var s4 = new Soldier("伍六一");

      war.Join(s1).Join(s2).Join(s3).Join(s4);

      s1.Ask(war);
    }
  }
}
