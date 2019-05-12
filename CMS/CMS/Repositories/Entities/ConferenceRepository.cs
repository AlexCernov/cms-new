using CMS.Exceptions;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Repositories.Entities
{
    public class ConferenceRepository : IEntityRepository<Conference>
    {
        public Conference Add(Conference entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Conferences.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
            
        }

        public Conference Delete(Conference entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Conferences.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
        }

        public IList<Conference> FindAll()
        {
            IList<Conference> conferences = new List<Conference>();
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    conferences = context.Conferences.ToList();
                
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }
            return conferences;
        }

        public Conference Update(Conference entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Conferences.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
        }
    }
}