using System;

namespace designmodedemo
{
  public static class Assert
  {
    public static void NotNull(Object obj, string name)
    {
      if (obj == null)
        throw new ArgumentException($"{name}不能为空");
    }

    public static void NotNullOrWhitespace(string value, string name)
    {
      if (string.IsNullOrWhiteSpace(value))
        throw new ArgumentException($"{name}不能为空或者空白字符串");
    }
  }
}
