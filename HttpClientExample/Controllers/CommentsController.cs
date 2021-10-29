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
    public class CommentsController : ControllerBase
    {

        //private readonly IHttpClientFactory _httpClientFactory;

        //public CommentsController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        private readonly IJsonPlaceHolderProxy _jsonPlaceHolderProxy;
        public CommentsController(IJsonPlaceHolderProxy jsonPlaceHolderProxy)
        {
            _jsonPlaceHolderProxy = jsonPlaceHolderProxy;
        }

        [HttpGet]
        public async Task<IActionResult> GetHttpClient()
        {
            var comments = await _jsonPlaceHolderProxy.GetComments();
            return Ok(comments);
        }
    }
}
