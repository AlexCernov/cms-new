using CMS.Exception;
using CMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;

namespace CMS.Repository
{
    public class PCMemberRepository : IPCMemberRepository
    {

        public PCMember Add(PCMember addedPCMember)
        {
            addedPCMember.Password = Crypto.Hash(addedPCMember.Password);

            try
            {
                using (var context = new DatabaseContext())
                {
                    addedPCMember.Role = context.Roles.FirstOrDefault(t => t.Type == "Member");

                    context.PCMembers.Add(addedPCMember);
                    context.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw new DatabaseException("Cannot connect to Database!\n");
            }

            return addedPCMember;
        }

        public IList<PCMember> FindAll()
        {
            IList<PCMember> pcmembers = new List<PCMember>();
            try
            {
                using (var context = new DatabaseContext())
                {
                    pcmembers = context.PCMembers.ToList();
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
    }
}