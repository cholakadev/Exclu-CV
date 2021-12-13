namespace exclucv.Services.ServiceContracts
{
    using exclucv.DAL.Models;
    using exclucv.DomainModels.DomainModels;
    using System;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<User> Register(User user);
        //string Login(LoginModel loginModel);
        User GetUserInfo(Guid userId);
    }
}
