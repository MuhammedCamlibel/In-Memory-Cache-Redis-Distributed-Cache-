using IDistributedCacheRedisApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IDistributedCacheRedisApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private IDistributedCache _distributedCache;


        public ProductsController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;

        }

        public IActionResult Index()
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.AbsoluteExpiration = DateTime.Now.AddMinutes(1);
            _distributedCache.SetString("name", "Muhammed", options);
            return View();
        }

        public IActionResult GetCache() 
        {
            ViewBag.Name = _distributedCache.GetString("name");
             
            return View();
        }

        public IActionResult DeleteCache() 
        {
            _distributedCache.Remove("name");
            return Ok(new { title = "cache silindi" });
        }

        public async Task<IActionResult>InsertProduct() 
        {
            var product = new Product { Id = 1, Name = "Pc", Price = 10000 };

            var jsonProduct = JsonSerializer.Serialize(product);

            DistributedCacheEntryOptions opt = new DistributedCacheEntryOptions();
            opt.AbsoluteExpiration = DateTime.Now.AddMinutes(2);

            // 1.yol json
            /*await _distributedCache.SetStringAsync("product:1", jsonProduct, opt);*/

            // 2.yol byte 

            Byte[] byteproduct = Encoding.UTF8.GetBytes(jsonProduct);

            await _distributedCache.SetAsync("product:2", byteproduct);

            return View();
        }

        public async Task<IActionResult> GetProduct() 
        {
            // json
            /*var jsonProduct = await _distributedCache.GetStringAsync("product:1");
            var product = JsonSerializer.Deserialize<Product>(jsonProduct);*/


            // byte 
            var byteProduct = await _distributedCache.GetAsync("product:2");
            var jsonProduct = Encoding.UTF8.GetString(byteProduct);
            var product1 = JsonSerializer.Deserialize<Product>(jsonProduct);

            return Ok(product1);

        }

        public IActionResult SetImageCache() 
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/clouds.jpg");

            byte[] imageByte = System.IO.File.ReadAllBytes(path);
            _distributedCache.Set("image",imageByte);

            return View();
        }

        public IActionResult GetImageCache() 
        {
            var imageByte = _distributedCache.Get("image");
            return File(imageByte,"image/jpg");
        }
    }
}
