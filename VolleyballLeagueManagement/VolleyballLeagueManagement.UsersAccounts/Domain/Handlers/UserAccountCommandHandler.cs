using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using VolleyballLeagueManagement.Common.Enums;
using VolleyballLeagueManagement.Common.Extensions;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.Common.Interfaces;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;
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
        IHandler<ChangeUserRole>,
        IHandler<LogInCommand>,
        IHandler<LogOffCommand>
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
            } 
        }

        public void Handle(UpdateUserDataCommand dataCommand)
        {
            ValidateCommandParameters(dataCommand);

            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.Single(u => u.Id == dataCommand.Id);

                if (user == null)
                    throw new ServerSideException("User not found, try agine");

                UpdateUserEntity(user, dataCommand);

                dbContext.SaveChanges();
            } 
        }

        public void Handle(RemoveUserCommand command)
        {
            ValidateCommandParameters(command, command.Id);

            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Id == command.Id);

                if (user == null)
                    throw new ServerSideException("User not found, try agine");

                // TODO Check if user have league or team
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            } 
        }

        public void Handle(UpdateUserAddressCommand command)
        {
            ValidateCommandParameters(command, command.UserId);

            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Id == command.UserId);

                if (user == null)
                    throw new ServerSideException("User not found, try agine");

                UpdateUserAddres(user.Address, command);

                dbContext.SaveChanges();
            } 
        }

        public void Handle(ChangeEmailCommand command)
        {
            ValidateCommandParameters(command);

            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Id == command.UserId);

                if (user == null)
                    throw new ServerSideException("User not found, try agine");

                ChangeEmail(user, command);

                dbContext.SaveChanges();
            } 
        }

        public void Handle(ChangePasswordCommand command)
        {
            ValidateCommandParameters(command);

            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Id == command.UserId);

                if (user == null)
                    throw new ServerSideException("User not found, try agine");

                ChangePassword(user, command);

                dbContext.SaveChanges();
            } 
        }

        public void Handle(ChangeUserRole command)
        {
            ValidateCommandParameters(command, command.UserId);

            using (var dbContext = new UserAccountDataContext())
            {
                User user = dbContext.Users.SingleOrDefault(u => u.Id == command.UserId);

                if (user == null)
                    throw new ServerSideException("User not found, try agine");

                ChangeRole(user, command);

                dbContext.SaveChanges();
            } 
        }

        public void Handle(LogInCommand command)
        {
            // Create cookie
        }

        public void Handle(LogOffCommand command)
        {
            // Remove cookie
        }


        private void ValidateCommandParameters(ICommand command, int userId)
        {
            if (command == null)
                throw new ArgumentNullException("command", "Command is empty. Something went wrong!");

            if (userId == 0)
                throw new ServerSideException("UserId cannot be 0");
        }

        private void ValidateCommandParameters(AddUserCommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command", "Command is empty. Something went wrong!");

            if (!Regex.IsMatch(command.Phone, @"^\d+$"))
                throw new ServerSideException("Phone number is invalid");

            if (!IsValidEmail(command.Email))
                throw new ServerSideException("Email is invalid");

            if (command.Password != command.PasswordRepeat)
                throw new ServerSideException("Passwords does not match");
        }

        private void ValidateCommandParameters(UpdateUserDataCommand command)
        {
            ValidateCommandParameters(command, command.Id);

            if (!Regex.IsMatch(command.Phone, @"^\d+$"))
                throw new ServerSideException("Phone number is invalid");
        }

        private void ValidateCommandParameters(ChangeEmailCommand command)
        {
            ValidateCommandParameters(command, command.UserId);

            if (!IsValidEmail(command.OldEmail))
                throw new ServerSideException("Your old email has invalid format");

            if (!IsValidEmail(command.NewEmail))
                throw new ServerSideException("Your new email has invalid format");

            if (!IsValidEmail(command.NewEmailRepeat))
                throw new ServerSideException("Your confirm email has invalid format");

            if (command.NewEmail != command.NewEmailRepeat)
                throw new ServerSideException("Emails does not match");
        }

        private void ValidateCommandParameters(ChangePasswordCommand command)
        {
            ValidateCommandParameters(command, command.UserId);

            if (command.NewPassword != command.NewPasswordRepeat)
                throw new ServerSideException("Passwords does not match");
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
                Role = (Role) command.RoleValue,
                IsAccountConfirmed = false,
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

        private void ChangeRole(User user, ChangeUserRole command)
        {
            // TODO Check if user have league or team

            user.Role = (Role) command.RoleValue;
        }
    }
}
