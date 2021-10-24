using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisExchangeAPI.Web.Services
{
    public class RedisService
    {
        private readonly string _redisHost;
        private readonly string _redisPort;
        public IDatabase db { get; set; } // veritabanı üzerinde çalışmak için 
        private ConnectionMultiplexer _redis; // redis ile iletişim saglamak için

        public RedisService(IConfiguration configuration)
        {
            _redisHost = configuration["Redis:Host"];
            _redisPort = configuration["Redis:Port"];
        }

        public void Connect() 
        {
            string connectionString = $"{_redisHost}:{_redisPort}";
            _redis = ConnectionMultiplexer.Connect(connectionString);
            
        }

        public IDatabase GetDb(int number = 0) 
        {
            return _redis.GetDatabase(number);
        }
        

    }
}
