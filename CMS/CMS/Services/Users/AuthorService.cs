using CMS.Models;
using CMS.Repositories;
using CMS.Repositories.Users;
using System;
using System.Collections.Generic;

namespace CMS.Services.Users
{
    public class AuthorService : IUserService<Author>
    {
        private readonly IUserRepository<Author> authorRepository;

		public AuthorService(AuthorRepository authorRepository)
		{
			this.authorRepository = authorRepository;
		}

		//public AuthorService(IUserRepository<Author> authorRepository) => this.AuthorRepository = authorRepository;
		public Author Add(Author entity)
        {
            return authorRepository.Add(entity);
        }

        public IList<Author> FindAll()
        {
            return authorRepository.FindAll();
        }

        public Author FindByUsername(string username)
        {
            return authorRepository.FindByUsername(username);
        }

        public bool UsernameExists(string username)
        {
			return authorRepository.FindByUsername(username) != null;

        }

        public bool EmailExists(string email)
        {
            return authorRepository.FindByEmail(email) != null;
        }
    }
}