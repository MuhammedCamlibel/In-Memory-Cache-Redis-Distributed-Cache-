using InMemoryApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace InMemoryApp.Web.Controllers
{

    public class Person 
    {
        public string Name { get; set; }
        public int BornYear { get; set; }

    }

    public class ProductController : Controller
    {

        private readonly IMemoryCache _memoryCache;

        public ProductController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            // 1.yol
            /*if (String.IsNullOrEmpty(_memoryCache.Get<string>("zaman")))
            {
                _memoryCache.Set<string>("zaman", DateTime.Now.ToString());
            }*/

            // 2.yol

            if (!_memoryCache.TryGetValue("zaman",out string zamancache)) 
            {
                MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();

                options.AbsoluteExpiration = DateTime.Now.AddSeconds(15); // verinin en fazla bu süre sonunda silinecek
             //   options.SlidingExpiration = TimeSpan.FromSeconds(10); // veriye her ulaşıldığında verilen süre kadar ulaşma süresi artacak (AbsoluteExpiration belirtilmişse en fazla o belirtilen süreye kadar veri memory de durur)
                options.Priority = CacheItemPriority.High;
                #region Priority
                /*
                 * Eğer priority degerlerinden(low,normal,high,neverremove) neverremove harici olaranı seçercek bize memory dolsa dahi hata fırlatmaz ve verdimiz priority degerlerinden 
                 * en az önemliden en önemliye şeklinde silmeye başlar 
                 * ancak neverremove olarak hepsini işaretlersek memory dolduğunda hiçbirini silemeyeceğinden bize hata fırlatır
                 */
                #endregion
                options.RegisterPostEvictionCallback((key,value,reason,state) =>  // eğer cache silinirse bu method çalışır 
                {
                    _memoryCache.Set("callback", $" {key}->{value} => sebep: {reason} ");
                });
                _memoryCache.Set<string>("zaman", DateTime.Now.ToString(),options);

                var p = new Product() { Id=1,Name="Çorap",Price=15.55};
                _memoryCache.Set<Product>("product", p);
                List<Person> people = new List<Person>();
                people.Add(new Person { Name = "Muhammed", BornYear = 1998 });
                people.Add(new Person { Name = "Elif", BornYear = 1998 });

                _memoryCache.Set<List<Person>>("list", people);

            }

           

           

            // memory de varsa zamancache ile yakalarız

            // varsa bakar yoksa yaratır
            /* _memoryCache.GetOrCreate<string>("zaman", entry => 
             {
                 // entry ile özelliklerini verebiliriz (priority,expire gibi)
                 return DateTime.Now.ToString();
             });*/

            // silmek için 
            // _memoryCache.Remove("zaman");

            return View();
        }

        public IActionResult SetCache() 
        {

            var Person = new Person() {  BornYear=1998,Name="Muhammed" };

            var p = JsonSerializer.Serialize(Person);

            _memoryCache.Set<string>("person", p);
            


            return View();
        }

        public IActionResult GetCache() 
        {
            ViewBag.person = JsonSerializer.Deserialize<Person>(_memoryCache.Get<string>("person"));
            return View();
        }

        public IActionResult Show() 
        {
            if (!String.IsNullOrEmpty(_memoryCache.Get<string>("zaman"))) 
            {
                ViewBag.zaman = _memoryCache.Get<string>("zaman");
            }
            else 
            {
                ViewBag.zaman = "Cache ömrü dolmuş";
            }

            ViewBag.callback = _memoryCache.Get("callback");
            ViewBag.product = _memoryCache.Get<Product>("product");
            ViewBag.List = _memoryCache.Get<List<Person>>("list");



            return View();
        }
    }
}
