namespace exclucv.Controllers
{
    using AutoMapper;
    using exclucv.DAL.Entities;
    using exclucv.DomainModels.DomainModels;
    using exclucv.Errors.ResponseErrors;
    using exclucv.Services.ServiceContracts;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/user")]
    [ApiController]
    public class ApplicationUserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IApplicationUserService _service;

        public ApplicationUserController(IMapper mapper, IApplicationUserService service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [HttpPost]
        [Route("registration")]
        // POST: /api/user/registration
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                var user = new User()
                {
                    UserId = Guid.NewGuid(),
                    Email = model.Email,
                    Password = model.Password
                };
                var registeredUser = this._service.Register(user);
                var mappedUser = this._mapper.Map<User, RegisterModelResponse>(registeredUser);
                return Created(nameof(this.Register), mappedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(406, new AbortedRegistrationError(ex.Message, false));
            }
        }

        [HttpPost]
        [Route("login")]
        // POST : /api/user/login
        public IActionResult Login(DomainModels.DomainModels.LoginModel model)
        {
            try
            {
                var token = this._service.Login(model);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return StatusCode(406, new AbortedRegistrationError(ex.Message, false));
            }
        }

        [HttpGet]
        [Route("currentUser")]
        // POST : /api/user/currentUser
        public ActionResult<DomainModels.DomainModels.UserModel> GetUserInfo()
        {
            Guid userId = this.GetUserId();
            var user = this._service.GetUserInfo(userId);

            var mappedUser = this._mapper.Map<User, UserModel>(user);

            return mappedUser;
        }
    }
}
