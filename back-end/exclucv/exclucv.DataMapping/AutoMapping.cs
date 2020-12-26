namespace exclucv.DataMapping
{
    using AutoMapper;
    using exclucv.DAL.Entities;
    using exclucv.DomainModels.DomainModels;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, RegisterModelResponse>();
        }
    }
}
