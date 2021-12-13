namespace exclucv.Data.Repositories
{
    using AutoMapper;
    using exclucv.Data.Contracts.RepositoryContracts;
    using exclucv.Data.Models;
    using System.Linq;

    public class AuthRepository : IAuthRepository
    {
        private readonly exclucvDb_10_DevContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(exclucvDb_10_DevContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public void Register(DomainModel.User user)
        {
            var entity = this._mapper.Map<DomainModel.User, User>(user);

            this._context.User.Add(entity);
            this._context.SaveChanges();
        }

        //public User GetUserByEmail(string email)
        //    => this._context.User.FirstOrDefault(u => u.Email == email);

        //public User GetUserInfo(Guid userId)
        //    => this._context.User.FirstOrDefault(u => u.Id == userId);

        public bool IsExistingUser(string email)
        {
            User user = this._context.User
                .FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
