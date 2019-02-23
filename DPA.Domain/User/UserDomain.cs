﻿using DPA.Model;
using System;

namespace DPA.Domain
{
    public class UserDomain
    {
        protected internal UserDomain(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        protected internal UserDomain(long userId, Roles roles)
        {
            Id = userId;
            Roles = roles;
        }

        protected internal UserDomain
        (
            long id,
            string name,
            string surname,
            string email,
            string username,
            string password,
            Title title,
            Roles roles
        )
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            UserName = username;
            Password = password;
            Roles = roles;
            Title = title;

        }


     

        protected internal UserDomain
        (
            string name,
            string surname,
            string email,
            string username,
            string password,
            Title title,
            Roles roles
        )
        {
            Name = name;
            Surname = surname;
            Email = email;
            UserName = username;
            Password = password;
            Roles = roles;
            Title = title;

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
            Roles = Roles.User; // TODO: bolum baskanı user ekler
            Status = Status.Active;
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public void Update(UpdateUserModel updateUserModel)
        {
            Name = updateUserModel.Name;
            Surname = updateUserModel.Surname;
            Email = updateUserModel.Email;
            Title = updateUserModel.Title;
            Roles = updateUserModel.Roles;
            UpdatedDate = DateTime.Now;
        }

    }
}