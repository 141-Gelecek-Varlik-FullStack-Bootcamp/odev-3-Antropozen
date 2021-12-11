using AutoMapper;
using Demo.DB.Entities.DataContext;
using Demo.Model;
using System.Linq;

namespace Demo.Service.User
{
    public class UserService : IUserService 
    {
        private readonly IMapper mapper;
        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public bool Login(string userName,string userPassword)
        {
            bool result = false;
            using (var srv = new DemoContext())
            {
                result =srv.User.Any(a =>!a.IsDeleted && a.IsActive && a.UserName == userName && a.UserPassword == userPassword);
            }

            return result;
        }


        public General<Model.User.User>Insert(Demo.Model.User.User newUser)
        {
            var result = new General<Model.User.User>(){IsSuccess = false };
            var model = mapper.Map<Demo.DB.Entities.User>(newUser);
            using (var srv = new DemoContext())
            {
                srv.User.Add(model);
                srv.SaveChanges();
                result.Entity = newUser;
                result.IsSuccess = true;
            }
            return result;
        }
    }
}
