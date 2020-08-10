namespace AppGreat.Service.Interface
{
    using AppGreat.Data.Models;
    using AppGreat.Models;
    using System.Collections.Generic;

    public interface IUserService
    {
        /// <summary>
        /// Authenticate evry new user with JWT token
        /// </summary>
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        /// <summary>
        /// Transfer all products price to user currency.
        /// </summary>
        /// <returns>All products</returns>
        IEnumerable<Product> TransferProductCurrency(List<Product> products, User user);
      
        IEnumerable<User> GetAll();
       
        User GetById(int id);
    }
}
