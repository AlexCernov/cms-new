using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using CMS.Models;
using CMS.Service;
using CMS.Exception;

namespace CMS.ViewModels
{
    public class LoginAuthorViewModel
    {
        public string Username;
        public string Password;
        public bool RememberMe;

        public HttpCookie Cookie;

        public string Message { get; set; }
        public bool Status { get; }
        public string Title { get; }

        public LoginAuthorViewModel(IAuthorService authorService, bool modelState, string username, string password, bool rememberMe, out int returnValue)
        {
            if (modelState)
            {
                try
                {
                    Author user = new Author(username, password);
                    RememberMe = rememberMe;
                    Status = CheckUser(authorService, user);
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
                catch (InternetException exception)
                {
                    Message = exception.Message;
                    Status = false;
                    returnValue = -1;
                    return;
                }
                catch (DatabaseException exception)
                {
                    Message = exception.Message;
                    Status = false;
                    returnValue = -1;
                    return;
                }
            }
            returnValue = -1;
            Message = "Invalid request!";
            Status = false;
        }

        public bool CheckUser(IAuthorService authorService, Author user)
        {
            try
            {
                bool usernameExists = authorService.UsernameExists(user.Username);
                if (usernameExists == false)
                {
                    Message = "Username is incorrect!";
                    return false;
                }
            }
            catch
            {
                throw; // throw what?
            }

            Author dbUser = authorService.FindByUsername(user.Email);
            bool correctPassword;
            if (dbUser.Password == Crypto.Hash(user.Password))
                correctPassword = true;
            else
                correctPassword = false;

            if (correctPassword == false)
            {
                Message = "Incorrect password!";
                return false;
            }

            return true;
        }

        public void SetCookie(string username, bool rememberMe)
        {
            int timeout = rememberMe ? 262800 : 20;
            var ticket = new FormsAuthenticationTicket(username, rememberMe, timeout);
            string encrypted = FormsAuthentication.Encrypt(ticket);
            Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
            Cookie.Expires = DateTime.Now.AddMinutes(timeout);
            Cookie.HttpOnly = true;
        }
    }
}