
using System;
using System.Collections.Generic;

namespace Library
{
    public class Seller : User
    {
        public List<Client> thisClients = new List<Client>();

        public Seller(string username) : base(username)
        {
            // Intencionalmente en blanco
        }

       
    }
}