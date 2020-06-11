namespace exclucv.Controllers
{
    using exclucv.DAL.Models;
    using exclucv.DAL.Models.Skills;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ExclucvDbContext _context;

        public SkillsController(ExclucvDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        [Route("levels")]
        // GET : /api/skills/levels
        public async Task<ActionResult<IEnumerable<SkillLevel>>> GetSkillLevels()
        {
            return await this._context.SkillLevels.ToListAsync();
        }

        [HttpPost]
        [Route("levels")]
        // POST : /api/skills/levels
        public async Task<ActionResult<SkillLevel>> AddSkillLevel(SkillLevel skillLevel)
        {
            this._context.SkillLevels.Add(skillLevel);

            await this._context.SaveChangesAsync();

            return CreatedAtAction("AddSkillLevel", new { id = skillLevel.Id }, skillLevel);
        }

        [HttpPost]
        [Route("all")]
        // POST : /api/skills/all
        public async Task<ActionResult<Skill>> CreateSkill(Skill skill)
        {
            this._context.Skills.Add(skill);

            await this._context.SaveChangesAsync();

            return CreatedAtAction("CreateSkill", new { id = skill.Id }, skill);
        }

        [HttpGet]
        [Route("all")]
        // GET : /api/skills/all
        public async Task<ActionResult<IEnumerable<Skill>>> GetAllSkills()
        {
            return await this._context.Skills.ToListAsync();
        }
    }
}
