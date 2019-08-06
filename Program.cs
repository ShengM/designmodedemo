using System;
using Microsoft.Extensions.Configuration;

namespace designmodedemo
{
    class Program
  {
    static void Main(string[] args)
    {
      var configBuilder = new ConfigurationBuilder();
      var config = configBuilder.AddJsonFile("config.json").Build();

      var section0 = config.GetSection("section0");
      var value0 = section0["key0"];
      var value1 = section0["key1"];
      var value3 = config.GetSection("section2:subsection0:key0");

      Console.ReadLine();
    }
  }
}
