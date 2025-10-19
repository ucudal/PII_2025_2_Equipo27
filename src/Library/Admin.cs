using System;
using System.Collections.Generic;

namespace Library
{
    public class Admin : User
    {
        private List<User> users = new List<User>();

        public Admin(string username) : base(username)
        {
        }

        public User CreateUser(string name)
        {
            foreach (User u in users)
            {
                if (u.UserName == name)
                {
                    Console.WriteLine("Ya hay un usuario con ese nombre de usuario");
                    return null;
                }
            }

            User user = new User(name);
            users.Add(user);
            return user;
        }

        public Seller CreateSeller(string name)
        {
            foreach (User u in users)
            {
                if (u.UserName == name)
                {
                    Console.WriteLine("Ya hay un vendedor con ese nombre de usuario");
                    return null;
                }
            }

            Seller seller = new Seller(name);
            users.Add(seller);
            return seller;
        }

        public void SuspendUser(User user)
        {
            user.Active = false;
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
        }
    }
}