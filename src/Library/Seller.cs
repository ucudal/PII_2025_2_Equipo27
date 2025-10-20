using System;
using System.Collections.Generic;

namespace Library
{
    public class Seller : User
    {
        private List<Client> thisClients = new List<Client>();

        public Seller(string username) : base(username)
        {
            
        }

        public void AsignClient(Seller other, Client client)
        {
            other.thisClients.Add(client);
        }
    }
}