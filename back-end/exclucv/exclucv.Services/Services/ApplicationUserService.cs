namespace exclucv.Services.Services
{
    using exclucv.DAL.Entities;
    using exclucv.DAL.Models;
    using exclucv.Repository.RepositoryContracts;
    using exclucv.Security.UserSecurity.Password;
    using exclucv.Services.ServiceContracts;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using LoginModel = DomainModels.DomainModels.LoginModel;

    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _repository;
        private readonly ApplicationSettings _appSettings;

        public ApplicationUserService(IApplicationUserRepository repository, IOptions<ApplicationSettings> appSettings)
        {
            this._repository = repository;
            this._appSettings = appSettings.Value;
        }

        public string Login(LoginModel loginModel)
        {
            if (!this._repository.IsExistingUser(loginModel.Email))
            {
                throw new Exception("User is not existing.");
            }

            var user = this._repository.GetUserByEmail(loginModel.Email);

            if (loginModel.Password != PasswordCipher.Decode(user.Password))
            {
                throw new Exception("Incorrect password!");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserID", user.UserId.ToString())
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

            return token;
        }

        public User Register(User user)
        {
            if (this._repository.IsExistingUser(user.Email) == false)
            {
                user.Password = PasswordCipher.Encode(user.Password);
                return this._repository.Register(user);
            }
            else
            {
                throw new System.Exception("Email is already taken.");
            }
        }
    }
}
