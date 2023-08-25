using DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductsTaskCore;

namespace ProductsTaskAPI
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Product product)
        {
            var pm = new ProductManager();

            var NewProduct = pm.Create(product);

            try
            {
                return Ok(NewProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public async Task<IActionResult> RetrieveAll()
        {
            var pm = new ProductManager();
            var result = pm.RetrieveAll();

            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
