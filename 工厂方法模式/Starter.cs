using System;

namespace designmodedemo.工厂方法模式
{
  public class Starter : IStart
  {
    public void Run()
    {
      var typeStr = JsonConfigParser.Parse("工厂方法模式/config.json", "imageFileReaderFactoryType");
      Assert.NotNullOrWhitespace(typeStr, "imageFileReaderFactoryType");

      var type = Type.GetType($"designmodedemo.工厂方法模式.{typeStr}");
      Assert.NotNull(type, "工厂类型");

      var imageFileReaderFactory = Activator.CreateInstance(type) as ImageFileReaderFactory;
      Assert.NotNull(imageFileReaderFactory, "工厂对象");

      var imageFileReader = imageFileReaderFactory.CreateImageFileReader();
      imageFileReader.Read();
    }
  }
}
