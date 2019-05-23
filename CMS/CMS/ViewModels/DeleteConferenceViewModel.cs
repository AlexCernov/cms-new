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
    public class DeleteConferenceViewModel 
    {
        public Conference conference { get; set; }

        public string Message { get; }
        public bool Status { get; }
        public string Title { get; }

        public DeleteConferenceViewModel(int id, IEntityService<Conference> conferenceService)
        {
            conference = conferenceService.FindById(id);
            DeleteConference(conference, conferenceService);
        }

        private void DeleteConference(Conference conference, IEntityService<Conference> conferenceService)
        {
            
            conferenceService.Delete(conference);
        }

        /*
        public DeleteConferenceViewModel(Conference conference)
        {
            this.conference = conference;
        }

        public DeleteConferenceViewModel()
        {
            Message = null;
            Title = "Delete";
        }

        public bool CheckEntity(IEntityService<Conference> service, Conference entity)
        {
            try
            {
                entity = service.Delete(entity);
            }
            catch
            {
                throw;
            }

            return true;
        }

        

        public DeleteConferenceViewModel(bool modelState, Conference conference, ConferenceService service)
        {
            if (modelState)
            {
                try
                {
                    Status = CheckEntity(service, conference);
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

                Message = " Delete successful!\n";
                Status = true;
            }
            else
            {
                Message = " Invalid request!\n";
                Status = false;
            }
        }*/
    }
}