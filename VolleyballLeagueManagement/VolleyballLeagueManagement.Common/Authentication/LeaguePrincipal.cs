using System.Security.Principal;
using VolleyballLeagueManagement.Common.Enums;

namespace VolleyballLeagueManagement.Common.Authentication
{
    public class LeaguePrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }

        public LeaguePrincipal() { }

        public LeaguePrincipal(int id, string login, string role)
        {
            UserId = id;
            Login = login;
            Role = role;
            Identity = new GenericIdentity(login);
        }

        public bool IsInRole(string role)
        {
            return Role == role;
        }

        public bool IsInRole(Role role)
        {
            return Role == role.ToString();
        }
    }
}
