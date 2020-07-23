using APINetCoreDemo.Model;
using System.Collections.Generic;

namespace APINetCoreDemo.Services
{
    public interface IUserService
    {
        User Create(User user);
        User FindById(long id);
        List<User> FindAll();
        User Update(User user);
        void Delete (long id);
    }
}
