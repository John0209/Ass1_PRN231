using DataAccess.ResponeModel;
using eStoreClient.Pages.Inheritance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace eStoreClient.Pages
{
    public class OrderModel : ClientAbstract
    {
        public OrderModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }

        [BindProperty]
        public List<OrderRespone> Orders { get; set; } = default!;
        [BindProperty]
        public string search { get; set; }
        public async Task OnGetAsync()
        {
            // Gọi API endpoint từ dự án API.
            HttpResponseMessage response = await HttpClient.GetAsync("api/order/Get-All");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                Orders = JsonConvert.DeserializeObject<List<OrderRespone>>(content);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string url = $"api/order/Search?serachs={search}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                Orders = JsonConvert.DeserializeObject<List<OrderRespone>>(content);
                return Page();
            }
            ViewData["Message"] = $"{search} don't exits!";
            return Page();
        }
    }
}
