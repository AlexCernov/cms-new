using CMS.Models;
using CMS.Service;

namespace CMS.ViewModels
{
	public interface IRegistrationAuthorViewModel
	{
		bool CheckUser(IAuthorService authorService, Author author);
	}
}