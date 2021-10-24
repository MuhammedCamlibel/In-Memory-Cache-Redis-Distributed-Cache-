using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.Web.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisExchangeAPI.Web.Controllers
{
    public class RedisSetTypeController : Controller
    {
        private readonly RedisService _redisService;

        private readonly IDatabase db;

        private string key = "setnames";

        public RedisSetTypeController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb(2);
        }

        public IActionResult Index()
        {
            HashSet<string> names = new HashSet<string>();
            if (db.KeyExists(key)) 
            {
                db.SetMembers(key).ToList().ForEach(x =>
                {
                    names.Add(x.ToString()); 
                });
            }
            return View(names);
        }

        public IActionResult Add(string name) 
        {

            if (!db.KeyExists(key)) 
            {
                db.KeyExpire(key, DateTime.Now.AddMinutes(3));
            }
            
            db.SetAdd(key, name);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(string name) 
        {
            db.SetRemove(key, name);    
            return RedirectToAction("Index");
        }
    }
}
