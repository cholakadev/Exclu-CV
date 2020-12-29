namespace exclucv.Repository.Repositories
{
    using exclucv.DAL.Entities;
    using exclucv.Repository.RepositoryContracts;
    using System;
    using System.Linq;

    public class UploadRepository : IUploadRepository
    {
        private readonly exclucv_dbContext _context;

        public UploadRepository(exclucv_dbContext context)
        {
            this._context = context;
        }

        public string SaveProfileImagePathToDb(Guid userId, string profileImagePath)
        {
            var user = this._context.User.FirstOrDefault(u => u.UserId == userId);
            user.ProfileImage = profileImagePath;
            this._context.SaveChanges();

            return user.ProfileImage;
        }
    }
}
