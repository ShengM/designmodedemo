namespace designmodedemo.简单工厂模式
{
  public class ShapeFactory
  {
    public static Shape CreateShape(string type)
    {
      switch (type)
      {
        case "circle":
          return new Circle();
        case "square":
          return new Square();
        case "triangle":
          return new Triangle();
        default:
          throw new UnSupportedShapeException("不支持的形状类型");
      }
    }
  }
}
