namespace exclucv.Services.ServiceContracts
{
    using exclucv.DAL.Entities;
    using exclucv.DomainModels.DomainModels;
    using System;

    public interface IApplicationUserService
    {
        User Register(User user);
        string Login(LoginModel loginModel);
        User GetUserInfo(Guid userId);
    }
}
