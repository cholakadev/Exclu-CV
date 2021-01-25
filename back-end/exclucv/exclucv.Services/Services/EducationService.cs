namespace exclucv.Services.Services
{
    using exclucv.DAL.Entities;
    using exclucv.Repository.RepositoryContracts;
    using exclucv.Services.ServiceContracts;
    using System;
    using System.Collections.Generic;

    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository)
        {
            this._educationRepository = educationRepository;
        }

        public void AddEducations(List<Education> educations, Guid userId)
        {
            foreach (var education in educations)
            {
                education.EducationId = Guid.NewGuid();
            }

            this._educationRepository.AddEducations(educations, userId);
        }

        public Guid RemoveEducation(Guid educationId)
        {
            throw new NotImplementedException();
        }
    }
}
