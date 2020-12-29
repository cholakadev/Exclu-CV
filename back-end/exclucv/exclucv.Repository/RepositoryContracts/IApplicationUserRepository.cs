namespace exclucv.Repository.RepositoryContracts
{
    using exclucv.DAL.Entities;
    using System;

    public interface IApplicationUserRepository : IRepository<Template>
    {
        User Register(User user);
        bool IsExistingUser(string email);
        User GetUserByEmail(string email);
        User GetUserInfo(Guid userId);
    }
}
