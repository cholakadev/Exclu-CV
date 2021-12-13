namespace exclucv.Data.RepositoryContracts
{
    using System;

    public interface IUploadRepository
    {
        string SaveProfileImagePathToDb(Guid userId, string path);
    }
}
