using System;
using System.Collections.Generic;

namespace Library
{
    public class RepoClients
    {
        public IReadOnlyList<Client> Clients
        {
            get
            {
                return clients;
            }
            
        }

        private List<Client> clients = new List<Client>();
        private int NextId = 0;
        
        public void CreateClient(string name, string lastName, string email, string phone, Client.GenderType gender, string birthDate, Seller seller)
        {
            int id = this.NextId;
            Client client = new Client(id, name, lastName, email, phone, gender, birthDate, seller);
            clients.Add(client);
            this.NextId += 1;
        }
        
        /// <summary>
        /// Agrega un cliente a la lista de clientes.
        /// </summary>
        /// <param name="client">El cliente que se va a agregar.</param>
        public void AddClient(Client client)
        {
            clients.Add(client);
        }
        
        /// <summary>
        /// Elimina un cliente del repo clientes
        /// </summary>
        /// <param name="client">El id del cliente que se va a eliminar.</param>
        public void DeleteClient(int id)
        {
            for (int i=0;i<clients.Count;i++)
            {
                if (clients[i].Id == id)
                {
                    clients.Remove(clients[i]);
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
            foreach (var client in clients)
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
            foreach (var client in clients)
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
            foreach (var client in clients)
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
            foreach (var client in clients)
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
            foreach (var client in clients)
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
            foreach (var client in clients)
            {
                if (client.Waiting)
                {
                    waitingClients.Add(client);
                }
            }
            return waitingClients;
        }
        
        /// <summary>
        /// Calcula la cantidad de clientes, interacciones recientes y reuniones futuras.  
        /// </summary>
        /// <returns>Un mensaje con la cantidad de clientes, interacciones recientes y reuniones futuras.</returns>


        public string GetPanel()
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int recentInteractions = 0;
            int futureMeetings = 0;

            foreach (var client in this.Clients)
            {
                foreach (var interaction in client.Interactions)
                {
                    if (interaction.InteractionDate.Month == month && interaction.InteractionDate.Year == year && interaction.InteractionDate <= DateTime.Now)
                    {
                        recentInteractions++;
                    }
                    if (DateTime.Now <= interaction.InteractionDate)
                    {
                        futureMeetings++;
                    }
                
                }
            }
            return ($"Clientes totales: {this.Clients.Count}\n" + $"Interacciones en este último mes: {recentInteractions}\n" + $"Reuniones próximas {futureMeetings}");
        }
        
        /// <summary>
        /// Calcula la cantidad de ventas entre un período dado.
        /// </summary>
        /// <param name="startdate">Fecha inicial del período.</param>
        /// <param name="finishdate">Fecha final del período.</param>
        /// <returns>Un mensaje con la cantidad de ventas</returns>


        public string GetTotalSales(DateTime startdate, DateTime finishdate)
        {
            int totalSales = 0;
            foreach (var client in this.Clients)
            {
                foreach (var sales in client.Opportunities)
                {
                    if (sales.Date.Date >= startdate && sales.Date.Date <= finishdate)
                    {
                        totalSales++;
                    }
                }
            }
            return $"Cantidad de ventas dentro del período: {totalSales}";
        }
    }
}