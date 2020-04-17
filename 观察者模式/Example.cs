using System;
using System.Collections.Generic;

namespace designmodedemo.观察者模式
{
  // 战场支援接口
  public interface IAskForSupport
  {
    // 请求支援
    void Ask(War war);

    // 发起支援
    void Support(Soldier soldier);
  }

  public class Soldier : IAskForSupport
  {
    public string Name { get; set; }

    public Soldier(string name)
    {
      this.Name = name;
    }

    public void Ask(War war)
    {
      Console.WriteLine($"{this.Name}正在呼叫支援");
      war.Notify(this);
    }

    public void Support(Soldier soldier)
    {
      Console.WriteLine($"{this.Name}正在前往支援{soldier.Name}");
    }
  }

  public class War
  {
    private List<Soldier> _soldiers = new List<Soldier>();

    public War Join(Soldier soldier)
    {
      _soldiers.Add(soldier);
      return this;
    }

    public void Notify(Soldier sender)
    {
      _soldiers.ForEach(s =>
      {
        if (s != sender)
        {
          s.Support(sender);
        }
      });
    }
  }
}
