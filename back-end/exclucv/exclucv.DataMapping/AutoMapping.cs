namespace exclucv.DataMapping
{
    using AutoMapper;
    using exclucv.Data.Models;
    using System.Collections.Generic;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Data.Models.User, DomainModel.RegisterModelResponse>();

            //CreateMap<User, User>();

            CreateMap<Skill, DomainModel.Skill>();
            CreateMap<List<Skill>, List<DomainModel.Skill>>();

            CreateMap<Education, Education>();
            CreateMap<Education, Education>();
            CreateMap<List<Education>, List<Education>>();
            CreateMap<List<Education>, List<Education>>();
        }
    }
}
