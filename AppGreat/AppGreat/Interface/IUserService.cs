namespace AppGreat.Service.Interface
{
    using AppGreat.Data.Models;
    using AppGreat.Models;
    using System.Collections.Generic;

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
