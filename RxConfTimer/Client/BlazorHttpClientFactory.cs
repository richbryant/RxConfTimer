using System.Net.Http;
using Flurl.Http.Configuration;

namespace RxConfTimer.Client
{
    public class BlazorHttpClientFactory : DefaultHttpClientFactory
    {
        public override HttpClient CreateHttpClient(HttpMessageHandler handler) => new HttpClient();

        public override HttpMessageHandler CreateMessageHandler() => null;
    }
}