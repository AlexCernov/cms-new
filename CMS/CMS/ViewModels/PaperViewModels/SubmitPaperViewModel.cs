using CMS.Models;
using CMS.Services;
using System;
using System.IO;
using System.Linq;
using System.Web;
namespace CMS.ViewModels.PaperViewModels
{
    public class SubmitPaperViewModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public string Title { get; }
        public HttpPostedFileBase File { get; set; }

        public int CallForPapersId { get; set; }

        private CallForPapers CallForPapers;

        public SubmitPaperViewModel()
        {

        }

        public SubmitPaperViewModel(int id)
        {
            Message = null;
            Status = true;
            Title = "Submit paper";

            CallForPapersId = id;

            using (var database = new DatabaseContext())
            {
                CallForPapers = database.CallsForPapers.FirstOrDefault(t => t.Id == CallForPapersId);
            }



            if (DateTime.Compare(CallForPapers.DeadlineProposal, DateTime.Now) == -1)
            {
                Status = false;
                Message = "We are sorry to inform you, but the deadline for the conference " + CallForPapers.Name + " has passed(" + CallForPapers.DeadlineProposal + "). You can no longer submit papers";

            }

        }



        public void Upload(IEntityService<Paper> service)
        {
            Status = true;
            using (var database = new DatabaseContext())
            {
                CallForPapers = database.CallsForPapers.FirstOrDefault(t => t.Id == CallForPapersId);
            }
            string path = saveFile();
            if (path != null)
            {
                Paper paper = new Paper(CallForPapers, path);
                try
                {
                    service.Add(paper);
                    Status = true;


                }
                catch (Exception)
                {
                    Status = false;
                    Message = "An error occured while adding the paper";
                    throw;
                }
            }
        }

        private string saveFile()
        {
            if (File != null && File.ContentLength > 0)
            {
                // extract only the filename
                string fileName = Path.GetFileName(File.FileName);
                // store the file inside ~/App_Data/uploads folder
                string path = Path.Combine("/App_Data/uploads", CallForPapers.Name, fileName);
                File.SaveAs(path);
                return path;
            }
            else
            {
                Status = false;
                Message = "Error while trying to upload file: File is null or has no content";
                return null;
            }
        }
    }
}