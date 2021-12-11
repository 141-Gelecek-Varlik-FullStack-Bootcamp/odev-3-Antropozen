using AutoMapper;

namespace Demo.API.Infrastructure
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //  DB classı ile  ViewModelin map'leneceğini ayarlandığı kısım
            CreateMap<Demo.Model.User.User, Demo.DB.Entities.User>();
            CreateMap<Demo.DB.Entities.User, Demo.Model.User.User>();

            CreateMap<Demo.Model.Product.Product, Demo.DB.Entities.Product>();
            CreateMap<Demo.DB.Entities.Product, Demo.Model.Product.Product>();
        }
    }
}
