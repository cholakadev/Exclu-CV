namespace exclucv.Services.ServiceContracts
{
    using exclucv.DAL.Entities;
    using System;
    using System.Collections.Generic;

    public interface ISkillsService
    {
        Guid AddSkill(Guid userId, Skill skill);
        void DeleteSkill(Guid userId, Guid skillId);
        IEnumerable<Skill> GetAllSkills(Guid userId);
    }
}
