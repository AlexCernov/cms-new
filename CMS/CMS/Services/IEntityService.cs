using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Services
{
    public interface IEntityService<T>
    {
        // IF ANYTHING EXTRA MUST BE ADDED WILL BE IMPLEMENTED LATER

        T Add(T entity);

        T Delete(T entity);

        T Update(T enitity);

        IList<T> FindAll();
    }
}