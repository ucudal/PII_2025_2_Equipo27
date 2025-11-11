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
        private RepoClients repoClients = new RepoClients();

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
        public void CreateClient(string name, string lastName, string email, string phone, Client.GenderType gender, string birthDate, Seller seller)
        {
            repoClients.CreateClient(name, lastName, email, phone, gender, birthDate, seller);
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
        /// Busca cliente por nombre, apellido mail o teléfono.
        /// </summary>
        /// <param name="dataSerched">Name, LastName, Email o Phone</param>
        /// <param name="text">El dato del cliente que se quierer buscar</param>
        /// <returns></returns>
        public List<Client> SearchClient(RepoClients.TypeOfData dataSerched, string text)
        {
            return repoClients.SearchClient(dataSerched, text);
        }
        
        // /// <summary>
        // /// Busca clientes por nombre.
        // /// </summary>
        // /// <param name="name">Nombre del cliente</param>
        // /// <returns>Lista coincidente</returns>
        // public List<Client> SearchClientByName(string name)
        // {
        //     return repoClients.SearchClientByName(name);
        // }
        //
        // /// <summary>
        // /// Busca clientes por apellido.
        // /// </summary>
        // /// <param name="lastname">Apellido del cliente</param>
        // /// <returns>Lista coincidente</returns>
        // public List<Client> SearchClientByLastName(string lastname)
        // {
        //     return repoClients.SearchClientByLastName(lastname);
        // }
        //
        // /// <summary>
        // /// Busca clientes por email.
        // /// </summary>
        // /// <param name="email">Email del cliente</param>
        // /// <returns>Lista coincidente</returns>
        // public List<Client> SearchClientByEmail(string email)
        // {
        //     return repoClients.SearchClientByEmail(email);
        // }
        //
        // /// <summary>
        // /// Busca clientes por teléfono.
        // /// </summary>
        // /// <param name="phone">Teléfono</param>
        // /// <returns>Lista coincidente</returns>
        // public List<Client> SearchClientByPhone(string phone)
        // {
        //     return repoClients.SearchClientByPhone(phone);
        // }

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
        public void CreateOportunity(string Product, int price, Opportunity.States states, Client client)
        {
            client.CreateOportunity(Product, price, states, client, DateTime.Now);
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
        /// Registra una llamada realizada a un cliente.
        /// </summary>
        /// <param name="content">Contenido de la llamada</param>
        /// <param name="notes">Notas</param>
        /// <param name="client">Cliente involucrado</param>
        /// <param name="interactionDate">Fecha de interacción (opcional)</param>
        public void RegisterCall(string content, string notes, Client client, DateTime? interactionDate = null)
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
        public void RegisterEmail(string content, InteractionOrigin.Origin sender, string notes, Client client, DateTime? interactionDate = null)
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
        public void RegisterMeeting(string content, string notes, string location, Meeting.MeetingState type, Client client, DateTime interactionDate )
        {
            Meeting meeting = new Meeting(content, notes, location, type, interactionDate);
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
        public void RegisterMessage(string content, string notes, InteractionOrigin.Origin sender, string channel, Client client, DateTime? interactionDate = null)
        {
            Message message = new Message(content, notes, sender, channel, DateTime.Now);
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
    }
}
