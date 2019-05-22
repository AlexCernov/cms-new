using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Services.Users;
using CMS.Models;

namespace CMS.ViewModels.PCMemberViewModels
{
    public class IndexPCMemberViewModel
    {
        public string Username;
        public int ID;

        public string Message { get; set; }
        public bool Status { get; }
        public string Title { get; }

        public IndexPCMemberViewModel()
        {
            Message = null;
            Title = "Welcome";
        }

        public IndexPCMemberViewModel(int id, PCMemberService service)
        {
            ID = id;
            PCMember member = service.FindByID(id);
            Username = member.Username;
        }
    }
}