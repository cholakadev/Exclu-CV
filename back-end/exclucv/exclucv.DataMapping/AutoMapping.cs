namespace exclucv.DataMapping
{
    using AutoMapper;
    using exclucv.Data.Models;
    using exclucv.DomainModels.DomainModels;
    using System.Collections.Generic;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, RegisterModelResponse>();

            CreateMap<User, UserModel>();

            CreateMap<Skill, SkillModel>();
            CreateMap<List<Skill>, List<SkillModel>>();

            CreateMap<Education, EducationModel>();
            CreateMap<EducationModel, Education>();
            CreateMap<List<Education>, List<EducationModel>>();
            CreateMap<List<EducationModel>, List<Education>>();
        }
    }
}
