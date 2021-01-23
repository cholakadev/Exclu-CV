namespace exclucv.Services.ServiceContracts
{
    using exclucv.DAL.Entities;
    using System;
    using System.Collections.Generic;

    public interface IEducationService
    {
        void AddEducations(List<Education> educations);
        Guid RemoveEducation(Guid educationId);
    }
}
