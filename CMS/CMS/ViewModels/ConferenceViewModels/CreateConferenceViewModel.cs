using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using CMS.Services.Entities;

namespace CMS.ViewModels.ConferenceViewModels
{
    public class CreateConferenceViewModel : ICreateEntityViewModel<Conference>
    {
        public Conference conference;

        public string Message { get; }
        public bool Status { get; }
        public string Title { get; }

        public CreateConferenceViewModel()
        {
            Message = null;
            Title = "Create";
        }

        public bool CheckEntity(IEntityService<Conference> service, Conference entity)
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



        public CreateConferenceViewModel(bool modelState, Conference conference, ConferenceService service)
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