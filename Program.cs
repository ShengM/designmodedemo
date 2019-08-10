using System;

namespace designmodedemo
{
  class Program
  {
    static void Main(string[] args)
    {
      Start();

      Console.ReadLine();
    }

    public static void Start()
    {
      var startup = JsonConfigParser.Parse("config.json", "startup");
      if (string.IsNullOrWhiteSpace(startup))
      {
        Console.WriteLine("[Start]: 没有配置启动示例");
        return;
      }

      IStart starter;

      try
      {
        var exampleStarter = Type.GetType($"designmodedemo.{startup}.Starter");
        starter = Activator.CreateInstance(exampleStarter) as IStart;
        if (starter == null)
        {
          Console.WriteLine("[Start]: 示例启动器未实现IStart接口");
          return;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("[Start]: 获取示例启动器异常");
        throw ex;
      }

      try
      {
        starter.run();
      }
      catch (Exception ex)
      {
        Console.WriteLine("[Start]: 示例执行异常");
        throw ex;
      }
    }
  }
}
