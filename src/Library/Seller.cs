
using System;
using System.Collections.Generic;

namespace Library
{
    public class Seller : User
    {
        private List<Client> _clients = new List<Client>();
        public IReadOnlyList<Client> Clients => _clients.AsReadOnly();

        public Seller(string username) : base(username)
        {
            // Intencionalmente en blanco
        }


        public string AsignClient(Seller newSeller, Client client)
        {
            if (newSeller.Active)
            {
                newSeller._clients.Add(client);
                return "Cliente agregado";
            }
            else
            {
                return "No se le puede asignar un cliente al vendedor porque está suspendido";
            }
        }

    }
}