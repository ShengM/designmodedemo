using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.工厂方法模式
{
  public abstract class ImageFileReaderFactory
  {
    public abstract ImageFileReader CreateImageFileReader();
  }
}
