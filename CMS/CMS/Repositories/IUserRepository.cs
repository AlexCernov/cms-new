using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    public interface IUserRepository<T> 
    {
        T Add(T entity);
        T FindByUsername(string username);
        T FindByEmail(string email);
        IList<T> FindAll();
    }
}
