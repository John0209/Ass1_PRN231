using DataAccess.Models;
using DataAccess.ResponeModel;
using eStoreClient.Pages.Inheritance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace eStoreClient.Pages
{
    public class MemberModel : ClientAbstract
    {
        public MemberModel(IHttpClientFactory http) : base(http)
        {
        }

        [BindProperty]
        public List<MemberRespone> Members { get; set; } = default!;
        [BindProperty]
        public string search { get; set; }
        public async Task OnGetAsync()
        {
            // Gọi API endpoint từ dự án API.
            HttpResponseMessage response = await HttpClient.GetAsync("api/member/Get-All");
            if(response.IsSuccessStatusCode)
            {
                var content= await response.Content.ReadAsStringAsync();

                Members = JsonConvert.DeserializeObject<List<MemberRespone>>(content);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string url = $"api/member/Search?serachs={search}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                Members = JsonConvert.DeserializeObject<List<MemberRespone>>(content);
                return Page();
            }
            ViewData["Message"] = $"{search} don't exits!";
            return Page();
        }
    }
}
