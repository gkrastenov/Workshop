using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppGreat.Data;
using AppGreat.Data.Models;
using AppGreat.Models;

namespace AppGreat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppGreatDbContext _context;

        public OrdersController(AppGreatDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: api/Orders
        [HttpPost("Create")]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // POST: api/Orders/id/ChangeStatus
        [HttpPost("{id}/ChangeStatus")]
        public IActionResult Authenticate(OrderChangeStatusRequest order, int id)
        {
            var newOrder = _context.Orders.Where(i => i.Id == id).FirstOrDefault();

            if (newOrder == null)
            {
                return BadRequest(new { message = "This order does not exist" });
            }
            newOrder.Status = order.Status;
            _context.SaveChanges();

            return Ok(newOrder);
        }


    }
}
