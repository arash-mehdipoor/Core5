using HttpClientExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetHttpClient()
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            var isSuccess = result.IsSuccessStatusCode;
            if (isSuccess)
            {
                var stringValue = await result.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<List<Post>>(stringValue);
                return Ok(posts);
            }
            return StatusCode(404);
        }
    }
}
