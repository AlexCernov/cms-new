using CMS.Exceptions;
using CMS.Models;
using CMS.Services;
using CMS.Services.Users;

namespace CMS.ViewModels.PCMemberViewModels
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
            bool emailExists;
            try
            {
                usernameExists = service.UsernameExists(entity.Username);
                emailExists = service.EmailExists(entity.Email);
            }
            catch (System.Exception)
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
    }
}