using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eStoreClient.Pages.Inheritance
{
    public abstract class ClientAbstract: PageModel
    {
        private readonly IHttpClientFactory _http;
        public HttpClient HttpClient { get; }

        public ClientAbstract(IHttpClientFactory http)
        {
            _http = http;
            HttpClient = _http.CreateClient();
            HttpClient.BaseAddress = new Uri("https://localhost:7052/");
        }
    }
}
