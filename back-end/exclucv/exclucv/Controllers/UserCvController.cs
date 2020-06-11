namespace exclucv.Controllers
{
    using exclucv.DAL.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/user")]
    [ApiController]
    public class UserCvController : BaseController
    {
        private readonly ExclucvDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserCvController(ExclucvDbContext context,
                                SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        [HttpGet]
        [Route("cv")]
        [Authorize]
        // GET : /api/user/cv
        public async Task<IEnumerable<CvViewModel>> CVs()
        {
            var userId = this.User.Claims.FirstOrDefault(claimRecord => claimRecord.Type == "UserID").Value;

            return await ByUser(userId);
        }

        public async Task<IEnumerable<CvViewModel>> ByUser(string userId)
            => await this._context
            .CVs
            .Where(c => c.ApplicationUserId == userId)
            .Select(c => new CvViewModel
            {
                Id = c.Id,
                DateOfCreation = c.DateOfCreation,
                MainInformation = c.MainInformation,
                Skill = c.Skill,
                Education = c.Education,
                WorkExperience = c.WorkExperience
            })
            .ToListAsync();

        [HttpPost]
        [Route("cv")]
        [Authorize]
        // POST : /api/user/cv
        public async Task<ActionResult<CvModel>> CreateCv(CvModel cv)
        {
            if (User == null || cv == null)
            {
                return BadRequest();
            }

            var userId = this.User.Claims.FirstOrDefault(claimRecord => claimRecord.Type == "UserID").Value;

            cv.ApplicationUserId = userId;

            cv.DateOfCreation = DateTime.Now.ToString("MM/dd/yyyy");

            this._context.CVs.Add(cv);

            await this._context.SaveChangesAsync();

            return CreatedAtAction("CreateCv", new { id = cv.Id }, cv);
        }

        [Authorize]
        [HttpDelete("cv/{id}")]
        // DELETE: /api/user/cv/1
        public async Task<ActionResult<CvModel>> DeleteCv(int id)
        {
            var cv = await _context.CVs.FindAsync(id);

            if (cv == null)
            {
                return NotFound();
            }

            this._context.CVs.Remove(cv);
            await this._context.SaveChangesAsync();

            return cv;
        }
    }
}
