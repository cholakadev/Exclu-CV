namespace exclucv.Controllers
{
    using exclucv.Core.Http;
    using exclucv.Core.ServiceContracts;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("register")]
        // POST: /api/user/registration
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                var user = await this._service.Register(request);
                return StatusCode(200, new { });
            }
            catch (Exception ex)
            {

                return StatusCode(406);
            }
        }

        //[HttpPost]
        //[Route("login")]
        //// POST : /api/user/login
        //public IActionResult Login(DomainModels.LoginModel model)
        //{
        //    try
        //    {
        //        var token = "token"; //this._service.Login(model);
        //        return Ok(new { token });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(406, new AbortedRegistrationError(ex.Message, false));
        //    }
        //}

        //[HttpGet]
        //[Route("currentUser")]
        //// POST : /api/user/currentUser
        //public ActionResult<DomainModels.DomainModels.UserModel> GetUserInfo()
        //{
        //    Guid userId = this.GetUserId();
        //    var user = this._service.GetUserInfo(userId);

        //    //var mappedUser = this._mapper.Map<User, UserModel>(user);

        //    return mappedUser;
        //}
    }
}
