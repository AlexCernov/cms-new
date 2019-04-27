using CMS.Models;
using CMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Services
{
    public class PCMemberService : IUserService<PCMember>
    {
        private readonly IUserRepository<PCMember> pcmemberRepository;

        public PCMemberService(IUserRepository<PCMember> pcmemberRepository) => this.pcmemberRepository = pcmemberRepository;

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
    }
}