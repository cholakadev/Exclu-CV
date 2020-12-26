namespace exclucv.Controllers
{
    using AutoMapper;
    using exclucv.DAL.Entities;
    using exclucv.DomainModels.DomainModels;
    using exclucv.Services.ServiceContracts;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/user")]
    [ApiController]
    public class ApplicationUserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IApplicationUserService _service;

        public ApplicationUserController(IMapper mapper,
                                         IApplicationUserService service)
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

                return Ok(new { message = "Successfully registered user", mappedUser });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
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
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
