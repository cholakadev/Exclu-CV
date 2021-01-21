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

        public Guid AddSkill(Guid userId, Skill skill)
        {
            Template template = this._context.Template.FirstOrDefault(x => x.UserId == userId);
            skill.TemplateId = template.TemplateId;

            this._context.Skill.Add(skill);
            this._context.SaveChanges();

            return skill.SkillId;
        }

        public Guid DeleteSkill(Guid userId, Guid skillId)
        {
            //var template = this._context.Template.FirstOrDefault(t => t.UserId == userId);
            var skill = this._context.Skill.FirstOrDefault(s => s.SkillId == skillId);

            this._context.Remove(skill);
            this._context.SaveChanges();

            return skill.SkillId;
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
