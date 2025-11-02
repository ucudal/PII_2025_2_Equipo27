using System.Collections.Generic;

namespace Library
{
    public class RepoClients
    {
        public List<Client> Clients { get; } = new List<Client>();
        
        /// <summary>
        /// Agrega un cliente a la lista de clientes.
        /// </summary>
        /// <param name="client">El cliente que se va a agregar.</param>
        public void AddClient(Client client)
        {
            Clients.Add(client);
        }
            
        
        /// <summary>
        /// Elimina un cliente del repo clientes
        /// </summary>
        /// <param name="client">El id del cliente que se va a eliminar.</param>
        public void DeleteClient(int id)
        {
            for (int i=0;i<Clients.Count;i++)
            {
                if (Clients[i].Id == id)
                {
                    Clients.Remove(Clients[i]);
                }
            }
        }

        /// <summary>
        /// Busca clientes en la lista cuyo nombre coincida con el especificado.
        /// </summary>
        /// <param name="name">El nombre por el que buscar.</param>
        /// <returns>Una lista de clientes cuyo nombre coincide con el del parametro</returns>
        public List<Client> SearchClientByName(string name)
        {
            List<Client> result = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Name == name)
                {
                    result.Add(client);
                }
            }
            return result;
        }
        
        
        /// <summary>
        /// Busca clientes en la lista cuyo apellido coincida con el especificado.
        /// </summary>
        /// <param name="lastname">El apellido por el que buscar.</param>
        /// <returns>Una lista de clientes cuyo apellido coincide con el del parametro</returns>
        public List<Client> SearchClientByLastName(string lastname)
        {
            List<Client> result = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.LastName == lastname)
                {
                    result.Add(client);
                }
            }
            return result;
        }
        
        
        /// <summary>
        /// Busca clientes en la lista cuyo email coincida con el especificado.
        /// </summary>
        /// <param name="email">El email por el que buscar.</param>
        /// <returns>Una lista de clientes cuyo email coincide el del parametro</returns>
        public List<Client> SearchClientByEmail(string email)
        {
            List<Client> result = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Email == email)
                {
                    result.Add(client);
                }
            }
            return result;
        }
        
        
        /// <summary>
        /// Busca clientes en la lista cuyo número de telefono coincida con el especificado.
        /// </summary>
        /// <param name="phone">El numero de telefono por el que buscar.</param>
        /// <returns>Una lista de clientes cuyo numero de telefono coincide el del parametro</returns>
        public List<Client> SearchClientByPhone(string phone)
        {
            List<Client> result = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Phone == phone)
                {
                    result.Add(client);
                }
            }
            return result;
        }

        /// <summary>
        /// Crea una lista de clientes cuyo estado esta inactivo.
        /// </summary>
        /// <returns>Lista de clientes con estado inactivo.</returns>
        public List<Client> InactiveClients()
        {
            List<Client> inactiveClients = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Inactive)
                {
                    inactiveClients.Add(client);
                }
            }

            return inactiveClients;
        }

        /// <summary>
        /// Crea una lista de clientes cuyo estado esta esperando por respuesta.
        /// </summary>
        /// <returns>Lista de clientes con estado esperando por respuesta.</returns>
        public List<Client> WaitingClients()
        {
            List<Client> waitingClients = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Waiting)
                {
                    waitingClients.Add(client);
                }
            }
            return waitingClients;
        }
        
    }
}