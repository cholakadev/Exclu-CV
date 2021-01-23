namespace exclucv.Services.ServiceContracts
{
    using exclucv.DAL.Entities;
    using exclucv.DomainModels.DomainModels;
    using System;
    using System.Threading.Tasks;

    public interface IApplicationUserService
    {
        Task<User> Register(User user);
        string Login(LoginModel loginModel);
        User GetUserInfo(Guid userId);
    }
}
