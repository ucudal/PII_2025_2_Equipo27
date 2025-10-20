using System;
using System.Collections.Generic;

namespace Library
{
    public class Admin : User
    {
        private List<Seller> sellers = new List<Seller>();

        public Admin(string username) : base(username)
        {
        }

      

        public Seller CreateSeller(string username)
        {
            foreach (User u in users)
            {
                if (u.UserName == username)
                {
                    Console.WriteLine("Ya hay un vendedor con ese nombre de usuario");
                    return null;
                }
            }

            Seller seller = new Seller(username);
            sellers.Add(seller);
            return seller;
        }

        

        public void SuspendSeller(Seller seller)
        {
            seller.Active = false;
        }

        public void DeleteSeller(Seller seller)
        {
            sellers.Remove(seller);
    }
    }
}