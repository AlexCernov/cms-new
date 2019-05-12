using CMS.Exceptions;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Repositories.Entities
{
    public class ComiteeRepository : IEntityRepository<Comitee>
    {
        public Comitee Add(Comitee entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Comitees.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
        }

        public Comitee Delete(Comitee entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Comitees.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
        }

        public IList<Comitee> FindAll()
        {
            IList<Comitee> comitees = new List<Comitee>();
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    comitees = context.Comitees.ToList();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }
            return comitees;
        }

        public Comitee Update(Comitee enitity)
        {
            throw new NotImplementedException();
        }
    }
}