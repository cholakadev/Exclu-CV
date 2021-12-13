namespace exclucv.Services.ServiceContracts
{
    using Microsoft.AspNetCore.Http;
    using System;

    public interface IUploadService
    {
        string UploadProfileImage(Guid userId, IFormFile file);
    }
}
