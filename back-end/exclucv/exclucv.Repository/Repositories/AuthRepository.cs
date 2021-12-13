namespace exclucv.Repository.Repositories
{
    using exclucv.Data.Models;
    using exclucv.Repository.RepositoryContracts;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class AuthRepository : IAuthRepository
    {
        private readonly exclucvDb_10_DevContext _context;

        public AuthRepository(exclucvDb_10_DevContext context)
        {
            this._context = context;
        }

        public User GetUserByEmail(string email)
            => this._context.User.FirstOrDefault(u => u.Email == email);

        public User GetUserInfo(Guid userId)
            => this._context.User.FirstOrDefault(u => u.Id == userId);

        public bool IsExistingUser(string email)
        {
            User user = this._context.User.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public async Task<User> Register(User user)
        {
            if (user != null)
            {
                await this._context.User.AddAsync(user);
                await this._context.SaveChangesAsync();
            }

            return user;
        }
    }
}
