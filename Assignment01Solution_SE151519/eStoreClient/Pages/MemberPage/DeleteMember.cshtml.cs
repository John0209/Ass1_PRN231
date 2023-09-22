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
    public class DeleteMemberModel : ClientAbstract
    {

        public DeleteMemberModel(IHttpClientFactory http) : base(http)
        {
        }

        [BindProperty]
        public MemberRequest memberRequest { get; set; } = default!;
        public async Task OnGetAsync(int? id)
        {
            string url = $"api/member/Get-By-Id?id={id}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                memberRequest = JsonConvert.DeserializeObject<MemberRequest>(content);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string url = $"api/member/Delete?id={memberRequest.MemberId}";
            HttpResponseMessage response = await HttpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/MemberPage/Member");
            }
            else
            {
                ViewData["Message"] = "Delete Fail!";
                return Page();
            }
        }
    }
}
