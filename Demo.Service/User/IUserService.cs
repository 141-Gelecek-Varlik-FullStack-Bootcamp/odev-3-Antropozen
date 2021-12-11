using Demo.Model;
namespace Demo.Service.User
{
    public interface IUserService
    {
        public General<Demo.Model.User.User> Insert(Demo.Model.User.User newUser);
    }
}
