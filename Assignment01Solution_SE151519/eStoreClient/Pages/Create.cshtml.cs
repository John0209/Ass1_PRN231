using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.RequestModel;
using DataAccess.ResponeModel;
using eStoreClient.Pages.Inheritance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MovieManagement_NguyenTuanVu.Pages
{
    public class CreateModel : ClientAbstract
    {
		public CreateModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
		{
		}

		[BindProperty]
        public ProductRequest productRequest { get; set; } = default!;
        public List<ProductRespone> productRespone { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            productRequest.ProductId =await CreateId();
            string url = "api/product/Create";
            // Chuyển đổi đối tượng ProductRequest thành chuỗi JSON
            var jsonContent = JsonConvert.SerializeObject(productRequest);
            // Tạo nội dung HTTP để gửi đi
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            // Gửi yêu cầu POST đến API
            var response = await HttpClient.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Product");
            }
            else
            {
                ViewData["Message"] = "Create Fail!";
                return Page();
            }
        }

        private async Task<int> CreateId()
        {
            // Gọi API endpoint từ dự án API.
            HttpResponseMessage response = await HttpClient.GetAsync("api/product/Get-All");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                productRespone = JsonConvert.DeserializeObject<List<ProductRespone>>(content);
                return productRespone.LastOrDefault().ProductId+1;
            }
            return 0;
        }
    }
}
