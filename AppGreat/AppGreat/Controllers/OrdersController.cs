namespace AppGreat.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using AppGreat.Data;
    using AppGreat.Data.Models;
    using AppGreat.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppGreatDbContext context;

        public OrdersController(AppGreatDbContext context)
        {
            this.context = context;
        }

        // GET: api/Orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await this.context.Orders.FindAsync(id);

            if (order == null)
            {
                return this.NotFound();
            }

            return order;
        }

        // POST: api/Orders
        [HttpPost("Create")]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            this.context.Orders.Add(order);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // POST: api/Orders/{id}/ChangeStatus
        [HttpPost("{id}/ChangeStatus")]
        public IActionResult Authenticate(OrderChangeStatusRequest order, int id)
        {
            var newOrder = this.context.Orders.Where(i => i.Id == id).FirstOrDefault();

            if (newOrder == null)
            {
                return this.BadRequest(new { message = "This order does not exist" });
            }

            newOrder.Status = order.Status;
            this.context.SaveChanges();

            return this.Ok(newOrder);
        }


    }
}
