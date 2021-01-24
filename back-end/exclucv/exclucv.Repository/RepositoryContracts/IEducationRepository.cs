namespace exclucv.Repository.RepositoryContracts
{
    using exclucv.DAL.Entities;
    using System;
    using System.Collections.Generic;

    public interface IEducationRepository
    {
        void AddEducations(List<Education> educations, Guid userId);
        Guid RemoveEducation(Guid educationId);
    }
}
