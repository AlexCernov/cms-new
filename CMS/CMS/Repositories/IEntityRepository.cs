using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    public interface IEntityRepository<T>
    {
        T Add(T entity);

        T Delete(T entity);

        T Update(T enitity);

        IList<T> FindAll();

    }
}
