using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppGreat.Data;
using AppGreat.Data.Models;
using AppGreat.Service.Interface;
using AppGreat.Models;
using Microsoft.AspNetCore.Localization;

namespace AppGreat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppGreatDbContext _context;
        private IUserService _userService;

        public UsersController(AppGreatDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        // POST: api/Users/Login
        [HttpPost("Login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
       
        // GET: api/Users/5/Orders
        [HttpGet("{id}/Orders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetUserOrders(int id)
        {
            var order = await _context.Orders.Where(o => o.UserId == id).ToListAsync();

            if (order == null)
            {
                return NotFound();
            }

            return  order;
        }

        // GET: api/Users/5/Products
        [HttpGet("{id}/Products")]
        public ActionResult<IEnumerable<Product>> GetAllProductsByUser(int id)
        {
            var currentUser = _context.Users.FirstOrDefault(a => a.Id == id);

            if (currentUser == null)
            {
                return NotFound();
            }

            var products = _context.Products.ToList();

            if (products == null)
            {
                return NotFound();
            }

            var response = _userService.TransferProductCurrency(products, currentUser);

            return response.ToList();
        }
    }
}
