using CMS.Services;

namespace CMS.ViewModels
{
    internal interface IDetailsEntityViewModel<T>
    {
        bool CheckEntity(IEntityService<T> service, T entity);

    }
}