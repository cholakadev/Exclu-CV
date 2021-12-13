namespace exclucv.Services.ServiceContracts
{
    using exclucv.Data.Models;
    using exclucv.DomainModels.DomainModels;
    using System;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<Data.Models.User> Register(Data.Models.User user);
        //string Login(LoginModel loginModel);
        Data.Models.User GetUserInfo(Guid userId);
    }
}
