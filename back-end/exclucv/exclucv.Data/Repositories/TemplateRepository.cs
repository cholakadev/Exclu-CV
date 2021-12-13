namespace exclucv.Data.Repositories
{
    using exclucv.Data.Contracts.RepositoryContracts;
    using exclucv.Data.Models;
    using System;


    public class TemplateRepository : ITemplateRepository
    {
        private readonly exclucvDb_10_DevContext _context;

        public TemplateRepository(exclucvDb_10_DevContext context)
        {
            this._context = context;
        }

        public Guid CreateTemplate(DomainModel.Template template)
        {
            //this._context.Template.Add(template);
            //this._context.SaveChanges();

            return Guid.NewGuid();// template.Id;
        }
    }
}
