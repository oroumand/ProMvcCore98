using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;

namespace Session22.RedisTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RedisClient client = new RedisClient())
            {
                for (int i = 0; i < 5000; i++)
                {
                    client.Set<string>("mykeycode:"+i, i.ToString());
                }
             
            }
            Console.WriteLine("Hello World!");
        }
    }
}
