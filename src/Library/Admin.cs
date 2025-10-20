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

        public Seller ScreachSeller(string username)
        {
            foreach (var seller in sellers)
            {
                if (seller.UserName == username)
                {
                    return seller;
                }
            }

            return null;
        }

        public Seller CreateSeller(string username)
        {
            foreach (User u in sellers)
            {
                if (u.UserName == username)
                {
                    Console.WriteLine("Ya hay un vendedor con ese nombre de usuario");
                    return null;
                }
            }

            Seller seller = new Seller(username);
            sellers.Add(seller);
            Console.WriteLine("Vendedor creado");
            return seller;
        }

        

        public void SuspendSeller(Seller seller)
        {
            if (!seller.Active)
            {
                seller.Active = false;
                Console.WriteLine("Usuario suspendido");
            }
            else
            {
                Console.WriteLine("El usuario ya está suspendido");
            }
        }

        public void DeleteSeller(Seller seller)
        {
            if (sellers.Contains(seller))
            {
                sellers.Remove(seller);
            }
            else
            {
                Console.WriteLine("Ese vendedor no existe");
            }
        }
    }
}