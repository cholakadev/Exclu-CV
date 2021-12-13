namespace exclucv.Data.Repositories
{
    using exclucv.Data.Models;
    using exclucv.Data.RepositoryContracts;
    using System;


    public class TemplateRepository : ITemplateRepository
    {
        private readonly exclucvDb_10_DevContext _context;

        public TemplateRepository(exclucvDb_10_DevContext context)
        {
            this._context = context;
        }

        public Guid CreateTemplate(Template template)
        {
            this._context.Template.Add(template);
            this._context.SaveChanges();

            return template.Id;
        }
    }
}
