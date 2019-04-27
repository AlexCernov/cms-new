using CMS.Services;

namespace CMS.ViewModels
{
    internal interface IRegisterUserViewModel<T>
    {
        bool CheckUser(IUserService<T> service, T entity);

    }
}
