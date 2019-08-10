using System;
using Microsoft.Extensions.Configuration;

namespace designmodedemo
{
    public static class JsonConfigParser
    {
        public static string Parse(string path, string key)
        {
            try
            {
                var configBuilder = new ConfigurationBuilder();
                var config = configBuilder.AddJsonFile(path).Build();
                return config.GetSection(key).Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[JsonConfigParser]解析配置失败，path:{path}, key:{key}");
                throw ex;
            }
        }
    }
}
