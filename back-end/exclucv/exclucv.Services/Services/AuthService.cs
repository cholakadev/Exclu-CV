namespace exclucv.Core.Services
{
    using exclucv.Core.Http;
    using exclucv.Security.UserSecurity.Password;
    using System;
    using System.Threading.Tasks;
    using exclucv.Core.ServiceContracts;
    using exclucv.Data.RepositoryContracts;

    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            this._repository = repository;
        }

        //public string Login(LoginModel loginModel)
        //{
        //    if (!this._repository.IsExistingUser(loginModel.Email))
        //    {
        //        throw new Exception("User is not existing.");
        //    }

        //    var user = this._repository.GetUserByEmail(loginModel.Email);

        //    if (loginModel.Password != PasswordCipher.Decode(user.Password))
        //    {
        //        throw new Exception("Incorrect password!");
        //    }

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim("UserID", user.UserId.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(1),
        //        SigningCredentials = new SigningCredentials(
        //            new SymmetricSecurityKey(
        //             Encoding.UTF8
        //             .GetBytes(this._appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //    var token = tokenHandler.WriteToken(securityToken);
        //    return token;
        //}

        public async Task<DomainModel.User> Register(RegisterRequest request)
        {
            if (!this._repository.IsExistingUser(request.Email))
            {
                request.Password = PasswordCipher.Encode(request.Password);
                //var registeredUser = await this._repository.Register(user);
                //this._templateService.CreateTemplate(user.Id);

                return new DomainModel.User();
            }
            else
            {
                throw new Exception("Email is already taken.");
            }
        }
    }
}
