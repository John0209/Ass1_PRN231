using eStoreClient.Pages.Inheritance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace MovieManagement_NguyenTuanVu.Pages
{
    public class LoginModel : ClientAbstract
    {
        public LoginModel(IHttpClientFactory http) : base(http)
        {
        }

        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string password { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
           
           //Xây dựng URL cho api
            string url = "api/member/Login";
            // Parameter
            var queryParameter = new Dictionary<string, string>
            {
                {"email", email},
                {"password", password}
            };
            string queryString= string.Join("&", queryParameter.Select(x=> $"{x.Key}={x.Value}"));
            url = $"{url}?{queryString}";
            //string apiUrl = $"api/member/Login?email={email}&password={password}";
            HttpResponseMessage respone = await HttpClient.PostAsync(url,null);
            if (respone.IsSuccessStatusCode)
            {
                return RedirectToPage("Product");
            }
            else
            {
                ViewData["Message"] = "You do not have permission to do this function!";
                return Page();
            }
        }

        
    }
}
