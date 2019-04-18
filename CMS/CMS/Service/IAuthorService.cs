using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models;

namespace CMS.Service
{
	public interface IAuthorService
	{
		Author Add(Author addedAuthor);
		bool UsernameExists(string username);
        Author FindByUsername(string username);
        IList<Author> FindAll();
	}
}