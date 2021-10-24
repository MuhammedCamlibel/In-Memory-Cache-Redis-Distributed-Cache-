using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.Web.Models;
using RedisExchangeAPI.Web.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedisExchangeAPI.Web.Controllers
{
    public class RedisStringTypeController : Controller
    {
        private readonly RedisService _redisService;
        private readonly IDatabase db;

        public RedisStringTypeController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb();
        }

        public IActionResult Index()
        {
            
            db.StringSet("name", "Muhammed Camlibel",TimeSpan.FromSeconds(30));
            db.StringSet("ziyaretci", 100);
            db.StringSet("deneme", "deneme");
            return View();
        }

        

        public async Task<IActionResult> Show() 
        {
            // db.StringIncrement("ziyaretci", 1);
            await db.StringDecrementAsync("ziyaretci", 1);
            /*
            var count = db.StringDecrementAsync("ziyaretci", 1).Result; // degeri alırız
            db.StringDecrementAsync("ziyaretci", 1).Wait(); // degeri düşürür ve asekron çalışır (task async kullanmamıza gerek kalmaz) 
            */
            var value = db.StringGet("ziyaretci");
            var value1 = db.StringGetRange("deneme", 0, 1);
            var value2 = db.StringLength("deneme"); 

            if (value.HasValue) 
            {
                ViewBag.value = value;
            }

            return View("Index");
        }

        public IActionResult InsertPerson()
        {
            var person = new Person { Name = "Muhammed", Surname = "Camlibel" };
            var JsonPerson = JsonSerializer.Serialize(person);

            db.StringSet("person", JsonPerson);

            return View("Index");
        }

        public IActionResult GetPerson()
        {
            var JsonPerson = db.StringGet("person");
            var person = JsonSerializer.Deserialize<Person>(JsonPerson);
            ViewBag.person = person;

            return View("Index");
        }

    }
}
