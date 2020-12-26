namespace exclucv.Services.ServiceContracts
{
    using exclucv.DAL.Entities;
    using exclucv.DomainModels.DomainModels;

    public interface IApplicationUserService
    {
        User Register(User user);
        string Login(LoginModel loginModel);
    }
}
