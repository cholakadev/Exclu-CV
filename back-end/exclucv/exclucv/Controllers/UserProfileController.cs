namespace exclucv.Controllers
{
    using exclucv.DAL.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/user")] // profile
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpGet]
        [Route("profile")]
        [Authorize]
        // GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var user = await this._userManager.FindByIdAsync(userId);

            return new
            {
                user.UserName,
                user.Email,
                user.ProfileImage
            };
        }
    }
}
