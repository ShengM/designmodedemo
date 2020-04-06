using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.装饰模式
{
  abstract class Decryptor
  {
    public abstract void Decrypt();
  }

  class SimpleDecryptor : Decryptor
  {
    public override void Decrypt()
    {
      Console.WriteLine("简单加密");
    }
  }

  class ComplexDecryptor : Decryptor
  {
    public override void Decrypt()
    {
      Console.WriteLine("复杂加密");
    }
  }

  class AddedDecryptor : Decryptor
  {
    protected Decryptor _decryptor;

    public AddedDecryptor(Decryptor d)
    {
      _decryptor = d;
    }

    public override void Decrypt()
    {
      _decryptor.Decrypt();
    }
  }

  class AddedDecryptorA : AddedDecryptor
  {
    public AddedDecryptorA(Decryptor d)
      : base(d)
    {
    }

    public override void Decrypt()
    {
      base.Decrypt();

      Console.WriteLine("新增加密方式A");
    }
  }

  class Starter : IStart
  {
    public void Run()
    {
      Decryptor d = new AddedDecryptorA(new SimpleDecryptor());
      d.Decrypt();
    }
  }
}
