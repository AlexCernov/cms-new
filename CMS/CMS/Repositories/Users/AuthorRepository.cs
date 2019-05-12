using CMS.Exceptions;
using CMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Data.Entity;

namespace CMS.Repositories.Users
{
    public class AuthorRepository : IUserRepository<Author>
    {
        public Author Add(Author entity)
        {

            entity.Password = Crypto.Hash(entity.Password);

            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    entity.Role = context.Roles.FirstOrDefault(x => x.Type == "Author");

                    context.Authors.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
        }

        public IList<Author> FindAll()
        {
            IList<Author> authors = new List<Author>();
            try
            {
                using (DatabaseContext context = new DatabaseContext())
                {
                    authors = context.Authors.Include(x => x.Role).ToList();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return authors;
        }

        public Author FindByUsername(string username)
        {
            IList<Author> authors = FindAll();

            return authors.SingleOrDefault(x => x.Username == username);
        }

        public Author FindByEmail(string email)
        {
            IList<Author> authors = FindAll();
            return authors.SingleOrDefault(x => x.Email == email);
        }
    }
}