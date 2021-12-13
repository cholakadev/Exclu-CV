namespace exclucv.Core.ServiceContracts
{
    using exclucv.Core.Http;
    using System;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<DomainModel.User> Register(RegisterRequest user);

        //string Login(LoginModel loginModel);
    }
}
