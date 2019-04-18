using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models;

namespace CMS.Repository
{
	public interface IAuthorRepository
	{
		Author Add(Author addedAuthor);
		Author FindByUsername(string username);
		IList<Author> FindAll();
	}
}