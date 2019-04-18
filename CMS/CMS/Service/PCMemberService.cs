using CMS.Models;
using CMS.Repository;
using System.Collections.Generic;
using System;

namespace CMS.Service
{
    public class PCMemberService : IPCMemberService
    {
        private readonly IPCMemberRepository pcmemberRepository;

        public PCMemberService(IPCMemberRepository pcmemberRepository)
        {
            this.pcmemberRepository = pcmemberRepository;
        }

		string IPCMemberService.f
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public PCMember Add(PCMember addedPCMember)
        {
            return pcmemberRepository.Add(addedPCMember);
        }


        public IList<PCMember> FindAll()
        {
            return pcmemberRepository.FindAll();
        }

        public bool UsernameExists(string username)
        {
            return pcmemberRepository.FindByUsername(username) != null;

        }

        public bool EmailExists(string email)
        {
            return pcmemberRepository.FindByEmail(email) != null;

        }

        public PCMember FindByUsername(string username)
        {
            return pcmemberRepository.FindByUsername(username);
        }

    }
}