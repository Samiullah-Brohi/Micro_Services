using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
