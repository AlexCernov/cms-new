using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using CMS.Services.Users;
using CMS.ViewModels;
using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
namespace CMS.ViewModels.AuthorViewModels
{
    public class LoginAuthorViewModel : ILoginUserViewModel<Author>
    {
        public string Username;
        public string Password;
        public bool RememberMe;

        public HttpCookie Cookie;

        public string Message { get; set; }
        public bool Status { get; }
        public string Title { get; }

        public LoginAuthorViewModel()
        {
            Message = null;
            Title = "Login";
        }

        public bool CheckUser(IUserService<Author> service, Author entity)
        {
            Author userRetrievedFromTheDatabase;
            bool userExists;
            try
            {
                userExists = service.UsernameExists(entity.Username);
                if (!userExists)
                {
                    Message = " The username does not exist!\n";
                    return false;
                }
                userRetrievedFromTheDatabase = service.FindByUsername(entity.Username);
            }
            catch
            {
                throw;
            }

            bool goodPassword;
            try
            {
                if (userRetrievedFromTheDatabase.Password == Crypto.Hash(entity.Password))
                {
                    goodPassword = true;
                }
                else
                {
                    goodPassword = false;
                }
            }
            catch
            {
                throw;
            }

            if (!goodPassword)
            {
                Message = " Incorrect password!\n";
                return false;
            }
            SetCookie(entity.Username, RememberMe);
            return true;
        }

        public void SetCookie(string username, bool rememberMe)
        {
            int timeout = rememberMe ? 262800 : 20;
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(username, rememberMe, timeout);
            string encrypted = FormsAuthentication.Encrypt(ticket);
            Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
            {
                Expires = DateTime.Now.AddMinutes(timeout),
                HttpOnly = true
            };
        }

        public LoginAuthorViewModel(bool modelState, string username, string password, bool rememberMe, AuthorService service, out int returnValue)
        {
            if (modelState)
            {
                try
                {
                    Author user = new Author(username, password);
                    RememberMe = rememberMe;
                    Status = CheckUser(service, user);
                    if (Status)
                    {
                        Username = username;
                        Password = "";
                        returnValue = 1;
                        return;
                    }
                    returnValue = -1;
                    return;
                }
                catch (InternetException ex)
                {
                    Message = ex.Message;
                    Status = false;
                    returnValue = -1;
                    return;
                }
                catch (DatabaseException ex)
                {
                    Message = ex.Message;
                    Status = false;
                    returnValue = -1;
                    return;
                }
            }
            returnValue = -1;
            Message = " Invalid request!\n";
            Status = false;
        }
    }
}