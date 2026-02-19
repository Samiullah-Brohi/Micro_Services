using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Micro_Services.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "Laptop", "Phone", "Tablet" };
        }

        [HttpGet("{productName}")]
        public IEnumerable<string> GetByName(string productName)
        {
            var products = new[] { "Laptop", "Phone", "Tablet" };
            var filteredProducts = products.Where(p => p.Contains(productName, StringComparison.OrdinalIgnoreCase));
            return filteredProducts;
        }
    }
}
