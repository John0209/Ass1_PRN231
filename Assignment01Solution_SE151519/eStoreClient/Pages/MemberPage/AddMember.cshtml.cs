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
    public class AddMemberModel : ClientAbstract
    {
        public AddMemberModel(IHttpClientFactory http) : base(http)
        {
        }

        [BindProperty]
        public MemberRequest memberRequest { get; set; } = default!;
        public List<MemberRespone> memberRespone { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CreateId();
            string url = "api/member/Create";
            // Chuyển đổi đối tượng ProductRequest thành chuỗi JSON
            var jsonContent = JsonConvert.SerializeObject(memberRequest);
            // Tạo nội dung HTTP để gửi đi
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            // Gửi yêu cầu POST đến API
            var response = await HttpClient.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/MemberPage/Member");
            }
            else
            {
                ViewData["Message"] = "Create Fail!";
                return Page();
            }
        }

        private async Task CreateId()
        {
            // Gọi API endpoint từ dự án API.
            HttpResponseMessage response = await HttpClient.GetAsync("api/member/Get-All");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                memberRespone = JsonConvert.DeserializeObject<List<MemberRespone>>(content);
                memberRequest.MemberId = memberRespone.LastOrDefault().MemberId + 1;
            }
        }
    }
}
