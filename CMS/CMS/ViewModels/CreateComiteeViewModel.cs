using System;
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
        public Comitee Comitee;
        public PCMember PCMember;
        public ICollection<PCMember> PCMembers;

        public string Message { get; }
        public bool Status { get; }
        public string Title { get; }

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
                throw;
            }

            return true;
        }



        public CreateComiteeViewModel(bool modelState, Comitee comitee, ComiteeService service)
        {
            if (modelState)
            {
                try
                {
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
    }
}