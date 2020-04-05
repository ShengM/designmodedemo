using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.单例模式
{
  public class Singleton
  {
    private static readonly Singleton _instance = new Singleton();

    private Singleton()
    {
    }

    public static Singleton GetInstance()
    {
      return _instance;
    }
  }

  public class Singleton2
  {
    private static Singleton2 _instance;
    private static Object _obj = new Object();

    private Singleton2()
    {
    }

    public static Singleton2 GetInstance()
    {
      if (_instance == null)
      {
        lock (_obj)
        {
          if (_instance == null)
          {
            _instance = new Singleton2();
          }
        }

      }

      return _instance;
    }
  }

public class Singleton3
{
  private Singleton3()
  {
  }

  private class Singleton3Hold
  {
    internal static readonly Singleton3 Instance = new Singleton3();
  }

  public static Singleton3 GetInstance()
  {
    return Singleton3Hold.Instance;
  }
}

  class Starter : IStart
  {
    public void Run()
    {
      var instance1 = Singleton3.GetInstance();
      var instance2 = Singleton3.GetInstance();
      Console.WriteLine(instance1 == instance2);
      Console.ReadLine();
    }
  }
}
