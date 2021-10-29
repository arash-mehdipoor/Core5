using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientExample.Models
{
    public class JsonPlaceHolderProxy : IJsonPlaceHolderProxy
    {
        private readonly HttpClient _httpClient;

        public JsonPlaceHolderProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        public async Task<List<Comment>> GetComments()
        {
            var result = await _httpClient.GetAsync("comments");
            var isSuccess = result.IsSuccessStatusCode;
            var stringValue = await result.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<Comment>>(stringValue);
            return comments;
        }

        public Task<List<Post>> GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}
