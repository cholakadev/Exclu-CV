namespace exclucv.Business.Services
{
    using System;
    using exclucv.Core.Http;
    using exclucv.Core.ServiceContracts;
    using exclucv.Data.Contracts.RepositoryContracts;
    using exclucv.Security.UserSecurity.Password;

    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            this._repository = repository;
        }

        public void Register(RegisterRequest request)
        {
            if (this._repository.IsExistingUser(request.Email))
                throw new ArgumentException("Registration failed");

            var encodedPassword = PasswordCipher.Encode(request.Password);

            var user = new DomainModel.User();
            user.Id = Guid.NewGuid();
            user.Email = request.Email;
            user.Password = encodedPassword;

            this._repository.Register(user);
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
    }
}
