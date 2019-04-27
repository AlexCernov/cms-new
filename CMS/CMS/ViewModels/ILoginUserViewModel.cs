using CMS.Services;

namespace CMS.ViewModels
{
    internal interface ILoginUserViewModel<T>
    {
        bool CheckUser(IUserService<T> service, T entity);
        void SetCoockie(string username, bool rememberMe);
    }
}
