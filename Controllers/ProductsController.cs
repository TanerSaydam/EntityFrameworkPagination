using EntityFrameworkPagination.Context;
using EntityFrameworkPagination.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int pageNumber = 1, int pageSize = 15)
        {
            var products = await _context.Products
                .ToPagedListAsync(pageNumber, pageSize);

            return Ok(products);
        }
    }
}
