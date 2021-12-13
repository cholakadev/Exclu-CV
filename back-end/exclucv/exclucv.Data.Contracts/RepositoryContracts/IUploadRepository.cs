namespace exclucv.Data.Contracts.RepositoryContracts
{
    using System;

    public interface IUploadRepository
    {
        string SaveProfileImagePathToDb(Guid userId, string path);
    }
}
