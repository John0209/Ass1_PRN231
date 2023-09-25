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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MovieManagement_NguyenTuanVu.Pages
{
    public class EditModel : ClientAbstract
    {
		public EditModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
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
            string url = "api/product/Update";
            // Chuyển đổi đối tượng ProductRequest thành chuỗi JSON
            var jsonContent = JsonConvert.SerializeObject(productRequest);
            // Tạo nội dung HTTP để gửi đi
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            // Gửi yêu cầu POST đến API
            var response = await HttpClient.PutAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Product");
            }
            else
            {
                ViewData["Message"] = "Update Fail!";
                return Page();
            }
        }
    }
}
