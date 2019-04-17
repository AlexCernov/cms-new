using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using CMS.Exception;
using CMS.Models;
using CMS.Service;
using CMS.ViewModels;
using System.Web.Helpers;

namespace CMS.ViewModels
{
    public class LoginViewModel : ILoginViewModel
    {
		// private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public string Username;
        public string Password;
        public bool RememberMe;

        public HttpCookie Cookie;
		private string email;

		public string Message { get; set; }

        public bool Status { get; }

        public string Title { get; }

        public LoginViewModel(IPCMemberService pCMemberService, Guid activationCode)
        {
			SetCoockie(pCMemberService.f, true);
        }

        public LoginViewModel(bool modelState, string username, string password, bool rememberMe, IPCMemberService pcmemberService, out int returnValue)
        {
            if (modelState)
            {
                try
                {
                    PCMember user = new PCMember("", email, password);
                    RememberMe = rememberMe;
                    Status = CheckUser(pcmemberService, user);
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

		private bool CheckUser(IPCMemberService pcmemberService, PCMember user)
		{
			PCMember dbUser;
			try
			{
				bool usernameExists = pcmemberService.UsernameExists(user.Username);
				if (!usernameExists)
				{
					Message = "Username or password is incorrect ! ";
					return false;
				}
				dbUser = pcmemberService.FindByEmail(email);
			}
			catch
			{
				throw;
			}

			bool goodPassword;
			try
			{
				if (dbUser.Password == Crypto.Hash(user.Password))
					goodPassword = true;
				else
					goodPassword = false;
			}
			catch
			{
				throw;
			}

			bool usernameVerified = false;
			if (!goodPassword || !usernameVerified)
			{
				Message = " Your email is invalid or your password is invalid or" +
						  " you haven't verified your email!";
				return false;
			}

			SetCoockie(user.Username, RememberMe);
			return true;
		}

		bool ILoginViewModel.CheckUser(IPCMemberService pcmemberService, PCMember user)
		{
			PCMember dbUser;
			try
			{
				bool usernameExists = pcmemberService.UsernameExists(user.Username);
				if (!usernameExists)
				{
					Message = "Username or password is incorrect ! ";
					return false;
				}
				dbUser = pcmemberService.FindByEmail(email);
			}
			catch
			{
				throw;
			}

			bool goodPassword;
			try
			{
				if (dbUser.Password == Crypto.Hash(user.Password))
					goodPassword = true;
				else
					goodPassword = false;
			}
			catch
			{
				throw;
			}

			bool usernameVerified = false;
			if (!goodPassword || !usernameVerified)
			{
				Message = " Your email is invalid or your password is invalid or" +
						  " you haven't verified your email!";
				return false;
			}

			SetCoockie(user.Username, RememberMe);
			return true;
		}

		private void SetCoockie(string username, bool rememberMe)
		{
			int timeout = rememberMe ? 262800 : 20; // 262800 min = 1/2 year
			var ticket = new FormsAuthenticationTicket(Username, rememberMe, timeout);
			string encrypted = FormsAuthentication.Encrypt(ticket);
			Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
			Cookie.Expires = DateTime.Now.AddMinutes(timeout);
			Cookie.HttpOnly = true;
		}

		void ILoginViewModel.SetCoockie(string username, bool rememberMe)
		{
			int timeout = rememberMe ? 262800 : 20; // 262800 min = 1/2 year
			var ticket = new FormsAuthenticationTicket(Username, rememberMe, timeout);
			string encrypted = FormsAuthentication.Encrypt(ticket);
			Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
			Cookie.Expires = DateTime.Now.AddMinutes(timeout);
			Cookie.HttpOnly = true;
		}
	}
}