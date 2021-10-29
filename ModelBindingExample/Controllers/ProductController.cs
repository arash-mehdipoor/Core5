using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBindingExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingExample.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddProduct([Bind("Name")] Product product)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddProduct([FromRoute] int id=1)
        //{
        //    return View();
        //}

        //public IActionResult AddProduct([FromQuery] int id = 1)
        //{
        //    return View();
        //}

        //public IActionResult AddProduct([FromHeader] string Accept)
        //{
        //    return View();
        //}

        //public IActionResult AddProduct([FromBody] string Api)
        //{
        //    return View();
        //}

        //public IActionResult AddProduct(IFormFile formFile)
        //{
        //    return View();
        //}

        //public async Task<IActionResult> AddProduct()
        //{
        //    var product = new Product();
        //    await TryUpdateModelAsync<Product>(product);
        //    return View();
        //}
    }
}
