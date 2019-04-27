using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.ViewModels
{
    public class RegisterPCMemberViewModel : IRegisterUserViewModel<PCMember>
    {
        public PCMember PCMember;

        public string Message { get; }
        public bool Status { get; }
        public string Title { get; }

        public RegisterPCMemberViewModel()
        {
            Message = null;
            Title = "Register";
        }


        public RegisterPCMemberViewModel(bool modelState, PCMember pcmember, PCMemberService service)
        {
            if (modelState)
            {
                try
                {
                    Status = CheckUser(service, pcmember);
                }
                catch (InternetException e)
                {
                    Message = e.Message;
                    Status = false;
                    return;
                }
                catch (DatabaseException e)
                {
                    Message = e.Message;
                    Status = false;
                    return;
                }

                Message = " Registration successfully done.";
                                 
                Status = true;
            }
            else
            {
                Message = " Invalid request";
                Status = false;
            }
        }


        public bool CheckUser(IUserService<PCMember> service, PCMember entity)
        {
            bool usernameExists;
            try
            {
                usernameExists = service.UsernameExists(entity.Username);
            }
            catch
            {
                throw;
            }

            if (usernameExists)
            {
                throw new DatabaseException(" Username already exists!\n");
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
    }
}