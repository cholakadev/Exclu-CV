namespace exclucv.Controllers
{
    using AutoMapper;
    using exclucv.DAL.Entities;
    using exclucv.Services.ServiceContracts;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/education")]
    [ApiController]
    public class EducationController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IEducationService _service;

        public EducationController(IMapper mapper, IEducationService service)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddEducations(List<Education> educations)
        {
            throw new NotImplementedException();
        }
    }
}
