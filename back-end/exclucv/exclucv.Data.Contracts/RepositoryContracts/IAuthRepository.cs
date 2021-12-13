namespace exclucv.Data.Contracts.RepositoryContracts
{
    using System;
    using System.Threading.Tasks;

    public interface IAuthRepository : IRepository<DomainModel.User>
    {
        //Task<DomainModel.User> Register(DomainModel.User user);
        //bool IsExistingUser(string email);
        //DomainModel.User GetUserByEmail(string email);
        //DomainModel.User GetUserInfo(Guid userId);
    }
}
