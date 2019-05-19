using CMS.Exceptions;
using CMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Data.Entity;

namespace CMS.Repositories.Users
{
    public class PCMemberRepository : IUserRepository<PCMember>
    {
        public PCMember Add(PCMember entity)
        {
            entity.Password = Crypto.Hash(entity.Password);

            try
            {
                using (var context = new DatabaseContext())
                {
                    entity.Role = context.Roles.FirstOrDefault(x => x.Type == "Member");
                    context.PCMembers.Add(entity);
                    context.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return entity;
        }

        public IList<PCMember> FindAll()
        {
            IList<PCMember> pcmembers = new List<PCMember>();
            try
            {
                using (var context = new DatabaseContext())
                {

                    pcmembers = context.PCMembers.Include(x => x.Role).ToList();
                }
            }
            catch (System.Exception e)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return pcmembers;
        }

        public PCMember FindByUsername(string username)
        {
            IList<PCMember> pcmembers = FindAll();

            return pcmembers.SingleOrDefault(x => x.Username == username);
        }

        public PCMember FindByEmail(string email)
        {
            IList<PCMember> pCMembers = FindAll();
            return pCMembers.SingleOrDefault(x => x.Email == email);
        }
    }
}