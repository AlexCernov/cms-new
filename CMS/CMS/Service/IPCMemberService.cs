using CMS.Models;
using System.Collections.Generic;

namespace CMS.Service
{
    public interface IPCMemberService
    {
		PCMember Add(PCMember addedPCMember);
        bool EmailExists(string email);
        bool UsernameExists(string username);
		PCMember FindByEmail(string email);
		IList<PCMember> FindAll();
    }
}
