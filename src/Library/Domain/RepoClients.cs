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
        
        /// <summary>
        /// Crea una instancia de Client y la guarda en List<Client> clients.
        /// </summary>
        /// <param name="name">Nombre del Cliente</param>
        /// <param name="lastName">Apellido del Cliente</param>
        /// <param name="email">Email del Cliente</param>
        /// <param name="phone">Numero de teléfono del Cliente</param>
        /// <param name="gender">Sexo del Cliente</param>
        /// <param name="birthDate">Fecha de nacimiento del Cliente</param>
        /// <param name="seller">Vendedor asignado al Cliente</param>
        /// <returns>Cliente creado</returns>
        public Client CreateClient(string name, string lastName, string email, string phone, Client.GenderType gender, string birthDate, Seller seller)
        {
            int id = this.NextId;
            Client client = new Client(id, name, lastName, email, phone, gender, birthDate, seller);
            clients.Add(client);
            this.NextId += 1;
            return client;
        }
            
        /// <summary>
        /// Elimina un cliente del repo clientes.
        /// </summary>
        /// <param name="client">El id del cliente que se va a eliminar.</param>
        public void DeleteClient(int id)
        {
            int i = 0;
            bool clientFound = false;
            while (i <= clients.Count & !clientFound)
            {
                if (clients[i].Id == id)
                {
                    clientFound = true;
                    clients.Remove(Clients[i]);
                }
                i += 1;
            }
        } 
        public enum TypeOfData
        {
            Name,
            LastName,
            Email,
            Phone
        }

        /// <summary>
        /// Busca un cliente por su Id, que es única.
        /// </summary>
        /// <param name="id">Id del cliente</param>
        /// <returns>Cliente con la Id correspondiente</returns>
        public Client SearchClientById(int id)
        {
            Client result = null;
            foreach (var client in clients)
            {
                if (client.Id == id)
                {
                    result = client;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Busca los clientes que cumplan con dato ingresado.
        /// </summary>
        /// <param name="datasearched">Tipo de dato a buscar</param>
        /// <param name="serdched">Nombre, Apellido, Mail o Teléfono a buscar</param>
        /// <returns>Lista de clientes buscados</returns>
        public List<Client> SearchClient(TypeOfData datasearched, string serdched)
        {
            List<Client> result = new List<Client>();
            if (datasearched == TypeOfData.Name)
            {
                foreach (var client in clients)
                {
                    if (client.Name == serdched)
                    {
                        result.Add(client);
                    }
                }
            }
            else if (datasearched == TypeOfData.LastName)
            {
                foreach (var client in clients)
                {
                    if (client.LastName == serdched)
                    {
                        result.Add(client);
                    }
                }
            }
            else if (datasearched == TypeOfData.Email) 
            { 
                foreach (var client in clients)
                {
                    if (client.Email == serdched)
                    {
                        result.Add(client);
                    }
                }
            }
            else if (datasearched == TypeOfData.Phone) 
            { 
                foreach (var client in clients)
                {
                    if (client.Phone == serdched)
                    {
                        result.Add(client);
                    }
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
                        recentInteractions+= 1;
                    }
                    if (DateTime.Now <= interaction.InteractionDate)
                    {
                        futureMeetings+=1;
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