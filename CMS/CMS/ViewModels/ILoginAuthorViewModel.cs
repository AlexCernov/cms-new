using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Service;
using CMS.Models;

namespace CMS.ViewModels
{
    interface ILoginAuthorViewModel
    {
        bool CheckUser(IAuthorService authorService, Author user);
        void SetCookie(string username, bool rememberMe);
    }
}
