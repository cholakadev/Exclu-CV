namespace exclucv.Core.ServiceContracts
{
    using exclucv.Core.Http;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        void Register(RegisterRequest user);

        //string Login(LoginModel loginModel);
    }
}
