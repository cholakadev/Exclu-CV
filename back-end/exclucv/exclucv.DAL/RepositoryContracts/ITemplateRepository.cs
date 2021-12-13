namespace exclucv.Data.RepositoryContracts
{
    using exclucv.Data.Models;
    using System;

    public interface ITemplateRepository : IRepository<Template>
    {
        Guid CreateTemplate(Template template);
    }
}
