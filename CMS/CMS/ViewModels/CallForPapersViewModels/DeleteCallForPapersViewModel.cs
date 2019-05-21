using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using CMS.Services.Entities;

namespace CMS.ViewModels.CallForPapersViewModels
{
    public class DeleteCallForPapersViewModel : IDeleteEntityViewModel<CallForPapers>
    {
        public CallForPapers callforpaper;

        public string Message { get; }
        public bool Status { get; }
        public string Title { get; }

        public DeleteCallForPapersViewModel()
        {
            Message = null;
            Title = "Delete";
        }

        public bool CheckEntity(IEntityService<CallForPapers> service, CallForPapers entity)
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


        public DeleteCallForPapersViewModel(bool isValid, CallForPapers callforpaper, CallForPaperService service)
        {
            if (isValid)
            {
                try
                {
                    Status = CheckEntity(service, callforpaper);
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