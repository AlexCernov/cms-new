using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models;
using CMS.Repository;

namespace CMS.Service
{
	public class AuthorService : IAuthorService
	{
		private readonly IAuthorRepository authorRepository;

		public AuthorService(IAuthorRepository authorRepository)
		{
			this.authorRepository = authorRepository;
		}

		public Author Add(Author addedAuthor)
		{
			return authorRepository.Add(addedAuthor);
		}

		public bool UsernameExists(string username)
		{
			return authorRepository.FindByUsername(username) != null;
		}

		public IList<Author> FindAll()
		{
			return authorRepository.FindAll();
		}
	}
}