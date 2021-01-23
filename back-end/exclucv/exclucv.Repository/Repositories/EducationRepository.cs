namespace exclucv.Repository.Repositories
{
    using exclucv.DAL.Entities;
    using exclucv.Repository.RepositoryContracts;
    using System;
    using System.Collections.Generic;

    public class EducationRepository : IEducationRepository
    {
        private readonly exclucv_dbContext _context;

        public EducationRepository(exclucv_dbContext context)
        {
            this._context = context;
        }

        public void AddEducations(List<Education> educations)
        {
            throw new NotImplementedException();
        }

        public Guid RemoveEducation(Guid educationId)
        {
            throw new NotImplementedException();
        }
    }
}
