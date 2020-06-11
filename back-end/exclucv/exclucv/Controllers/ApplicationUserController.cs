namespace exclucv.Controllers
{
    using exclucv.DAL.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    [Route("api/user")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;

        public ApplicationUserController(UserManager<ApplicationUser> userManager,
                                         SignInManager<ApplicationUser> signInManager,
                                         IOptions<ApplicationSettings> appSettings)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("registration")]
        // POST: /api/user/registration
        public async Task<Object> Register(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                // We dont specify the password here because it should be encrypted.
                UserName = model.UserName,
                Email = model.Email
            };

            try
            {
                var result = await this._userManager.CreateAsync(applicationUser, model.Password); // Here we pass the password.
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("login")]
        // POST : /api/user/login
        public async Task<IActionResult> Login(LoginModel model)
        {
            // Find the user by username from the model which is comming from the FE form.
            var user = await _userManager.FindByNameAsync(model.UserName);

            var userId = user.Id;

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(
                         Encoding.UTF8
                         .GetBytes(this._appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect." });
            }
        }
    }
}
