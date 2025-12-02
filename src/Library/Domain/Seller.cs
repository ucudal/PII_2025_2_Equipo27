
using System;
using System.Collections.Generic;

namespace Library
{
    public class Seller : User
    {
        private List<Client> _clients = new List<Client>();
        public IReadOnlyList<Client> Clients => _clients.AsReadOnly();

        public Seller(string username, int id) : base(username, id)
        {
            // Intencionalmente en blanco.
        }

        /// <summary>
        /// Asigna un cliente a otro vendedor.
        /// Principios aplicados:
        /// Expert: Seller es el resposable de gestionar sus propios clientes.
        /// SRP: El método únicamente se encarga de asignar un cliente a otro vendedor.
        /// </summary>
        /// <param name="newSeller">El vendedor al que se asignará un cliente</param>
        /// <param name="client">Cliente que se asignará al vendedor</param>
        /// <returns>Un mensaje de que se agregó el cliente o que no se pudo porque el vendedor está suspendido</returns>
        /// <exception cref="ArgumentNullException">El vendedor o el cliente no pueden ser nulos</exception>
        
        public void AsignClient(Seller newSeller, Client client)
        {
            if (newSeller == null)
            {
                throw new ArgumentNullException(nameof(newSeller), "El vendedor no puede ser nulo");
            }

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "El cliente no puede ser nulo");
            }
            if (newSeller.Active)
            {
                
                newSeller._clients.Add(client);
                client.AsignedSeller = newSeller;
            }
            
        }

    }
}