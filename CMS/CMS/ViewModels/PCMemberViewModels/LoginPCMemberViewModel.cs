using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using CMS.Services.Users;
using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;

namespace CMS.ViewModels.PCMemberViewModels
{
    public class LoginPCMemberViewModel : ILoginUserViewModel<PCMember>
    {
        public string Username;
        public string Password;
        public bool RememberMe;

        public HttpCookie Cookie;

        public string Message { get; set; }

        public bool Status { get; }

        public string Title { get; }


        public LoginPCMemberViewModel()
        {
            Message = null;
            Title = "Login";
        }
        public LoginPCMemberViewModel(bool modelState, string username, string password, bool rememberMe, PCMemberService service, out int returnValue)
        {
            if (modelState)
            {
                try
                {
                    PCMember user = new PCMember(username, password);
                    RememberMe = rememberMe;
                    Status = CheckUser(service, user);
                    if (Status)
                    {
                        Username = username;
                        Password = "";//do not expose password

                        returnValue = 1;
                        return;
                    }
                    returnValue = -1;
                    return;
                }
                catch (InternetException e)
                {
                    Message = e.Message;
                    Status = false;
                    returnValue = -1;
                    return;
                }
                catch (DatabaseException e)
                {
                    Message = e.Message;
                    returnValue = -1;
                    Status = false;
                    return;
                }
            }
            returnValue = -1;
            Message = " Invalid request";
            Status = false;
        }

        public bool CheckUser(IUserService<PCMember> service, PCMember entity)
        {
            PCMember userRetrivedFromDb;
            bool userExists;
            try
            {
                userExists = service.UsernameExists(entity.Username);
                if (!userExists)
                {
                    Message = " Your email is invalid or your password is invalid or" +
                              " you haven't verified your email!";
                    return false;
                }
                userRetrivedFromDb = service.FindByUsername(entity.Username);
            }
            catch
            {
                throw;
            }

            bool goodPassword;
            try
            {
                if (userRetrivedFromDb.Password == Crypto.Hash(entity.Password))
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
                Message = " Your password is not correct";
                return false;
            }
            SetCookie(entity.Username, RememberMe);
            return true;
        }

        public void SetCookie(string username, bool rememberMe)
        {
            int timeout = rememberMe ? 262800 : 20; // 262800 min = 1/2 year
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(username, rememberMe, timeout);
            string encrypted = FormsAuthentication.Encrypt(ticket);
            Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
            {
                Expires = DateTime.Now.AddMinutes(timeout),
                HttpOnly = true
            };
        }
    }
}