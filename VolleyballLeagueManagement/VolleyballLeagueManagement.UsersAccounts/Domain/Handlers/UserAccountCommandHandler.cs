using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using VolleyballLeagueManagement.Common.Authentication;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.Common.Extensions;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.Common.Interfaces;
using VolleyballLeagueManagement.UsersAccounts.Domain.Commands;
using VolleyballLeagueManagement.UsersAccounts.Model;

namespace VolleyballLeagueManagement.UsersAccounts.Domain.Handlers
{
    public class UserAccountCommandHandler : IHandler<AddUserCommand>,
        IHandler<UpdateUserDataCommand>,
        IHandler<RemoveUserCommand>,
        IHandler<UpdateUserAddressCommand>,
        IHandler<ChangeEmailCommand>,
        IHandler<ChangePasswordCommand>,
        IHandler<ChangeUserRoleCommand>,
        IHandler<LogInCommand>,
        IHandler<LogOffCommand>,
        IHandler<ForgotPasswordCommand>,
        IHandler<ConfirmAccountCommand>
    {
        public void Handle(AddUserCommand command)
        {
            ValidateCommandParameters(command);

            using (var dbContext = new UserAccountDataContext())
            {
                ValidateLogin(dbContext, command.Login);
                ValidateEmail(dbContext, command.Email);

                User user = CreateUserEntity(command);
                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                // TODO add event: User registered - send confirm email
            } 
        }

        public void Handle(UpdateUserDataCommand command)
        {
            ValidatePhoneNumber(command.Phone);

            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.Single(u => u.Id == command.Id);

                if (user == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                UpdateUserEntity(user, command);

                dbContext.SaveChanges();

                // TODO add event: User updated - send email
            } 
        }

        public void Handle(RemoveUserCommand command)
        {
            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Id == command.Id);

                if (user == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                // TODO Check if user have league or team
                // if user have league or team then cant delete account
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();

                // TODO add event: User deleted - send email - delete cookie
            } 
        }

        public void Handle(UpdateUserAddressCommand command)
        {
            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Id == command.UserId);

                if (user == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                UpdateUserAddres(user.Address, command);

                dbContext.SaveChanges();

                // TODO add event: User change address - send email
            } 
        }

        public void Handle(ChangeEmailCommand command)
        {
            ValidateCommandParameters(command);

            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Id == command.UserId);

                if (user == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                ChangeEmail(user, command);

                dbContext.SaveChanges();

                // TODO add event: User email changed - send confirm email
            } 
        }

        public void Handle(ChangePasswordCommand command)
        {
            ValidatePasswordConfirm(command.NewPassword, command.NewPasswordRepeat);

            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Id == command.UserId);

                if (user == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                ChangePassword(user, command);

                dbContext.SaveChanges();

                // TODO add event: User changed password - send confirm email
            } 
        }

        public void Handle(ChangeUserRoleCommand command)
        {
            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Id == command.UserId);

                if (user == null)
                    throw new ServerSideException("Ups, something went wrong! Refresh page and try agine");

                // TODO Check if user have league or team
                // if user have league or team then cant change role

                ChangeRole(user, command);

                dbContext.SaveChanges();

                // TODO add event: User change role - send email
            } 
        }

        public void Handle(LogInCommand command)
        {
            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Login == command.Login);
                ValidateLoginData(user, command);

                var appUser = CreateAppUserEntity(user);
                CookieHandler.Create(appUser, command.RememberMe);
            }
        }

        public void Handle(LogOffCommand command)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return;

            authCookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        public void Handle(ForgotPasswordCommand command)
        {
            if (!IsValidEmail(command.Email))
                throw new ServerSideException("Email format is invalid");

            using (var dbContext = new UserAccountDataContext())
            {
                var user = dbContext.Users.SingleOrDefault(u => u.Email == command.Email);

                if (user == null)
                    throw new ServerSideException(
                        String.Format("User with email: {0} does not exist", command.Email));

                // TODO Generate new password
                // TODO Send email with new password
            } 
        }

        public void Handle(ConfirmAccountCommand command)
        {
            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.ConfirmGuid == command.ConfirmGuid);

                if (user == null)
                    throw new ServerSideException("User not find, check your activate link and try agine, or contact us");

                user.ConfirmAccount();
            } 
        }


        private void ValidateCommandParameters(AddUserCommand command)
        {
            if (!Regex.IsMatch(command.Phone, @"^\d+$"))
                throw new ServerSideException("Phone number is invalid");

            if (!IsValidEmail(command.Email))
                throw new ServerSideException("Email is invalid");

            if (command.Password != command.PasswordRepeat)
                throw new ServerSideException("Passwords does not match");
        }

        private void ValidateCommandParameters(ChangeEmailCommand command)
        {
            if (!IsValidEmail(command.OldEmail))
                throw new ServerSideException("Your old email has invalid format");

            if (!IsValidEmail(command.NewEmail))
                throw new ServerSideException("Your new email has invalid format");

            if (!IsValidEmail(command.NewEmailRepeat))
                throw new ServerSideException("Your confirm email has invalid format");

            if (command.NewEmail != command.NewEmailRepeat)
                throw new ServerSideException("Emails does not match");
        }

        private void ValidatePasswordConfirm(string newPassword, string newPasswordRepeat)
        {
            if (newPassword != newPasswordRepeat)
                throw new ServerSideException("Passwords does not match");
        }

        private void ValidatePhoneNumber(string phoneNumber)
        {
            if (!Regex.IsMatch(phoneNumber, @"^\d+$"))
                throw new ServerSideException("Phone number is invalid");
        }

        private void ValidateLogin(UserAccountDataContext dc, string login)
        {
            var user = dc.Users.FirstOrDefault(u => u.Login == login);

            if (user != null)
                throw new ServerSideException(String.Format(
                    "A user with the login name: {0}, already exists", login));
        }

        private void ValidateEmail(UserAccountDataContext dc, string email)
        {
            var user = dc.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
                throw new ServerSideException(String.Format(
                    "This email: {0}, is already in use", email));
        }

        private void ValidateLoginData(User user, LogInCommand command)
        {
            if (user == null)
                throw new ServerSideException(
                    String.Format("User with login: {0} not found, try agine", command.Login));

            if (!command.Password.CompareWithHash(user.Password))
                throw new ServerSideException("Wrong password");
        }

        private bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private User CreateUserEntity(AddUserCommand command)
        {
            return new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Login = command.Login,
                Password = command.Password.Encrypt(),
                Email = command.Email,
                Phone = command.Phone,
                Role = (Role) command.Role,
                IsAccountConfirmed = false,
                ConfirmGuid = new Guid(),
                Address = new Address
                {
                    City = command.City,
                    Street = command.Street,
                    HomeNumber = command.HomeNumber,
                    FlatNumber = command.FlatNumber,
                    PostCode = command.PostCode
                }
            };
        }

        private ApplicationUser CreateAppUserEntity(User user)
        {
            return new ApplicationUser
            {
                Id = user.Id,
                Login = user.Login,
                Role = user.Role.ToString()
            };
        }

        private void UpdateUserEntity(User user, UpdateUserDataCommand command)
        {
            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.Login = command.Login;
            user.Phone = command.Phone;
        }

        private void UpdateUserAddres(Address addres, UpdateUserAddressCommand command)
        {
            addres.City = command.City;
            addres.Street = command.Street;
            addres.HomeNumber = command.HomeNumber;
            addres.FlatNumber = command.FlatNumber;
            addres.PostCode = command.PostCode;
        }

        private void ChangeEmail(User user, ChangeEmailCommand command)
        {
            if (user.Email != command.OldEmail)
                throw new ServerSideException("Old email and user email does not match");

            user.Email = command.NewEmail;
        }

        private void ChangePassword(User user, ChangePasswordCommand command)
        {
            if (!command.OldPassword.CompareWithHash(user.Password))
                throw new ServerSideException("Old password and user password does not match");

            user.Password = command.NewPassword.Encrypt();
        }

        private void ChangeRole(User user, ChangeUserRoleCommand command)
        {
            // TODO Check if user have league or team

            user.Role = (Role) command.RoleValue;
        }
    }
}
