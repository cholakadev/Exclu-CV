namespace exclucv.Repository.Repositories
{
    using exclucv.DAL.Entities;
    using exclucv.Repository.RepositoryContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EducationRepository : IEducationRepository
    {
        private readonly exclucv_dbContext _context;

        public EducationRepository(exclucv_dbContext context)
        {
            this._context = context;
        }

        public void AddEducations(List<Education> educations, Guid userId)
        {
            var currentUserTemplateId = this._context.Template.FirstOrDefault(x => x.UserId == userId).TemplateId;

            foreach (var education in educations)
            {
                education.TemplateId = currentUserTemplateId;
                this._context.Education.Add(education);
            }

            this._context.SaveChanges();
        }

        public Guid RemoveEducation(Guid educationId)
        {
            throw new NotImplementedException();
        }
    }
}
