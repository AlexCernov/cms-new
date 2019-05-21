using CMS.Exceptions;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CMS.Repositories.Entities
{
    public class PaperRepository : IEntityRepository<Paper>
    {

       

        public Paper Add(Paper entity)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.Papers.Add(entity);
                    db.SaveChanges();

                }
            }
            catch (System.Exception)
            {

                throw new DatabaseException("Cannot connect to the database");
            }
            return entity;
        }

        public Paper Delete(Paper entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Papers.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
        }

        public IList<Paper> FindAll()
        {
            IList<Paper> papers = new List<Paper>();
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    papers = context.Papers.ToList();

                }
            }
            catch (System.Exception e)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }
            return papers;
        }

        public Paper Update(Paper entity)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {

                throw new DatabaseException("Could not connect" + e.Message);
            }

            return entity;
        }
    }
}