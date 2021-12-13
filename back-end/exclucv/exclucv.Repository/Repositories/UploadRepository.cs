﻿namespace exclucv.Repository.Repositories
{
    using exclucv.DAL.Models;
    using exclucv.Repository.RepositoryContracts;
    using System;
    using System.Linq;

    public class UploadRepository : IUploadRepository
    {
        private readonly exclucvDb_10_DevContext _context;

        public UploadRepository(exclucvDb_10_DevContext context)
        {
            this._context = context;
        }

        public string SaveProfileImagePathToDb(Guid userId, string profileImagePath)
        {
            var user = this._context.User.FirstOrDefault(u => u.Id == userId);
            user.ProfileImage = profileImagePath;
            this._context.SaveChanges();

            return user.ProfileImage;
        }
    }
}
