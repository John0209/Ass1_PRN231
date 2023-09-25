using DataAccess.Models;
using DataAccess.RequestModel;
using DataAccess.ResponeModel;
using eStoreClient.Pages.Inheritance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace eStoreClient.Pages
{
    public class CartModel : ClientAbstract
    {
        public CartModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }
        [BindProperty]
        public ProductRespone Product { get; set; }
        public OrderRequest Order { get; set; }
        public List<OrderRespone> OrderRespone { get; set; }
        public OrderDetailRequest OrderDetail { get; set; }
        public List<OrderDetailRespone> OrderDetailRespone { get; set; }
        public async Task OnGetAsync()
        {
            int getSession = (int)_context.HttpContext.Session.GetInt32("ProductSS");
            string url = $"api/product/Get-By-Id?id={getSession}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Product = JsonConvert.DeserializeObject<ProductRespone>(content);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await OnGetAsync();
            Order= new OrderRequest();
            int memberId = (int)_context.HttpContext.Session.GetInt32("MemberSS");
            Order.MemberId=memberId;
            Order.OrderId= await GetOrderId();
            Order.OrderDate = DateTime.Now;
            Order.RequiredDate = DateTime.Now;
            Order.ShippedDate = DateTime.Now;
            Order.Freight = Product.UnitPrice;
            string url = "api/order/Create";
            // Chuyển đổi đối tượng ProductRequest thành chuỗi JSON
            var jsonContent = JsonConvert.SerializeObject(Order);
            // Tạo nội dung HTTP để gửi đi
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            // Gửi yêu cầu POST đến API
            var response = await HttpClient.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                CreateOrderDetail();
            }
            return RedirectToPage("/OrderPage/Order");
        }

        private async Task CreateOrderDetail()
        {
            OrderDetail= new OrderDetailRequest();
			OrderDetail.OrderId=Order.OrderId;
            OrderDetail.ProductId = Product.ProductId;
            OrderDetail.UnitPrice= Product.UnitPrice;
            OrderDetail.Quantity = Product.UnitsInStock;
            OrderDetail.Discount = 0;
            string url = "api/order-detail/Create";
            // Chuyển đổi đối tượng ProductRequest thành chuỗi JSON
            var jsonContent = JsonConvert.SerializeObject(OrderDetail);
            // Tạo nội dung HTTP để gửi đi
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            // Gửi yêu cầu POST đến API
            var response = await HttpClient.PostAsync(url, httpContent);
        }

        private async Task<int> GetORderDetailId()
        {
            // Gọi API endpoint từ dự án API.
            HttpResponseMessage response = await HttpClient.GetAsync("api/order-detail/Get-All");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                OrderDetailRespone = JsonConvert.DeserializeObject<List<OrderDetailRespone>>(content);
				return OrderDetailRespone.LastOrDefault().OrderId  + 1;
            }
			return 1;
		}

        private async Task<int> GetOrderId()
        {
            // Gọi API endpoint từ dự án API.
            HttpResponseMessage response = await HttpClient.GetAsync("api/order/Get-All");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                OrderRespone = JsonConvert.DeserializeObject<List<OrderRespone>>(content);
                return OrderRespone.LastOrDefault().OrderId + 1;
            }
            return 1;
        }
    }
}
