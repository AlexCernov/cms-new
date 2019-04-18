
using CMS.Models;
using CMS.Service;

namespace CMS.ViewModels
{
    public interface IRegistrationViewModel
    {
        bool CheckUser(IPCMemberService pcmemberService, PCMember pcmember);
	}
}