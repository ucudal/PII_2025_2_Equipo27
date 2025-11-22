using System;
using System.Collections.Generic;
using Library.interactions;

namespace Library
{
    /// <summary>
    /// Fachada principal que gestiona todas las operaciones comunes de clientes, oportunidades y registro de interacciones.
    /// </summary>
    public class MainFacade
    {
        protected RepoClients repoClients = RepoClients.Instance;
        private RepoTag repoTag = new RepoTag();
        protected RepoUser RepoUsers = RepoUser.Instance;
        

        /// <summary>
        /// Crea un nuevo cliente y lo agrega al repositorio.
        /// </summary>
        /// <param name="name">Nombre del cliente</param>
        /// <param name="lastName">Apellido del cliente</param>
        /// <param name="email">Email del cliente</param>
        /// <param name="phone">Teléfono del cliente</param>
        /// <param name="gender">Género del cliente</param>
        /// <param name="birthDate">Fecha de nacimiento (string)</param>
        /// <param name="seller">Vendedor responsable</param>
        public Client CreateClient(string name, string lastName, string email, string phone, Client.GenderType gender, string birthDate, Seller seller)
        {
            return repoClients.CreateClient(name, lastName, email, phone, gender, birthDate, seller);
        }

        /// <summary>
        /// Devuelve el listado completo de clientes registrados.
        /// </summary>
        /// <returns>Lista de clientes</returns>
        public IReadOnlyList<Client> GetClients()
        {
            return repoClients.Clients;
        }

        /// <summary>
        /// Elimina un cliente del repositorio según su ID.
        /// </summary>
        /// <param name="id">ID del cliente</param>
        public void DeleteClient(int id)
        {
            repoClients.DeleteClient(id);
        }

        /// <summary>
        /// Busca un cliente por su Id, que es única.
        /// </summary>
        /// <param name="id"> Id del cliente a buscar</param>
        /// <returns>Cliente con la Id buscada</returns>
        public Client SearchClientById(int id)
        {
            return repoClients.SearchClientById(id);
        }

        /// <summary>
        /// Busca cliente por nombre, apellido mail o teléfono.
        /// </summary>
        /// <param name="dataSerched">Name, LastName, Email o Phone</param>
        /// <param name="text">El dato del cliente que se quierer buscar</param>
        /// <returns>Lista con clientes buscados</returns>
        public List<Client> SearchClient(RepoClients.TypeOfData dataSerched, string text)
        {
            return repoClients.SearchClient(dataSerched, text);
        }

        /// <summary>
        /// Devuelve lista de clientes inactivos.
        /// </summary>
        /// <returns>Clientes inactivos</returns>
        public List<Client> InactiveClients()
        {
            return repoClients.InactiveClients();
        }

        /// <summary>
        /// Devuelve lista de clientes en estado de espera.
        /// </summary>
        /// <returns>Clientes en espera</returns>
        public List<Client> WaitingClients()
        {
            return repoClients.WaitingClients();
        }

        /// <summary>
        /// Modifica un campo del cliente (email, apellido, nombre, teléfono).
        /// </summary>
        /// <param name="client">Cliente a modificar</param>
        /// <param name="modified">Tipo de dato a modificar</param>
        /// <param name="modification">Nuevo valor</param>
        public void ModifyClient(Client client, RepoClients.TypeOfData modified, string modification)
        {
            if (modified == RepoClients.TypeOfData.Email)
            {
                client.Email = modification;
            }
            else if (modified == RepoClients.TypeOfData.LastName)
            {
                client.LastName = modification;
            }
            else if (modified == RepoClients.TypeOfData.Name)
            {
                client.Name = modification;
            }
            else if (modified == RepoClients.TypeOfData.Phone)
            {
                client.Phone = modification;
            }
        }

        /// <summary>
        /// Crea una oportunidad asociada al cliente.
        /// </summary>
        /// <param name="Product">Producto</param>
        /// <param name="price">Precio</param>
        /// <param name="states">Estado de la oportunidad</param>
        /// <param name="client">Cliente asociado</param>
        public Opportunity CreateOpportunity(string product, int price, Opportunity.States states, Client client)
        {
            return client.CreateOpportunity(product, price, states, client, DateTime.Now);
        }

        /// <summary>
        /// Crea un Tag y lo guarda.
        /// </summary>
        /// <param name="tagName">Nombre del Tag</param>
        public Tag CreateTag(string tagName)
        {
            return repoTag.CreateTag(tagName);
        }

        /// <summary>
        /// Asocia un tag al cliente.
        /// </summary>
        /// <param name="client">Cliente</param>
        /// <param name="tag">Tag a asociar</param>
        public void AddTag(Client client, Tag tag)
        {
            client.AddTag(tag);
        }

        /// <summary>
        /// Retorna una IReadOnlyList con todos los Tags creados.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Tag> GetTags()
        {
            return repoTag.TagList;
        }

        /// <summary>
        /// Registra una llamada realizada a un cliente.
        /// </summary>
        /// <param name="content">Contenido de la llamada</param>
        /// <param name="notes">Notas</param>
        /// <param name="client">Cliente involucrado</param>
        /// <param name="interactionDate">Fecha de interacción (opcional)</param>
        public void RegisterCall(string content, string notes, Client client)
        {
            RegisterCall(content, notes, client,DateTime.Now);
        }

        public void RegisterCall(string content, string notes, Client client, DateTime date)
        {
            
            Call call = new Call(content, notes, DateTime.Now);
            client.AddInteraction(call);
        }

        /// <summary>
        /// Registra un email enviado a un cliente.
        /// </summary>
        /// <param name="content">Contenido</param>
        /// <param name="sender">Origen</param>
        /// <param name="notes">Notas</param>
        /// <param name="client">Cliente involucrado</param>
        /// <param name="interactionDate">Fecha de interacción (opcional)</param>
        public void RegisterEmail(string content, InteractionOrigin.Origin sender, string notes, Client client)
        {
            
            RegisterEmail(content, sender, notes, client,DateTime.Now);
        }

        public void RegisterEmail(string content, InteractionOrigin.Origin sender, string notes, Client client,
            DateTime date)
        {
            
            Email email = new Email(content, sender, notes, DateTime.Now);
            client.AddInteraction(email);
        }

        /// <summary>
        /// Registra una reunión con un cliente.
        /// </summary>
        /// <param name="content">Resumen de reunión</param>
        /// <param name="notes">Notas</param>
        /// <param name="location">Lugar</param>
        /// <param name="type">Estado de la reunión</param>
        /// <param name="client">Cliente involucrado</param>
        /// <param name="interactionDate">Fecha de interacción (opcional)</param>
        public void RegisterMeeting(string content, string notes, string location, Meeting.MeetingState type,
            Client client)
        {
            RegisterMeeting(content, notes, location, type, client, DateTime.Now);
        }
        public void RegisterMeeting(string content, string notes, string location, Meeting.MeetingState type,
            Client client, DateTime date)
        {
            Meeting meeting = new Meeting(content, notes, location, type, date);
            client.AddInteraction(meeting);
        }

        /// <summary>
        /// Registra un mensaje enviado al cliente.
        /// </summary>
        /// <param name="content">Mensaje</param>
        /// <param name="notes">Notas</param>
        /// <param name="sender">Origen</param>
        /// <param name="channel">Canal de contacto</param>
        /// <param name="client">Cliente involucrado</param>
        /// <param name="interactionDate">Fecha de interacción (opcional)</param>
        public void RegisterMessage(string content, string notes, InteractionOrigin.Origin sender, string channel,
            Client client)
        {
            RegisterMessage(content, notes, sender, channel, client, DateTime.Now);
        }
        
        public void RegisterMessage(string content, string notes, InteractionOrigin.Origin sender, string channel,
            Client client, DateTime date)
        {
            Message message = new Message(content, notes, sender, channel, date);
            client.AddInteraction(message);
        }

        public string GetPanel()
        {
            return this.repoClients.GetPanel();
        }

        public void SwitchClientActivity(int id)
        {
            foreach (Client client in repoClients.Clients)
            {
                if (client.Id == id)
                {
                    if (client.Inactive == true)
                    {
                        client.Inactive = false;
                    }
                    else
                    {
                        client.Inactive = true;
                    }
                }
            }
        }

        public void SwitchClientWaiting(int id)
        {
            foreach (Client client in repoClients.Clients)
            {
                if (client.Id == id)
                {
                    if (client.Waiting == true)
                    {
                        client.Waiting = false;
                    }
                    else
                    {
                        client.Waiting = true;
                    }
                }
            }
        }

        public void AddNotes(Interaction interaction, string note)
            {
                interaction.Notes = note;

            }
        }
    }

