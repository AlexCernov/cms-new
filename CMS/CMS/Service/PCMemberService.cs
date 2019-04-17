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


        public bool EmailExists(string email)
        {
            return pcmemberRepository.FindByEmail(email) != null;
        }

        public IList<PCMember> FindAll()
        {
            return pcmemberRepository.FindAll();
        }

		public PCMember findByEmail(string email)
		{
			return pcmemberRepository.FindByEmail(email);
		}

        public bool UsernameExists(string username)
        {
            return pcmemberRepository.FindByUsername(username) != null;

        }

		PCMember IPCMemberService.Add(PCMember addedPCMember)
		{
			throw new NotImplementedException();
		}

		bool IPCMemberService.EmailExists(string email)
		{
			throw new NotImplementedException();
		}

		IList<PCMember> IPCMemberService.FindAll()
		{
			throw new NotImplementedException();
		}

		PCMember IPCMemberService.FindByEmail(string email)
		{
			throw new NotImplementedException();
		}

		bool IPCMemberService.UsernameExists(string username)
		{
			throw new NotImplementedException();
		}
	}
}