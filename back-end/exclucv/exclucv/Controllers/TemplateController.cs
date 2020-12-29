namespace exclucv.Controllers
{
    using AutoMapper;
    using exclucv.DAL.Entities;
    using exclucv.DomainModels.DomainModels;
    using exclucv.Services.ServiceContracts;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/template")]
    [ApiController]
    public class TemplateController : BaseController
    {
        private readonly ISkillsService _skillsService;
        private readonly IMapper _mapper;

        public TemplateController(ISkillsService skillsService, IMapper mapper)
        {
            this._skillsService = skillsService;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("skill/delete")]
        public ActionResult<Guid> DeleteSkill(Guid skillId)
        {
            var userId = this.GetUserId();
            this._skillsService.DeleteSkill(userId, skillId);
            return userId;
        }

        [HttpPost]
        [Route("skill/add")]
        public ActionResult<Guid> AddSkill(Skill skill)
        {
            var userId = this.GetUserId();
            return this._skillsService.AddSkill(userId, skill);
        }

        [HttpGet]
        [Route("skill/all")]
        public ActionResult<IEnumerable<SkillModel>> GetAllSkills()
        {
            try
            {
                var userId = this.GetUserId();
                var skills = this._skillsService.GetAllSkills(userId).ToList();

                var mappedSkills = this._mapper.Map<IEnumerable<Skill>, IEnumerable<SkillModel>>(skills);
                return mappedSkills.ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
