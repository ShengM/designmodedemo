using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.桥接模式
{
  abstract class DataConverterBase
  {
    public IDatabaseReader DatabaseReader { get; set; }

    public abstract void Convert();
  }

  class TxtConverter : DataConverterBase
  {
    public override void Convert()
    {
      this.DatabaseReader.Read();
      Console.WriteLine("转换为TXT");
    }
  }

  class PDFConverter : DataConverterBase
  {
    public override void Convert()
    {
      this.DatabaseReader.Read();
      Console.WriteLine("转换为PDF");
    }
  }

  class XMLConverter : DataConverterBase
  {
    public override void Convert()
    {
      this.DatabaseReader.Read();
      Console.WriteLine("转换为XML");
    }
  }

  public class MySQLReader : IDatabaseReader
  {
    public void Read()
    {
      Console.WriteLine("读取MySQL");
    }
  }

  public class AccessReader : IDatabaseReader
  {
    public void Read()
    {
      Console.WriteLine("读取Access");
    }
  }

  interface IDatabaseReader
  {
    void Read();
  }

  class Starter : IStart
  {
    public void Run()
    {
      var reader = new AccessReader();
      DataConverterBase converter = new TxtConverter();
      converter.DatabaseReader = reader;
      converter.Convert();

      converter = new PDFConverter();
      converter.DatabaseReader = reader;
      converter.Convert();
    }
  }
}
