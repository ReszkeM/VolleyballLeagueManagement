using System;
using System.Linq;
using VolleyballLeagueManagement.UsersAccounts.Contracts.ViewModels;
using VolleyballLeagueManagement.UsersAccounts.Model;

namespace VolleyballLeagueManagement.UsersAccounts.QueryObjects
{
    public static class UserExtensions
    {
        public static ChangeUserDataViewModel GetUserData(this IQueryable<User> users, int userId)
        {
            var user = users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                throw new ArgumentException(
                    string.Format("User with id: {0} does not exist in the database.", userId));

            return GetUserData(user);
        }

        public static ChangeAddressViewModel GetUserAddress(this IQueryable<User> users, int userId)
        {
            var user = users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                throw new ArgumentException(
                    string.Format("User with id: {0} does not exist in the database.", userId));

            return GetUserAddress(user);
        }

        public static ChangeUserRoleViewModel GetUserRole(this IQueryable<User> users, int userId)
        {
            var user = users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                throw new ArgumentException(
                    string.Format("User with id: {0} does not exist in the database.", userId));

            return GetUserRole(user);
        }


        private static ChangeUserDataViewModel GetUserData(User user)
        {
            return new ChangeUserDataViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = user.Login,
                Phone = user.Phone
            };
        }

        private static ChangeAddressViewModel GetUserAddress(User user)
        {
            return new ChangeAddressViewModel
            {
                UserId = user.Id,
                City = user.Address.City,
                Street = user.Address.Street,
                HomeNumber = user.Address.HomeNumber,
                FlatNumber = user.Address.FlatNumber,
                PostCode = user.Address.PostCode
            };
        }

        private static ChangeUserRoleViewModel GetUserRole(User user)
        {
            return new ChangeUserRoleViewModel
            {
                UserId = user.Id,
                Role = (int)user.Role
            };
        }
    }
}
