namespace AppGreat.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AppGreat.Data;
    using AppGreat.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppGreatDbContext context;

        public ProductsController(AppGreatDbContext context)
        {
            this.context = context;
        }

        // GET api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await this.context.Products.ToListAsync();
        }

        // GET: api/Products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await this.context.Products.FindAsync(id);

            if (product == null)
            {
                return this.NotFound();
            }

            return product;
        }

        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return this.BadRequest();
            }

            this.context.Entry(product).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ProductExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            this.context.Products.Add(product);
            await this.context.SaveChangesAsync();


            return this.CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await this.context.Products.FindAsync(id);
            if (product == null)
            {
                return this.NotFound();
            }

            this.context.Products.Remove(product);
            await this.context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return this.context.Products.Any(e => e.Id == id);
        }
    }
}
