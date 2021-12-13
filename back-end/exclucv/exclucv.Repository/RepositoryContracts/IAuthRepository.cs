namespace exclucv.Repository.RepositoryContracts
{
    using exclucv.Data.Models;
    using System;
    using System.Threading.Tasks;

    public interface IAuthRepository : IRepository<User>
    {
        Task<User> Register(User user);
        bool IsExistingUser(string email);
        User GetUserByEmail(string email);
        User GetUserInfo(Guid userId);
    }
}
