using System;
using System.Collections.Generic;

namespace Library
{
    public class Admin : User
    {
        public List<Seller> sellers = new List<Seller>();

        public Admin(string username) : base(username)
        {
            // Itencionalmente en blanco
        }

        public Seller SearchSeller(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("El usuario no tiene nombre", nameof(username));
            }
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
            foreach (Seller s in sellers)
            {
                if (s.UserName == username)
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

        public string ActiveSeller(Seller seller)
        {
            if (!seller.Active)
            {
                seller.Active = true;
                return "El vendedor dejó de estar suspendido";
            }
            else
            {
                return "El vendedor ya estaba activo";
            }
        }

        public string SuspendSeller(Seller seller)
        {
            if (seller.Active)
            {
                seller.Active = false;
                return "Vendedor suspendido";
            }
            else
            {
                return "El vendedor ya estaba suspendido";
            }
        }

        public string DeleteSeller(Seller seller)
        {
            if (sellers.Contains(seller))
            {
                sellers.Remove(seller);
                return "Vendedor eliminado";
            }
            else
            {
                return "Ese vendedor no existe";
            }
        }
    }
}