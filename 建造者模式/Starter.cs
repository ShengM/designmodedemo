using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.建造者模式
{
  class Product
  {
    public String Name { get; set; }
    public String Category { get; set; }
    public double Price { get; set; }
    public override string ToString()
    {
      return $"{this.Category}:{this.Name}-{this.Price}";
    }
  }

  abstract class BuilderBase
  {
    protected Product _product = new Product();
    public abstract void BuildName();
    public abstract void BuildCategory();
    public abstract void BuildPrice();
    public Product GetProduct()
    {
      return _product;
    }
  }

  class FruitBuilder : BuilderBase
  {
    public override void BuildCategory()
    {
      _product.Category = "水果";
    }

    public override void BuildName()
    {
      _product.Name = "苹果";
    }

    public override void BuildPrice()
    {
      _product.Price = 10;
    }
  }

  class ToyBuilder : BuilderBase
  {
    public override void BuildCategory()
    {
      _product.Category = "玩具";
    }

    public override void BuildName()
    {
      _product.Name = "变形金刚";
    }

    public override void BuildPrice()
    {
      _product.Price = 50;
    }
  }

  class Director
  {
    public Product CreateProduct(BuilderBase builder)
    {
      builder.BuildCategory();
      builder.BuildName();
      builder.BuildPrice();
      return builder.GetProduct();
    }
  }

  class Starter : IStart
  {
    public void Run()
    {
      var d = new Director();
      var toyBuilder = new ToyBuilder();
      var appleBuilder = new FruitBuilder();
      var toy = d.CreateProduct(toyBuilder);
      var apple = d.CreateProduct(appleBuilder);
      Console.WriteLine(toy);
      Console.WriteLine(apple);
    }
  }
}
