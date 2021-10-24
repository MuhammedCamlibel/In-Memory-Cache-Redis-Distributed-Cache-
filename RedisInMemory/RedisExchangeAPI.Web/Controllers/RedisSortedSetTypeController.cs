using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.Web.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisExchangeAPI.Web.Controllers
{
    public class RedisSortedSetTypeController : Controller
    {

        private readonly RedisService _redisService;

        private readonly IDatabase db;

        private string key = "sortedset";

        public RedisSortedSetTypeController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb(3);
        }

        public IActionResult Index()
        {

            HashSet<string> list = new HashSet<string>();

            if (db.KeyExists(key)) 
            {
                /*db.SortedSetScan(key).ToList().ForEach(x =>
                {
                    list.Add(x.ToString());
                });*/

                db.SortedSetRangeByRank(key, order: Order.Descending).ToList().ForEach(x =>
                  {
                      list.Add(x.ToString());
                  });

            }


            return View(list);
        }

        [HttpPost]
        public IActionResult Add(string name , int score) 
        {
            
            db.SortedSetAdd(key, name, score);
            db.KeyExpire(key, DateTime.Now.AddMinutes(3));

            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(string name) 
        {
            /*string[] a =  name.Split(":");
            db.SortedSetRemove(key, a[0]);*/
            db.SortedSetRemove(key,name);
            return RedirectToAction("Index");
        }
    }
}
