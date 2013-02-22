﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Butler;

namespace Web.Models
{
    public class User
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class Authorization
    {
        public Authorization()
        {
            data = Store.Get<Data>("Butler.Meta.Authorization");

            if (data == null)
            {
                data = new Data();
                Store.Save(data);
            }
        }

        public List<User> Users
        {
            get
            {
                return data.Users;
            }
        }

        private Data data;

        public void AddUser(User user)
        {
            // Validate
            foreach (var u in data.Users)
            {
                if (u.email == user.email)
                {
                    throw new Exception("User already exist");
                }
            }

            // hash password
            user.password = BCrypt.Net.BCrypt.HashPassword(user.password,9);

            data.Users.Add(user);
            Save();
        }

        private void Save()
        {
            Store.Save(data);
        }

        private class Data : ButlerDocument
        {
            public Data()
            {
                Users = new List<User>();
            }

            public override string ID { get { return "Butler.Meta.Authorization"; } set {} }
            public List<User> Users { get; set; }
        }
    }
}