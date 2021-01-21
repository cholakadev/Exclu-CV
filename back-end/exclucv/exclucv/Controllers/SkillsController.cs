namespace exclucv.Controllers
{
    using AutoMapper;
    using exclucv.DAL.Entities;
    using exclucv.Services.ServiceContracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/skills")]
    [ApiController]
    public class SkillsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISkillsService _service;

        public SkillsController(IMapper mapper, ISkillsService service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [HttpPost]
        [Route("add")]
        // POST : /api/skills/all
        public ActionResult<Skill> CreateSkill(Skill skill)
        {
            var userId = this.GetUserId();
            this._service.AddSkill(userId, skill);

            return CreatedAtAction("CreateSkill", new { id = skill.SkillId }, skill);
        }

        [HttpGet]
        [Route("all")]
        // GET : /api/skills/all
        public ActionResult<IEnumerable<Skill>> GetAllSkills()
        {
            var userId = this.GetUserId();
            var skills = this._service.GetAllSkills(userId);

            return skills.ToList();
        }
    }
}
