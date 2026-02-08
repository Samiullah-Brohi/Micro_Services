using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly HttpClient _http;


        public OrdersController(HttpClient http)
        {
            _http = http;

        }

        [HttpGet]
        public async Task<string> Get()
        {
            var products = await _http.GetStringAsync("http://productservice/api/products");
           // var products = await _http.GetStringAsync("https://localhost:7160/api/products");
            return $"Order created for: {products}";
        }

    }
}
