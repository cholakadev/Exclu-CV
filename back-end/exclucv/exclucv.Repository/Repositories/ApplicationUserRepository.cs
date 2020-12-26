namespace exclucv.Repository.Repositories
{
    using exclucv.DAL.Entities;
    using exclucv.Repository.RepositoryContracts;
    using System.Linq;

    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly exclucv_dbContext _context;

        public ApplicationUserRepository(exclucv_dbContext context)
        {
            this._context = context;
        }

        public User GetUserByEmail(string email)
            => this._context.User.FirstOrDefault(u => u.Email == email);

        public bool IsExistingUser(string email)
        {
            User user = this._context.User.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        public User Register(User user)
        {
            if (user != null)
            {
                this._context.User.Add(user);
                this._context.SaveChangesAsync();
            }

            return user;
        }
    }
}
