using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using CMS.Services.Entities;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CMS.ViewModels.ComiteeViewModels
{
    public class CreateComiteeViewModel : ICreateEntityViewModel<Comitee>
    {
        public Comitee Comitee { get; set; }
        public ICollection<PCMember> PCMembers { get; set; }
        public string rawPCMembers { get; set; }

        public string Message { get; set; }
        public bool Status { get; set; }
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
                throw;
            }

            return true;
        }

        private void collectionConverter(string collection) {
            string[] members = collection.Split(',');
            PCMembers = new List<PCMember>();
            for (int i = 0; i < members.Length - 1; i++)
            {
                using (var db = new DatabaseContext())
                {
                    var username = members[i];
                    var pcmember = db.PCMembers.Include("Role").FirstOrDefault(x => x.Username == username);
                    PCMembers.Add(pcmember);
                }
            }
        }

        public void addComitee(bool modelState, ComiteeService service)
        {
            if (modelState)
            {
                try
                {
                    collectionConverter(rawPCMembers);
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