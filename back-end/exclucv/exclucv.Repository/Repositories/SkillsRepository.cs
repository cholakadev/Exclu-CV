namespace exclucv.Repository.Repositories
{
    using exclucv.DAL.Entities;
    using exclucv.Repository.RepositoryContracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SkillsRepository : ISkillsRepository
    {
        private readonly exclucv_dbContext _context;

        public SkillsRepository(exclucv_dbContext context)
        {
            this._context = context;
        }

        public Guid AddSkill(Guid templateId, Guid userId, Skill requestSkill)
        {
            Skill skill = new Skill()
            {
                SkillId = Guid.NewGuid(),
                Skill1 = requestSkill.Skill1,
                TemplateId = templateId
            };

            this._context.Skill.Add(skill);
            this._context.SaveChanges();

            return skill.SkillId;
        }

        public void DeleteSkill(Guid userId, Guid skillId)
        {
            var template = this._context.Template.FirstOrDefault(t => t.UserId == userId);
            var skill = this._context.Skill.FirstOrDefault(s => s.SkillId == skillId);

            this._context.Remove(skill);
            this._context.SaveChanges();
        }

        public IEnumerable<Skill> GetAllSkills(Guid userId)
        {
            var template = this._context.Template.FirstOrDefault(u => u.UserId == userId);
            var skills = this._context.Skill.Where(s => s.TemplateId == template.TemplateId).ToList();

            if (skills.Count == 0)
            {
                throw new Exception("Empty skills collection");
            }
            return skills;
        }
    }
}
