using CMS.Models;
using System;
using System.Collections.Generic;

namespace CMS.Repositories.Entities
{
    public class AbstractRepository : IEntityRepository<Abstract>
    {
        public Abstract Add(Abstract entity)
        {
            throw new NotImplementedException();
        }

        public Abstract Delete(Abstract entity)
        {
            throw new NotImplementedException();
        }

        public IList<Abstract> FindAll()
        {
            throw new NotImplementedException();
        }

        public Abstract Update(Abstract enitity)
        {
            throw new NotImplementedException();
        }
    }
}