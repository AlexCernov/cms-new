using CMS.Exceptions;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Repositories.Entities
{
    public class ConferenceRepository 
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

        public void Delete(Conference entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Conferences.Attach(entity);
                    context.Conferences.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            
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

        public Conference FindById(int? id)
        {
            Conference entity;
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    entity = context.Conferences.FirstOrDefault(x => x.Id == id);
                } 
            }
            catch (System.Exception e)
            {
               // Logger.Info(e.Message);
                throw new DatabaseException("Cannot connect to database!\n");
            }

            return entity;
        }
    }
}