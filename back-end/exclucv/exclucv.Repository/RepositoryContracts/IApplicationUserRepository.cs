namespace exclucv.Repository.RepositoryContracts
{
    using exclucv.DAL.Entities;
    using System;
    using System.Threading.Tasks;

    public interface IApplicationUserRepository : IRepository<Template>
    {
        Task<User> Register(User user);
        bool IsExistingUser(string email);
        User GetUserByEmail(string email);
        User GetUserInfo(Guid userId);
    }
}
