namespace exclucv.Controllers
{
    using exclucv.Core.Http;
    using exclucv.Core.ServiceContracts;
    using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Register(RegisterRequest request)
        {
            this._service.Register(request);
            return StatusCode(200);
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
