using APINetCoreDemo.Model;
using System.Collections.Generic;

namespace APINetCoreDemo.Services
{
    public interface IDomainService
    {
        Domain FindById(long id);
        List<Domain> FindAll();
    }
}
