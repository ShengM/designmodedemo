using System;
using System.Collections.Generic;
using System.Text;

namespace designmodedemo.享元模式
{
  abstract class MediaObject
  {
    public String Name { get; set; }

    public abstract void Add(String position, String size);
  }

  class Picture : MediaObject
  {
    public override void Add(string position, string size)
    {
      Console.WriteLine($"添加尺寸为{size}图片到{position}");
    }
  }

  class Video : MediaObject
  {
    public override void Add(string position, string size)
    {
      Console.WriteLine($"添加尺寸为{size}视频到{position}");
    }
  }

  class MediaFactory
  {
    private static readonly MediaFactory _instance = new MediaFactory();
    private readonly Dictionary<string, MediaObject> _medias = new Dictionary<string, MediaObject>();

    private MediaFactory()
    {
    }

    public static MediaFactory GetInstance()
    {
      return _instance;
    }

    public MediaObject GetMediaObject(string key)
    {
      if (_medias.ContainsKey(key))
      {
        return _medias[key];
      }
      return null;
    }

    public void SetMediaObject(String key, MediaObject m)
    {
      _medias[key] = m;
    }
  }

  class Starter : IStart
  {
    public void Run()
    {
      var mediaFactory = MediaFactory.GetInstance();
      mediaFactory.SetMediaObject("1", new Picture { Name = "图片1" });
      mediaFactory.SetMediaObject("2", new Video { Name = "视频1" });

      var m = mediaFactory.GetMediaObject("1");
      m.Add("底部", "正常");

      var n = mediaFactory.GetMediaObject("2");
      n.Add("中间", "2倍");
    }
  }
}
