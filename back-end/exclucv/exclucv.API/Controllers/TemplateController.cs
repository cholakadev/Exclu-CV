namespace exclucv.Controllers
{
    using exclucv.Services.ServiceContracts;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/template")]
    [ApiController]
    public class TemplateController : BaseController
    {
        private readonly ITemplateService _service;

        public TemplateController(ITemplateService service)
        {
            this._service = service;
        }

        //[HttpPost]
        //[Route("skill/delete")]
        //public ActionResult<Guid> DeleteSkill(DeleteSkillRequest deleteSkillReq)
        //{
        //    var userId = this.GetUserId();
        //    Guid deletedSkillId = this._service.DeleteSkill(userId, deleteSkillReq.SkillId);

        //    return Ok(new SuccessfullyDeletedNotification($"Successfully deleted skill with id {deletedSkillId}"));
        //}

        //[HttpPost]
        //[Route("skill/add")]
        //public ActionResult<Guid> AddSkill(Skill skill)
        //{
        //    var userId = this.GetUserId();
        //    return this._skillsService.AddSkill(userId, skill);
        //}

        //[HttpGet]
        //[Route("skill/all")]
        //public ActionResult<IEnumerable<SkillModel>> GetAllSkills()
        //{
        //    try
        //    {
        //        var userId = this.GetUserId();
        //        var skills = this._skillsService.GetAllSkills(userId).ToList();

        //        var mappedSkills = this._mapper.Map<IEnumerable<Skill>, IEnumerable<SkillModel>>(skills);
        //        return mappedSkills.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(700, new ApiError(700, ex.Message));
        //    }
        //}
    }
}
