using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.Web.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisExchangeAPI.Web.Controllers
{
    public class RedisListTypeController : Controller
    {

        private readonly RedisService _redisService;
        
        private readonly IDatabase db;

        private string ListKey = "names";

        public RedisListTypeController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb(1);
        }

        public IActionResult Index()
        {
           
            
            List<string> namelist = new List<string>();
            db.ListRange(ListKey, 0, -1).ToList().ForEach(x =>
            {
                namelist.Add(x.ToString());
            });



            return View(namelist);
        }

        [HttpPost]
        public IActionResult AddList(string name) 
        {
            db.ListLeftPush(ListKey, name);
            return RedirectToAction("Index");
        }

        //[HttpPost] // form kullanırsak 

        public IActionResult DeleteItem(string name) 
        {
            db.ListRemoveAsync(ListKey, name).Wait();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFirstItem() 
        {
            db.ListLeftPop(ListKey);
            return RedirectToAction("Index");
        }
    }
}
