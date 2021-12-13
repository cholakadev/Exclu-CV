namespace exclucv.Data
{
    using AutoMapper;
    using exclucv.Data.Models;
    using System.Collections.Generic;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Education, Education>();
            CreateMap<Education, Education>();
            CreateMap<List<Education>, List<Education>>();
            CreateMap<List<Education>, List<Education>>();
        }
    }
}
