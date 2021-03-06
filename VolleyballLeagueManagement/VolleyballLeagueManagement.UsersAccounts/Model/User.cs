﻿using System;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.UsersAccounts.Model
{
    public class User
    {
        public int Id { get; set; }

        public int AddressId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsAccountConfirmed { get; set; }

        public Guid ConfirmGuid { get; set; }

        public Role Role { get; set; }


        public virtual Address Address { get; set; }


        public void ConfirmAccount()
        {
            this.IsAccountConfirmed = true;
        }
    }
}
