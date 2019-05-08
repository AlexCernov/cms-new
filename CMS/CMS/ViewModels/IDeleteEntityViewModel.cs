using CMS.Services;

namespace CMS.ViewModels
{
    internal interface IDeleteEntityViewModel<T>
    {
        bool CheckEntity(IEntityService<T> service, T entity);

    }
}
