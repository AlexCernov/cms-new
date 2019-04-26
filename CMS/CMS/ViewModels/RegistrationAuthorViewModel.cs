using System;
using CMS.Models;
using CMS.Service;
using CMS.Exception;

namespace CMS.ViewModels
{
	public class RegistrationAuthorViewModel : IRegistrationAuthorViewModel
	{
		public Author Author { get; set; }
		public string Message { get; set; }
		public bool Status { get; set; }
		public string Title { get; set; }

		public RegistrationAuthorViewModel()
		{
			Message = null;
			Title = "Registration";
		}

		public RegistrationAuthorViewModel(bool modelState, Author author, IAuthorService authorService)
		{
			if (modelState)
			{
				try
				{
					Status = CheckUser(authorService, author);
				}
				catch (InternetException e)
				{
					Message = e.Message;
					Status = false;
					return;
				}
				catch (DatabaseException e)
				{
					Message = e.Message;
					Status = false;
					return;
				}

				Message = " Registration successfully done.";
				Status = true;
			}
			else
			{
				Message = " Invalid request";
				Status = false;
			}
		}
		public bool CheckUser(IAuthorService authorService, Author author)
		{
			bool userExists;
			try
			{
				userExists = authorService.UsernameExists(author.Username);
			}
			catch
			{
				throw;
			}

			if (userExists)
			{
				throw new DatabaseException(" User already exists!\n");
			}
			try
			{
				author = authorService.Add(author);
			}
			catch
			{
				throw;
			}

			author.Password = "";

			return true;
		}
	}
}