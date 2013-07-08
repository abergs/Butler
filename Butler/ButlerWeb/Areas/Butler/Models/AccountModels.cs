using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ButlerCore;

namespace ButlerWeb.Areas.Butler.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }

    public class Authorization
    {
        public Authorization()
        {
            data = Store.Get<ButlerAuthorization>("Authorization");

            if (data == null)
            {
                data = new ButlerAuthorization();
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

        private ButlerAuthorization data;

        public void AddUser(User user)
        {
            // Validate
            foreach (var u in data.Users)
            {
                if (u.Email == user.Email)
                {
                    throw new Exception("User already exist");
                }
            }

            // hash password
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password,9);

            data.Users.Add(user);
            Save();
        }

        private void Save()
        {
            Store.Save(data);
        }

        private class ButlerAuthorization : ButlerDocument
        {
            public ButlerAuthorization()
            {
                Users = new List<User>();
                this.ID = "Authorization";
            }

            public List<User> Users { get; set; }
        }
    }
}