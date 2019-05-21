using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using CMS.Services.Entities;

namespace CMS.ViewModels.ConferenceViewModels
{
    public class DeleteConferenceViewModel : IDeleteEntityViewModel<Conference>
    {
        public Conference conference;

        public string Message { get; }
        public bool Status { get; }
        public string Title { get; }

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
        }
    }
}