using System;
using System.Collections.Generic;

namespace Library
{
    public class RepoClients
    {
        /// <summary>
        /// Para una mejor encapsulación de las listas se utiliza IReadOnlyList y otra lista privada.
        /// </summary>
        public IReadOnlyList<Client> Clients
        {
            get
            {
                return clients;
            }
            
        }

        private List<Client> clients = new List<Client>();
        
        /// <summary>
        /// NextId aumenta en uno cada vez que se crea un cliente, así todos los clientes tienen un número identificador diferente.
        /// </summary>
        private int NextId = 0;
        
        /// <summary>
        /// RepoClients contiene instancias de Client y trabaja con ellos, siguiendo la guía del patron Creator debería ser quien cree los clientes.
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
        /// Agrega un cliente a la lista de clientes.
        /// </summary>
        /// <param name="client">El cliente que se va a agregar.</param>
        public void AddClient(Client client)
        {
            clients.Add(client);
        }
        
        /// <summary>
        /// Por la guía Expert, la información necesaria para eliminar un cliente la tiene RepoClients, ya que es le que tiene las instancias y los id.
        /// </summary>
        /// <param name="client">El id del cliente que se va a eliminar.</param>
        public void DeleteClient(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentException("Debe escribir un id válido", nameof(id));
            }
            for (int i=0;i<clients.Count;i++)
            {
                if (clients[i].Id == id)
                {
                    clients.Remove(clients[i]);
                }
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
        /// Por la guía Expert, RepoClients contiene la información para ser responsable de buscar los clientes.
        /// Busca un cliente por su Id, que es única.
        /// </summary>
        /// <param name="id">Id del cliente</param>
        /// <returns>Cliente con la Id correspondiente</returns>
        public Client SearchClientById(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentException("Debe escribir un id válido", nameof(id));
            }
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
        /// Por la guía Expert, RepoClients contiene la información para ser responsable de buscar los clientes.
        /// Busca los clientes que cumplan con dato ingresado.
        /// </summary>
        /// <param name="datasearched">Tipo de dato a buscar</param>
        /// <param name="serdched">Nombre, Apellido, Mail o Teléfono a buscar</param>
        /// <returns>Lista de clientes buscados</returns>
        public List<Client> SearchClient(TypeOfData datasearched, string searched)
        {
            if (string.IsNullOrEmpty(searched))
            {
                throw new ArgumentException("Debe escribir un dato válido", nameof(searched));
            }

            if (string.IsNullOrEmpty(datasearched.ToString()))
            {
                throw new ArgumentException("Debe utilizar un tipo de dato existente", nameof(datasearched));
            }
            List<Client> result = new List<Client>();
            if (datasearched == TypeOfData.Name)
            {
                foreach (var client in clients)
                {
                    if (client.Name == searched)
                    {
                        result.Add(client);
                    }
                }
            }
            else if (datasearched == TypeOfData.LastName)
            {
                foreach (var client in clients)
                {
                    if (client.LastName == searched)
                    {
                        result.Add(client);
                    }
                }
            }
            else if (datasearched == TypeOfData.Email) 
            { 
                foreach (var client in clients)
                {
                    if (client.Email == searched)
                    {
                        result.Add(client);
                    }
                }
            }
            else if (datasearched == TypeOfData.Phone) 
            { 
                foreach (var client in clients)
                {
                    if (client.Phone == searched)
                    {
                        result.Add(client);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// RepoClients contiene los clientes, entonces tiene los datos suficientes para buscar los que estan inactivos.
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
        /// RepoClients contiene los clientes, entonces tiene los datos suficientes para buscar los que estan esperando.
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
        /// Al contener a los clientes, RepoClients es el experto en información de los clientes.
        /// Para no violar Demeter, se crearon en Client GetInteractions y GetFutureMeetings.
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
                recentInteractions += client.GetInteractions();
                futureMeetings += client.GetFutureMeetings();
            }
            return ($"Clientes totales: {this.Clients.Count}\n" + $"Interacciones en este último mes: {recentInteractions}\n" + $"Reuniones próximas {futureMeetings}");
        }
        
        /// <summary>
        /// Al contener a los clientes, RepoClients es el experto en información de los clientes.
        /// Para no violar Demeter existe GetTotalSales en Client.
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
                totalSales = client.GetTotalSales(startdate,finishdate);
            }
            return $"Cantidad de ventas dentro del período: {totalSales}";
        }
    }
}