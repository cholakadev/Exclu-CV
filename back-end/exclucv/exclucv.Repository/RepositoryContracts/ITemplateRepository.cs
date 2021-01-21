namespace exclucv.Repository.RepositoryContracts
{
    using exclucv.DAL.Entities;
    using exclucv.DAL.Models;
    using exclucv.DAL.Models.MainInfo;
    using System;

    public interface ITemplateRepository : IRepository<CvModel>
    {
        MainInformation CreateMainInformation(MainInformation mainInformation);

        Guid CreateSummary(Summary summary);
        Guid CreateTemplate(Template template);
    }
}
