namespace exclucv.Repository.RepositoryContracts
{
    using exclucv.DAL.Entities;

    public interface IApplicationUserRepository : IRepository<Template>
    {
        User Register(User user);
        bool IsExistingUser(string email);
        User GetUserByEmail(string email);
    }
}
