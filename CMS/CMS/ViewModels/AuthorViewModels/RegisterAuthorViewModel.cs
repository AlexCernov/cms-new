using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using CMS.Services.Users;
using CMS.ViewModels;

namespace CMS.ViewModels.AuthorViewModels
{
    public class RegisterAuthorViewModel : IRegisterUserViewModel<Author>
    {
        public Author Author;

        public string Message { get; }
        public bool Status { get; }
        public string Title { get; }

        public RegisterAuthorViewModel()
        {
            Message = null;
            Title = "Register";
        }

        public bool CheckUser(IUserService<Author> service, Author entity)
        {
            bool usernameExists;
            bool emailExists;
            try
            {
                usernameExists = service.UsernameExists(entity.Username);
                emailExists = service.EmailExists(entity.Email);
            }
            catch
            {
                throw;
            }

            if (usernameExists)
            {
                throw new DatabaseException(" Username already exists!\n");
            }

            if (emailExists)
            {
                throw new DatabaseException(" An account with the given email already exists!\n");
            }

            try
            {
                entity = service.Add(entity);
            }
            catch
            {
                throw;
            }

            entity.Password = "";
            return true;
        }

        public RegisterAuthorViewModel(bool modelState, Author author, AuthorService service)
        {
            if (modelState)
            {
                try
                {
                    Status = CheckUser(service, author);
                }
                catch (InternetException ex)
                {
                    Message = ex.Message;
                    Status = false;
                    return;
                }
                catch (DatabaseException ex)
                {
                    Message = ex.Message;
                    Status = false;
                    return;
                }

                Message = " Registration successful!\n";
                Status = true;
            }
            else
            {
                Message = " Invalid request!\n";
                Status = false;
            }
        }
    }
}