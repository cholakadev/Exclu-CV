namespace exclucv.Repository.RepositoryContracts
{
    using exclucv.DAL.Entities;
    using System;
    using System.Collections.Generic;

    public interface ISkillsRepository
    {
        Guid AddSkill(Guid userId, Skill skill);
        Guid DeleteSkill(Guid userId, Guid skillId);
        IEnumerable<Skill> GetAllSkills(Guid userId);
    }
}
