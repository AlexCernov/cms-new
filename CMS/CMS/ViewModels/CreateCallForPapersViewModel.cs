using System;
using CMS.Models;
using CMS.Services;
using CMS.Services.Entities;
using CMS.Exceptions;

namespace CMS.ViewModels
{
	public class CreateCallForPapersViewModel : ICreateEntityViewModel<CallForPapers>
	{
		public CallForPapers callforpaper;

		public string Message { get; set; }
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

		public CreateCallForPapersViewModel(bool modelState, CallForPapers callforpapers, CallForPaperService service)
		{
			if (modelState)
			{

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