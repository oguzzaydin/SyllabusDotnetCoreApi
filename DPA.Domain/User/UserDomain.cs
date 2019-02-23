using DPA.Model;
using System;

namespace DPA.Domain
{
    public class UserDomain
    {

        protected internal UserDomain(object userId, string username, string password)
        {
            UserName = username;
            Password = password;
        }

        protected internal UserDomain(long userId, Roles roles)
        {
            Id = userId;
            Roles = roles;
        }

        public UserDomain(string login, string password)
        {
            UserName = login;
            Password = password;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Email { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime UpdatedDate { get; private set; }

        public Roles Roles { get; private set; }

        public Status Status { get; private set; }

        public Title Title { get; private set; }

        public void Add()
        {
            Roles = Roles.User;
            Status = Status.Active;
        }

    }
}
