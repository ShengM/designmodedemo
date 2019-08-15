namespace designmodedemo.工厂方法模式
{
  public class GIFFileReaderFactory : ImageFileReaderFactory
  {
    public override ImageFileReader CreateImageFileReader()
    {
      return new GIFFileReader();
    }
  }
}
