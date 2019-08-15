namespace designmodedemo.简单工厂模式
{
  public class Starter : IStart
  {
    public void Run()
    {
      var shape1 = ShapeFactory.CreateShape("circle");
      var shape2 = ShapeFactory.CreateShape("square");
      var shape3 = ShapeFactory.CreateShape("triangle");

      shape1.Draw();
      shape2.Draw();
      shape3.Draw();

      shape3.Erase();
      shape2.Erase();
      shape1.Erase();

      var type = JsonConfigParser.Parse("简单工厂模式/config.json", "shapeType");
      var shape4 = ShapeFactory.CreateShape(type);
      shape4.Draw();
      shape4.Erase();
    }
  }
}