using exclucv.DAL.Entities;
using exclucv.DAL.Models.MainInfo;
using exclucv.Repository.RepositoryContracts;
using System;
using System.Collections.Generic;

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

        public Guid CreateTemplate(Guid userId)
        {
            Template template = new Template()
            {
                TemplateId = Guid.NewGuid(),
                UserId = userId
            };

            this._context.Template.Add(template);
            this._context.SaveChanges();

            return template.TemplateId;
        }

        public IEnumerable<Department> GetDepartments()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Level> GetLevels()
        {
            throw new System.NotImplementedException();
        }
    }
}
