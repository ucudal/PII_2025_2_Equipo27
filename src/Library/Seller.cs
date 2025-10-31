
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

        public string AsignClient(Seller other, Client client)
        {
            if (other.Active)
            {
                other.thisClients.Add(client);
                return "Cliente agregado";
            }
            else
            {
                return "No se le puede asignar un cliente al vendedor porque está suspendido";
            }
        }
    }
}