using AutoMapper;

namespace Demo.API.Infrastructure
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Demo.Model.User.User, Demo.DB.Entities.User>();
            CreateMap<Demo.DB.Entities.User, Demo.Model.User.User>();
        }
    }
}
