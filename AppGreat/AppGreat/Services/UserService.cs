namespace AppGreat.Service
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using AppGreat.Data.Models;
    using AppGreat.Helpers;
    using AppGreat.Models;
    using AppGreat.Service.Interface;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> users = new List<User>
        {
            new User { Id = 1,  Username = "test", Password = "test" }
        };

        private readonly AppSettings appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        /// <summary>
        /// Autenticate user with JWT token
        /// </summary>
        /// <param name="model">AuthenticateRequest</param>
        /// <returns>AuthenticateResponse</returns>
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = this.users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null)
            {
                return null;
            }

            // authentication successful so generate jwt token
            var token = this.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return this.users;
        }

        public User GetById(int id)
        {
            return this.users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> TransferProductCurrency(List<Product> products, User user)
        {
            // If CurrencyCode is BGN, product do not need to be transferred
            if (user.CurrencyCode == "BGN")
            {
                return products;
            }
    
            var exchangedRates = this.GetExchangeRates();
            Task.WaitAll(exchangedRates);
            var rate = exchangedRates.Result;

            decimal exchangedPrice = rate[user.CurrencyCode];
            foreach (var product in products)
            {
                product.Price = product.Price * exchangedPrice;
            }

            return products;
        }

        /// <summary>
        /// Generate new JWT token for authenticaiton .
        /// </summary>
        /// <returns>Token</returns>
        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Get exchanged rates from another api
        /// </summary>
        private async Task<Dictionary<string, decimal>> GetExchangeRates()
        {
            HttpClient client = new HttpClient();
            var responseString = await client.GetStringAsync("https://api.exchangeratesapi.io/latest?base=BGN");
          
            var jobject = JsonConvert.DeserializeObject<JObject>(responseString);
            Dictionary<string, decimal> rates = jobject["rates"].ToObject<Dictionary<string, decimal>>();

            return rates;
        }
    }
}
