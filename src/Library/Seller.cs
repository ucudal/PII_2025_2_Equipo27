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
            if (!client.Waiting)
            {
                Console.WriteLine("El cliente no está en espera");
            }
            if (!other.thisClients.Contains(client))
            {
                other.thisClients.Add(client);
                client.Waiting = false;
            }
            else
            {
                Console.WriteLine("El vendedor ya tiene asignado ese cliente");
            }
        }
    }
}