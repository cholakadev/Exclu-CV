using exclucv.DAL.Entities;
using exclucv.DAL.Models.MainInfo;
using exclucv.Repository.RepositoryContracts;
using System;

namespace exclucv.Repository.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly exclucv_dbContext _context;

        public TemplateRepository(exclucv_dbContext context)
        {
            this._context = context;
        }

        public MainInformation CreateMainInformation(MainInformation mainInformation)
        {
            throw new System.NotImplementedException();
        }

        public Guid CreateSummary(Summary summary)
        {
            this._context.Summary.Add(summary);
            this._context.SaveChanges();

            return summary.SummaryId;
        }

        public Guid CreateTemplate(Template template)
        {
            this._context.Template.Add(template);
            this._context.SaveChanges();

            return template.TemplateId;
        }
    }
}
