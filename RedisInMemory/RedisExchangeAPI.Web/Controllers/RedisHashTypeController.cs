using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.Web.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisExchangeAPI.Web.Controllers
{
    public class RedisHashTypeController : BaseController
    {

        private string hashkey = "hashkey";

        public RedisHashTypeController(RedisService redisService):base(redisService,4)
        {
            
        }

        public IActionResult Index()
        {

            Dictionary<string, string> hashlist = new Dictionary<string, string>();

            db.HashGetAll(hashkey).ToList().ForEach(x =>
            {
                hashlist.Add(x.Name, x.Value);
            });

            return View(hashlist);
        }

        [HttpPost]
        public IActionResult Add(string name, string value) 
        {

            db.HashSet(hashkey, name, value);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(string name) 
        {
            db.HashDelete(hashkey, name);

            return RedirectToAction("Index");
        }


    }
}
