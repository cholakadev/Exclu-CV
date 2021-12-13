namespace exclucv.Repository.RepositoryContracts
{
    using exclucv.DAL.Models;
    using System;

    public interface ITemplateRepository : IRepository<Template>
    {
        Guid CreateTemplate(Template template);
    }
}
