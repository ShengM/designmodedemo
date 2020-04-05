using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.适配器模式
{
  interface IEncrypt
  {
    String Encrypt(String originalInfomation);
  }

  class Encrypt
  {
    public String Reverse(String msg)
    {
      var msgChars = msg.ToCharArray();
      Array.Reverse(msgChars);
      return String.Join("", msgChars);
    }
  }

  class EncryptAdapter : IEncrypt
  {
    private Encrypt _encryptor = new Encrypt();

    public string Encrypt(string originalInfomation)
    {
      return _encryptor.Reverse(originalInfomation);
    }
  }

  class Starter : IStart
  {
    public void Run()
    {
      var encryptor = new EncryptAdapter();
      var encryptedMsg = encryptor.Encrypt("name:Jim,mail:jim@163.com");
      Console.WriteLine(encryptedMsg);
    }
  }
}
