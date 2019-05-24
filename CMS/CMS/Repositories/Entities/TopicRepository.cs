using CMS.Exceptions;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Repositories.Entities
{
    public class TopicRepository : IEntityRepository<Topic>
    {
        public Topic Add(Topic entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Topics.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;

        }

        public Topic Delete(Topic entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    context.Topics.Remove(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
        }

        public IList<Topic> FindAll()
        {
            IList<Topic> topics = new List<Topic>();
            try
            {
                using (var context = new DatabaseContext())
                {
                    topics = context.Topics.ToList();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return topics;
        }

        public Topic Update(Topic entity)
        {
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    var result = context.Topics.SingleOrDefault(c => c.Id == entity.Id);
                    if (result != null)
                    {
                        result.Id = entity.Id;
                        result.Name = entity.Name;
                        result.Description = entity.Description;
                        context.SaveChanges();
                    }
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