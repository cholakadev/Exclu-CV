namespace exclucv.Services.Services
{
    using exclucv.DAL.Entities;
    using exclucv.Repository.RepositoryContracts;
    using exclucv.Services.ServiceContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SkillsService : ISkillsService
    {
        private readonly ISkillsRepository _repository;
        private readonly ITemplateRepository _templateRepository;

        public SkillsService(ISkillsRepository repository, ITemplateRepository templateRepository)
        {
            this._repository = repository;
            this._templateRepository = templateRepository;
        }

        public Guid AddSkill(Guid userId, Skill skill)
        {
            skill.SkillId = Guid.NewGuid();
            return this._repository.AddSkill(userId, skill);
        }

        public Guid DeleteSkill(Guid userId, Guid skillId)
            => this._repository.DeleteSkill(userId, skillId);

        public IEnumerable<Skill> GetAllSkills(Guid userId)
        {
            var skills = this._repository.GetAllSkills(userId).ToList();
            return skills;
        }
    }
}
