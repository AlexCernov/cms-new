using CMS.Models;
using CMS.Repositories;
using System;
using System.Collections.Generic;

namespace CMS.Services
{
    public class AuthorService : IUserService<Author>
    {
        private readonly IUserRepository<Author> authorRepository;

        public AuthorService(IUserRepository<Author> authorRepository) => this.authorRepository = authorRepository;
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
    }
}