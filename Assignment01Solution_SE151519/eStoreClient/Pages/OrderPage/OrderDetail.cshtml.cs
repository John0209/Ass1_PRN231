using DataAccess.RequestModel;
using DataAccess.ResponeModel;
using eStoreClient.Pages.Inheritance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace eStoreClient.Pages.OrderPage
{
    public class OrderDetailModel : ClientAbstract
    {
        public OrderDetailModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }

        [BindProperty]
        public OrderDetailRespone orderDetail { get; set; } = default!;
        public async Task OnGetAsync(int OrderId)
        {
            string url = $"api/order-detail/Get-By-Id?orderId={OrderId}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                orderDetail = JsonConvert.DeserializeObject<OrderDetailRespone>(content);
            }
        }

    }
}
