namespace exclucv.Controllers
{
    using AutoMapper;

    public class EducationController : BaseController
    {
        private readonly IMapper _mapper;

        public EducationController(IMapper mapper)
        {
            this._mapper = mapper;
        }
    }
}
