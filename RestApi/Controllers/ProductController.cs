using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductApiDbContext _dbContext;

        public ProductController(ProductApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<ProductController>
        [HttpGet]
        //[Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            var products = await _dbContext.Products.Include(c => c.Category).Include(c => c.Supplier).ToListAsync();
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        //[HttpGet("{id}")]
        [HttpGet("{id}.{format?}")]
        [FormatFilter]
        [Produces("application/xml", "application/json")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post(ProductForSave product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product.ToProduct());
                _dbContext.SaveChanges();
            }
            return Ok();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
