using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using CMS.Services.Entities;
using CMS.Services.Users;

namespace CMS.ViewModels
{
    public class CreateComiteeViewModel : ICreateEntityViewModel<Comitee>
    {
        public Comitee Comitee { get; set; }
        public ICollection<PCMember> PCMembers;
        public IEnumerable<string> rawPCMembers { get; set; }

        public string Message { get; set; }
        public bool Status { get; set;  }
        public string Title { get; set; }

        public CreateComiteeViewModel()
        {
            Message = null;
            Title = "Create";
        }

        public bool CheckEntity(IEntityService<Comitee> service, Comitee entity)
        {
            try
            {
                entity = service.Add(entity);
            }
            catch
            {
                throw ;
            }

            return true;
        }

        private ICollection<PCMember> collectionConverter() { throw new NotImplementedException(); }

        public void addComitee(bool modelState, ComiteeService service)
        {
            if (modelState)
            {
                try
                {
                    var comitee = new Comitee(Comitee.Name, PCMembers);
                    Status = CheckEntity(service, comitee);
                }
                catch (InternetException ex)
                {
                    Message = ex.Message;
                    Status = false;
                    return;
                }
                catch (DatabaseException ex)
                {
                    Message = ex.Message;
                    Status = false;
                    return;
                }

                Message = " Registration successful!\n";
                Status = true;
            }
            else
            {
                Message = " Invalid request!\n";
                Status = false;
            }
        }

        public CreateComiteeViewModel(bool modelState, Comitee comitee, ComiteeService service)
        {
           
        }
    }
}