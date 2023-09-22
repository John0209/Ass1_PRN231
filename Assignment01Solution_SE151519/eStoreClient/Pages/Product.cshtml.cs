using DataAccess.Models;
using DataAccess.RequestModel;
using DataAccess.ResponeModel;
using eStoreClient.Pages.Inheritance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace eStoreClient.Pages
{
    public class ProductModel : ClientAbstract
    {
        public ProductModel(IHttpClientFactory http) : base(http)
        {
        }

        [BindProperty]
        public List<ProductRespone> Products { get; set; } = default!;
        [BindProperty]
        public string search { get; set; }
        public async Task OnGetAsync()
        {
            // Gọi API endpoint từ dự án API.
            HttpResponseMessage response = await HttpClient.GetAsync("api/product/Get-All");
            if(response.IsSuccessStatusCode)
            {
                var content= await response.Content.ReadAsStringAsync();

                Products = JsonConvert.DeserializeObject<List<ProductRespone>>(content);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string url = $"api/product/Search?serachs={search}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                Products = JsonConvert.DeserializeObject< List<ProductRespone>>(content);
                return Page();
            }
            ViewData["Message"] = $"{search} don't exits!";
            return Page();
        }
    }
}
