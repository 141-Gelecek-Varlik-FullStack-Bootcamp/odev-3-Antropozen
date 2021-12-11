using Demo.DB.Entities.DataContext;
using System.Linq;

namespace Demo.Service.User
{
    public class UserService
    {
        public bool Login(string userName,string userPassword)
        {
            bool result = false;
            using (var srv = new DemoContext())
            {
                result =srv.User.Any(a =>!a.IsDeleted && a.IsActive && a.UserName == userName && a.UserPassword == userPassword);
            }

            return result;
        }

        public void Insert()
        {
            var newUser = new Demo.DB.Entities.User();
            using (var srv = new DemoContext())
            {
                srv.User.Add(newUser);
                srv.SaveChanges();
            }
        }
    }
}
