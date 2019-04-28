using CMS.Models;
using CMS.Repositories;
using System.Collections.Generic;

namespace CMS.Services.Users
{
    public class PCMemberService : IUserService<PCMember>
    {
        private readonly IUserRepository<PCMember> pcmemberRepository;

        public PCMemberService(IUserRepository<PCMember> pcmemberRepository)
        {
            this.pcmemberRepository = pcmemberRepository;
        }

        public PCMember Add(PCMember entity)
        {
            return pcmemberRepository.Add(entity);

        }

        public IList<PCMember> FindAll()
        {
            return pcmemberRepository.FindAll();

        }

        public PCMember FindByUsername(string username)
        {
            return pcmemberRepository.FindByUsername(username);
        }

        public bool UsernameExists(string username)
        {
            return pcmemberRepository.FindByUsername(username) != null;

        }

        public bool EmailExists(string email)
        {
            return pcmemberRepository.FindByEmail(email) != null;
        }
    }
}