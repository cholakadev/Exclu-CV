namespace exclucv.Repository.RepositoryContracts
{
    using exclucv.DAL.Models;
    using exclucv.DAL.Models.MainInfo;
    using System.Collections.Generic;

    public interface ITemplateRepository : IRepository<CvModel>
    {
        IEnumerable<Department> GetDepartments();
        IEnumerable<Level> GetLevels();
        MainInformation CreateMainInformation(MainInformation mainInformation);
    }
}
