﻿using System;
using CMS.Models;
using CMS.Service;
using CMS.Exception;

namespace CMS.ViewModels
{
	public class RegistrationAuthorViewModel : IRegistrationAuthorViewModel
	{
		public Author author;
		public string Message;
		public bool Status;
		public string Title;

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
				Author = authorService.Add(author);
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