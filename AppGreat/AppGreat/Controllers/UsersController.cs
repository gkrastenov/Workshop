namespace AppGreat.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using AppGreat.Data;
    using AppGreat.Data.Models;
    using AppGreat.Service.Interface;
    using AppGreat.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppGreatDbContext context;
        private IUserService userService;

        public UsersController(AppGreatDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await this.context.Users.ToListAsync();
        }

        // POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        // POST: api/Users/Login
        [HttpPost("Login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = this.userService.Authenticate(model);

            if (response == null)
                return this.BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
       
        // GET: api/Users/{id}/Orders
        [HttpGet("{id}/Orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetUserOrders(int id)
        {
            var order = await this.context.Orders.Where(o => o.UserId == id).ToListAsync();

            if (order == null)
            {
                return this.NotFound();
            }

            return order;
        }

        // GET: api/Users/{id}/Products
        [HttpGet("{id}/Products")]
        public ActionResult<IEnumerable<Product>> GetAllProductsByUser(int id)
        {
            var currentUser = this.context.Users.FirstOrDefault(a => a.Id == id);

            if (currentUser == null)
            {
                return this.NotFound();
            }

            var products = this.context.Products.ToList();

            if (products == null)
            {
                return this.NotFound();
            }

            var response = this.userService.TransferProductCurrency(products, currentUser);

            return response.ToList();
        }
    }
}
