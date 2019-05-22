using System;
using CMS.Models;
using CMS.Services;
using CMS.Services.Entities;
using CMS.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CMS.ViewModels
{
	public class CreateCallForPapersViewModel : ICreateEntityViewModel<CallForPapers>
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(10)]
        public string Acronym { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter the issued date.")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter the issued date.")]
        public DateTime DeadlineAbstract { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter the issued date.")]
        public DateTime DeadlineProposal { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public string Message { get; }
		public bool Status { get; }
		public string Title { get; }

		public CreateCallForPapersViewModel()
		{
			Message = null;
			Title = "Create";
		}

		public bool CheckEntity(IEntityService<CallForPapers> service, CallForPapers entity)
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

		public CreateCallForPapersViewModel(bool modelState, CallForPapers callforpaper, CallForPaperService service)
		{
            if (modelState)
            {
                try
                {
                    Status = CheckEntity(service,callforpaper);
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