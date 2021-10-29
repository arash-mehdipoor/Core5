using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientExample.Models
{
    public class ValidateApiKeyExists : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            if (!request.Headers.Contains("X-Api-Key"))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("You must supply an Api key header called X-Api-Key")
                };
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }

    public class AddApiKey : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            if (!request.Headers.Contains("X-Api-Key"))
            {
                request.Headers.Add("X-Api-Key", "apikey");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
