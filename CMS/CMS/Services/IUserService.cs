using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services
{
    public interface IUserService<T>
    {
        T Add(T entity);
        bool UsernameExists(string username);
        bool EmailExists(string email);
        T FindByUsername(string username);
        IList<T> FindAll();
    }
}
