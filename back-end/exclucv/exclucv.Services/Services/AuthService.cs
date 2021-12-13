namespace exclucv.Core.Services
{
    using exclucv.Core.Http;
    using exclucv.Security.UserSecurity.Password;
    using System;
    using System.Threading.Tasks;
    using exclucv.Core.ServiceContracts;
    using exclucv.Data.RepositoryContracts;
    using AutoMapper;
    using exclucv.Domain.DomainModel;

    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
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

        public async Task<User> Register(RegisterRequest request)
        {
            if (!this._repository.IsExistingUser(request.Email))
            {
                request.Password = PasswordCipher.Encode(request.Password);
                var userSource = new User();
                userSource.Id = Guid.NewGuid();
                userSource.Email = request.Email;
                //var userEntity = this._mapper.Map<User, DomainModel.User>()
                //var registereduser = await this._repository.Register(user);
                //this._templateservice.createtemplate(user.id);

                return new User();
            }
            else
            {
                throw new Exception("Email is already taken.");
            }
        }
    }
}
