using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.RequestModel;
using eStoreClient.Pages.Inheritance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MovieManagement_NguyenTuanVu.Pages
{
    public class DeleteModel : ClientAbstract
    {

        public DeleteModel(IHttpClientFactory http) : base(http)
        {
        }

        [BindProperty]
        public ProductRequest productRequest { get; set; } = default!;
        public async Task OnGetAsync(int? id)
        {
            string url = $"api/product/Get-By-Id?id={id}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                productRequest = JsonConvert.DeserializeObject<ProductRequest>(content);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string url = $"api/product/Delete?id={productRequest.ProductId}";
            HttpResponseMessage response = await HttpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Product");
            }
            else
            {
                ViewData["Message"] = "Delete Fail!";
                return Page();
            }
         }
    }
}
