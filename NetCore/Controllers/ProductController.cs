using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Controllers
{
    [Route("product.html")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("{alias}-c.{id}.html")]
        public IActionResult catalog(int id, string keyword,int?pageSize, string sortBy,int page=1)
        {
            return View();
        }
    }
   
}