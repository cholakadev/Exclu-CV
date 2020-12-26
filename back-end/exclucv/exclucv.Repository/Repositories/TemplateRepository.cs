using exclucv.DAL.Models;
using exclucv.DAL.Models.MainInfo;
using exclucv.Repository.RepositoryContracts;
using System.Collections.Generic;

namespace exclucv.Repository.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly ExclucvDbContext _context;

        public TemplateRepository(ExclucvDbContext context)
        {
            this._context = context;
        }

        public MainInformation CreateMainInformation(MainInformation mainInformation)
        {
            throw new System.NotImplementedException();
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
