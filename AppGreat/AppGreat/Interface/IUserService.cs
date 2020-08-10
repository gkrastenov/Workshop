namespace AppGreat.Service.Interface
{
    using AppGreat.Data.Models;
    using AppGreat.Models;
    using System.Collections.Generic;

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Product> TransferProductCurrency(List<Product> products, User user);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
