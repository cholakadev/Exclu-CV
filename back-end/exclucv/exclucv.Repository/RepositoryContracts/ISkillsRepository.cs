namespace exclucv.Repository.RepositoryContracts
{
    using exclucv.DAL.Entities;
    using System;
    using System.Collections.Generic;

    public interface ISkillsRepository
    {
        Guid AddSkill(Guid templateId, Guid userId, Skill skill);
        void DeleteSkill(Guid userId, Guid skillId);
        IEnumerable<Skill> GetAllSkills(Guid userId);
    }
}
