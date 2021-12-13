namespace exclucv.Core.ServiceContracts
{
    using exclucv.Core.Http;
    using exclucv.Domain.DomainModel;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<User> Register(RegisterRequest user);

        //string Login(LoginModel loginModel);
    }
}
