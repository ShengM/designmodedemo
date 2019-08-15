namespace designmodedemo.工厂方法模式
{
  public class PNGFileReaderFactory : ImageFileReaderFactory
  {
    public override ImageFileReader CreateImageFileReader()
    {
      return new PNGFileReader();
    }
  }
}
