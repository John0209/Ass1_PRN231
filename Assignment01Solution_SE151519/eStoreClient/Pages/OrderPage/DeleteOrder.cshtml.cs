using DataAccess.RequestModel;
using eStoreClient.Pages.Inheritance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace eStoreClient.Pages
{
    public class DeleteOrderModel : ClientAbstract
    {
        public DeleteOrderModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }

        [BindProperty]
        public OrderRequest orderRequest { get; set; } = default!;
        public async Task OnGetAsync(int? id)
        {
            string url = $"api/order/Get-By-Id?id={id}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                orderRequest = JsonConvert.DeserializeObject<OrderRequest>(content);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            string url = $"api/order/Delete?id={orderRequest.OrderId}";
            HttpResponseMessage response = await HttpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/OrderPage/Order");
            }
            else
            {
                ViewData["Message"] = "Delete Fail!";
                return Page();
            }
        }

    }
}
