using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using CMS.Services.Entities;

namespace CMS.ViewModels.ComiteeViewModels
{
    public class DeleteComiteeViewModel : IDeleteEntityViewModel<Comitee>
    {
        public Comitee comitee { get; set; }

        public string Message { get; }
        public bool Status { get; }
        public string Title { get; }

        public DeleteComiteeViewModel()
        {
            Message = null;
            Title = "Delete";
        }

        public bool CheckEntity(IEntityService<Comitee> service, Comitee entity)
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



        public DeleteComiteeViewModel(bool modelState, Comitee comitee, ComiteeService service)
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