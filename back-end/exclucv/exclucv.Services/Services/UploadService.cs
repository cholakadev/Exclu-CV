using exclucv.Repository.RepositoryContracts;
using exclucv.Services.ServiceContracts;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace exclucv.Services.Services
{
    public class UploadService : IUploadService
    {
        private readonly IUploadRepository _repository;

        public UploadService(IUploadRepository repository)
        {
            this._repository = repository;
        }

        public string UploadProfileImage(Guid userId, IFormFile file)
        {
            if (userId == Guid.Empty || userId == null)
            {
                throw new Exception("Failed to upload. Invalid user.");
            }

            if (file.Length <= 0)
            {
                throw new Exception("There is not a file specified to be uploaded.");
            }

            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var uploadedImagePath = this._repository.SaveProfileImagePathToDb(userId, dbPath);
            return uploadedImagePath;
        }
    }
}
