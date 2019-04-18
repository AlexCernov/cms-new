using CMS.Models;
using System.Collections.Generic;

namespace CMS.Service
{
    public interface IPCMemberService
    {
		string f { get; set; }

		PCMember Add(PCMember addedPCMember);
        bool UsernameExists(string username);
        bool EmailExists(string email);
		PCMember FindByUsername(string username);
		IList<PCMember> FindAll();
    }
}
