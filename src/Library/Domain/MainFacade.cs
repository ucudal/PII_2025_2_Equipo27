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
        private RepoTags repoTag = RepoTags.Instance;

        protected RepoUsers RepoUsers = RepoUsers.Instance;



            /// <summary>
            /// Crea un nuevo cliente y lo agrega al repositorio.
            /// </summary>
            /// <param name="name">Nombre del cliente</param>
            /// <param name="lastName">Apellido del cliente</param>
            /// <param name="email">Email del cliente</param>
            /// <param name="phone">Teléfono del cliente</param>
            /// <param name="sellerId">Id del vendedor responsable</param>
        public Client CreateClient(string name, string lastName, string email, string phone, string sellerId)
        {
            int intSellerId;
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("El cliente debe tener un nombre", nameof(name));
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("El cliente debe tener un apellido", nameof(lastName));
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("El cliente debe tener un emial", nameof(email));
            }

            if (string.IsNullOrEmpty(phone))
            {
                throw new ArgumentException("El cliente debe tener un número de teléfono", nameof(phone));
            }

            if (!(int.TryParse(sellerId, out intSellerId)) || RepoUsers.SearchUser<Seller>(intSellerId) == null)
            {
                throw new ArgumentException("El ID del seller no es valido", nameof(sellerId));
            }

            Seller seller = RepoUsers.SearchUser<Seller>(intSellerId);
            return repoClients.CreateClient(name, lastName, email, phone, seller);
        }

        /// <summary>
        /// Añade nuevos datos al cliente, ya sea fecha de nacimiento o genero.
        /// </summary>
        /// <param name="clientid"></param>
        /// <param name="data"></param>
        /// <param name="modification"></param>
        public void AddData(string id, string typeOfData, string modification)
        {
            RepoClients.TypeOfData datatype = 0;
            Client client = repoClients.GetById(int.Parse(id));
            if (client == null)
            {
                throw new ArgumentException("Cliente no encontrado.");
            }

            if (typeOfData.ToLower() == RepoClients.TypeOfData.BirthDate.ToString().ToLower())
            {
                datatype = RepoClients.TypeOfData.BirthDate;
            }
            else if (typeOfData.ToLower() == RepoClients.TypeOfData.Gender.ToString().ToLower())
            {
                datatype = RepoClients.TypeOfData.Gender;
            }
            else
            {
                throw new ArgumentException("El tipo de datos a añadir debe ser 'BirthDate' o 'Gender'");
            }

            client.AddData(datatype, modification);
        }

        /// <summary>
        /// Devuelve el listado completo de clientes registrados.
        /// </summary>
        /// <returns>Lista de clientes</returns>
        public IReadOnlyList<Client> GetClients()
        {
            return repoClients.GetAll();
        }

        /// <summary>
        /// Elimina un cliente del repositorio según su ID.
        /// </summary>
        /// <param name="id">ID del cliente</param>
        public void DeleteClient(string id)
        {
            repoClients.Remove(int.Parse(id));
        }

        /// <summary>
        /// Busca un cliente por su Id, que es única.
        /// </summary>
        /// <param name="id"> Id del cliente a buscar</param>
        /// <returns>Cliente con la Id buscada</returns>
        public Client SearchClientById(string id)
        {
            return repoClients.GetById(int.Parse(id));
        }

        /// <summary>
        /// Busca cliente por nombre, apellido mail o teléfono.
        /// </summary>
        /// <param name="dataSerched">Name, LastName, Email o Phone</param>
        /// <param name="text">El dato del cliente que se quierer buscar</param>
        /// <returns>Lista con clientes buscados</returns>
        public List<Client> SearchClient(string dataSearched, string text)
        {
            RepoClients.TypeOfData typeOfData = 0;
            if (dataSearched == RepoClients.TypeOfData.Email.ToString())
            {
                typeOfData = RepoClients.TypeOfData.Email;
            }
            else if (dataSearched == RepoClients.TypeOfData.Name.ToString())
            {
                typeOfData = RepoClients.TypeOfData.Name;
            }
            else if (dataSearched == RepoClients.TypeOfData.LastName.ToString())
            {
                typeOfData = RepoClients.TypeOfData.LastName;
            }
            else if (dataSearched == RepoClients.TypeOfData.Phone.ToString())
            {
                typeOfData = RepoClients.TypeOfData.Phone;
            }
            else
            {
                throw new ArgumentException(
                    "El tipo de datos a buscar debe ser 'Name' o 'LastName' o 'Email' o 'Phone'");
            }

            return repoClients.SearchClient(typeOfData, text);

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
        public void ModifyClient(string id, string modified, string modification)
        {
            Client client = repoClients.GetById(int.Parse(id));
            if (modified == RepoClients.TypeOfData.Name.ToString())
            {
                client.ModifyClient(RepoClients.TypeOfData.Name, modification);
            }
            else if (modified == RepoClients.TypeOfData.LastName.ToString())
            {
                client.ModifyClient(RepoClients.TypeOfData.LastName, modification);

            }
            else if (modified == RepoClients.TypeOfData.Email.ToString())
            {
                client.ModifyClient(RepoClients.TypeOfData.Email, modification);

            }
            else if (modified == RepoClients.TypeOfData.Phone.ToString())
            {
                client.ModifyClient(RepoClients.TypeOfData.Phone, modification);

            }
            else
            {
                throw new ArgumentException(
                    "El tipo de datos a modificar debe ser 'Name' o 'LastName' o 'Email' o 'Phone'");
            }
        }

        /// <summary>
        /// Crea una oportunidad asociada al cliente.
        /// </summary>
        /// <param name="Product">Producto</param>
        /// <param name="price">Precio</param>
        /// <param name="states">Estado de la oportunidad</param>
        /// <param name="client">Cliente asociado</param>
        public Opportunity CreateOpportunity(string product, string price, string state, string clientid)
        {
            Client client = this.SearchClientById(clientid);
            Opportunity.States states = 0;
            if (state == Opportunity.States.Canceled.ToString())
            {
                states = Opportunity.States.Canceled;
            }
            else if (state == Opportunity.States.Open.ToString())
            {
                states = Opportunity.States.Open;
            }
            else if (state == Opportunity.States.Close.ToString())
            {
                states = Opportunity.States.Close;
            }
            else
            {
                throw new ArgumentException("El estado de la oportunidad debe ser o 'Closed' o 'Canceled' o 'Open'");
            }

            return client.CreateOpportunity(product, int.Parse(price), states, client, DateTime.Now);
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
        public void AddTag(string clientid, string tagid)
        {
            Client client = this.SearchClientById(clientid);
            Tag tag = repoTag.GetById(int.Parse(tagid));
            client.AddTag(tag);
        }

        /// <summary>
        /// Retorna una IReadOnlyList con todos los Tags creados.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Tag> GetTags()
        {
            return repoTag.GetAll();
        }

        /// <summary>
        /// Registra una llamada realizada a un cliente.
        /// </summary>
        /// <param name="content">Contenido de la llamada</param>
        /// <param name="notes">Notas</param>
        /// <param name="client">Cliente involucrado</param>
        /// <param name="interactionDate">Fecha de interacción (opcional)</param>

        public void RegisterCall(string content, string notes, string clientid)
        {
            Client client = this.SearchClientById(clientid);
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
        public void RegisterEmail(string content, string sender, string notes, string clientid)
        {
            Client client = this.SearchClientById(clientid);
            if (sender == InteractionOrigin.Origin.Received.ToString())
            {
                Email email = new Email(content, InteractionOrigin.Origin.Received, notes, DateTime.Now);
                client.AddInteraction(email);
            }
            else if (sender == InteractionOrigin.Origin.Sent.ToString())
            {
                Email email = new Email(content, InteractionOrigin.Origin.Sent, notes, DateTime.Now);
                client.AddInteraction(email);
            }
            else
            {
                throw new ArgumentException("El estado de la llamada debe ser o 'Sent' o 'Received'");
            }
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
        public void RegisterMeeting(string content, string notes, string location, string type,
            string clientid, string date)
        {
            Client client = this.SearchClientById(clientid);
            if (type == Meeting.MeetingState.Programmed.ToString())
            {
                Meeting meeting = new Meeting(content, notes, location, Meeting.MeetingState.Programmed,
                    DateTime.Parse(date));
                client.AddInteraction(meeting);
            }
            else if (type == Meeting.MeetingState.Canceled.ToString())
            {
                Meeting meeting = new Meeting(content, notes, location, Meeting.MeetingState.Canceled,
                    DateTime.Parse(date));
                client.AddInteraction(meeting);
            }
            else if (type == Meeting.MeetingState.Done.ToString())
            {
                Meeting meeting = new Meeting(content, notes, location, Meeting.MeetingState.Done,
                    DateTime.Parse(date));
                client.AddInteraction(meeting);
            }
            else
            {
                throw new ArgumentException("El tipo de la reunión debe ser o 'Done' o 'Canceled' o 'Programmed'");
            }
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
        public void RegisterMessage(string content, string notes, string sender, string channel,
            string clientid)
        {
            Client client = this.SearchClientById(clientid);

            if (sender == InteractionOrigin.Origin.Received.ToString())
            {
                Message message = new Message(content, notes, InteractionOrigin.Origin.Received, channel, DateTime.Now);
                client.AddInteraction(message);
            }
            else if (sender == InteractionOrigin.Origin.Sent.ToString())
            {
                Message message = new Message(content, notes, InteractionOrigin.Origin.Sent, channel, DateTime.Now);
                client.AddInteraction(message);
            }
            else
            {
                throw new ArgumentException("El estado del mensaje debe ser o 'Sent' o 'Received'");
            }
        }

        public string GetPanel()
        {
            return this.repoClients.GetPanel();
        }

        public void SwitchClientActivity(string id)
        {
            foreach (Client client in repoClients.GetAll())
            {
                if (client.Id.ToString() == id)
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

        public void SwitchClientWaiting(string id)
        {
            foreach (Client client in repoClients.GetAll())
            {
                if (client.Id.ToString() == id)
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

        public void AddNotes(string interactionid, string note, string clientid)
        {
            Client client = this.SearchClientById(clientid);
            foreach (Interaction i in client.Interactions)
            {
                if (i.Id.ToString() == interactionid)
                {
                    i.Notes = note;
                }
            }
        }
    }
}

