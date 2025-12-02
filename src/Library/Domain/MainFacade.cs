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
        /// Crea un nuevo cliente y lo agrega al repositorio a partir de los datos proporcionados por el bot.
        /// MainFacade funciona como fachada hacia RepoClients, delegando la creación al experto en clientes.
        /// Aplicación de los patrones y principios:
        /// - Expert: La creación real del cliente se delega a RepoClients, que es el experto en gestionar clientes.
        /// - SRP: La responsabilidad de este método es recibir los datos en formato string desde la capa de comandos y delegar la creación del cliente al repositorio correspondiente.
        /// </summary>
        /// <param name="name">Nombre del cliente</param>
        /// <param name="lastName">Apellido del cliente</param>
        /// <param name="email">Email del cliente</param>
        /// <param name="phone">Teléfono del cliente</param>
        /// <param name="sellerid">Id del vendedor responsable.</param>
        /// <returns>Cliente creado.</returns>

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
        /// Añade nuevos datos al cliente (fecha de nacimiento o género) a partir de información recibida en formato string.
        /// MainFacade actúa delegando la modificación al cliente correspondiente.
        /// Aplicación de los patrones y principios:
        /// - Expert: La validación y modificación final de los datos se delega a Client, que es el experto en su propia información.
        /// - SRP: La responsabilidad de este método es localizar al cliente por su id, interpretar el tipo de dato recibido como string y delegar en Client la actualización del valor.
        /// </summary>
        /// <param name="id">Id del cliente al que se le añadirán los datos.</param>
        /// <param name="typeOfData">Tipo de dato a añadir (“BirthDate” o “Gender”).</param>
        /// <param name="modification">Nuevo valor para el dato especificado.</param>
        public void AddData(string id, string typeOfData, string modification)
        {
            RepoClients.TypeOfData datatype = 0;
            string birthDate = "birthdate";
            string gender = "gender";
            Client client = repoClients.GetById(int.Parse(id));
            if (client == null)
            {
                throw new ArgumentException("Cliente no encontrado.");
            }
            if (typeOfData.ToLower() == birthDate)
            {
                datatype = RepoClients.TypeOfData.BirthDate;
            }
            else if (typeOfData.ToLower() == gender)
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
        /// Devuelve el listado completo de clientes registrados desde el repositorio.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients es el experto en la información de los clientes y MainFacade delega en él la obtención de los datos.
        /// - SRP: La responsabilidad de este método es devolver a la capa superior la colección de clientes gestionada por el repositorio.
        /// </summary>
        /// <returns>Lista de clientes.</returns>

        public IReadOnlyList<Client> GetClients()
        {
            return repoClients.GetAll();
        }

        /// <summary>
        /// Elimina un cliente del repositorio según su ID.
        /// MainFacade  delega la eliminación al repositorio de clientes, que es el experto en gestionarlos.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients es el experto en la información y el ciclo de vida de los clientes, por eso realiza la eliminación.
        /// - SRP: La responsabilidad de este método es eliminar un cliente identificado por su ID recibido como string, delegando la operación concreta al repositorio.
        /// </summary>
        /// <param name="id">ID del cliente.</param>

        public void DeleteClient(string id)
        {
            repoClients.Remove(int.Parse(id));
        }

        /// <summary>
        /// Busca un cliente por su Id, que es única, utilizando el repositorio de clientes.
        /// MainFacade  delega la búsqueda al repositorio, que es el experto en gestionar clientes.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients es el experto en la información y ubicación de los clientes, por eso realiza la búsqueda real.
        /// - SRP: La responsabilidad de este método es recibir el Id como string desde la capa de comandos y devolver el cliente correspondiente delegando la búsqueda al repositorio.
        /// </summary>
        /// <param name="id">Id del cliente a buscar.</param>
        /// <returns>Cliente con la Id buscada.</returns>

        public Client SearchClientById(string id)
        {
            return repoClients.GetById(int.Parse(id));
        }

        /// <summary>
        /// Busca clientes por nombre, apellido, email o teléfono y devuelve la lista de coincidencias.
        /// MainFacade delega la búsqueda al repositorio de clientes.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients es el experto en la información de los clientes y realiza la búsqueda real en la colección.
        /// - SRP: La responsabilidad de este método es interpretar el tipo de dato de búsqueda recibido como texto y delegar la búsqueda de clientes al repositorio.
        /// </summary>
        /// <param name="dataSearched">Name, LastName, Email o Phone.</param>
        /// <param name="text">Dato del cliente que se quiere buscar.</param>
        /// <returns>Lista con los clientes que cumplen el criterio de búsqueda.</returns>

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
        /// Devuelve la lista de clientes inactivos obtenida del repositorio de clientes.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients es el experto en la información de los clientes y determina cuáles están inactivos.
        /// - SRP: La responsabilidad de este método es devolver a la capa superior la lista de clientes inactivos que proporciona el repositorio.
        /// </summary>
        /// <returns>Clientes inactivos.</returns>

        public List<Client> InactiveClients()
        {
            return repoClients.InactiveClients();
        }

        /// <summary>
        /// Devuelve la lista de clientes en estado de espera obtenida del repositorio de clientes.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients es el experto en la información de los clientes y determina cuáles están en estado de espera.
        /// - SRP: La responsabilidad de este método es devolver a la capa superior la lista de clientes en espera que proporciona el repositorio.
        /// </summary>
        /// <returns>Clientes en espera.</returns>

        public List<Client> WaitingClients()
        {
            return repoClients.WaitingClients();
        }

        /// <summary>
        /// Modifica un campo del cliente (email, apellido, nombre o teléfono) a partir de datos recibidos como texto.
        /// MainFacade interpreta el tipo de dato a modificar y delega la actualización en el cliente correspondiente.
        /// Aplicación de los patrones y principios:
        /// - Expert: La modificación concreta del dato se delega a Client, que es el experto en su propia información.
        /// - SRP: La responsabilidad de este método es localizar al cliente por su Id, interpretar el tipo de dato a modificar y solicitar al cliente que actualice el valor indicado.
        /// </summary>
        /// <param name="id">Id del cliente a modificar.</param>
        /// <param name="modified">Tipo de dato a modificar: Name, LastName, Email o Phone.</param>
        /// <param name="modification">Nuevo valor para el campo especificado.</param>

        public void ModifyClient(string id, string modified, string modification)
        {
            Client client = repoClients.GetById(int.Parse(id));
            if (modified == RepoClients.TypeOfData.Name.ToString())
            {
                client.ModifyClient(RepoClients.TypeOfData.Name,modification);
            }
            else if (modified == RepoClients.TypeOfData.LastName.ToString())
            {
                client.ModifyClient(RepoClients.TypeOfData.LastName,modification);
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
        /// Crea una oportunidad asociada a un cliente a partir de datos recibidos como texto.
        /// Aplicación de los patrones y principios:
        /// - Expert: La creación efectiva de la oportunidad se delega al Client, que es el experto en sus propias oportunidades.
        /// - SRP: La responsabilidad de este método es localizar al cliente, interpretar el estado y el precio recibidos como texto y solicitar al cliente que cree la oportunidad con esos datos.
        /// </summary>
        /// <param name="product">Producto de la oportunidad.</param>
        /// <param name="price">Precio de la oportunidad (string numérico).</param>
        /// <param name="state">Estado de la oportunidad: Open, Close o Canceled.</param>
        /// <param name="clientid">Id del cliente asociado.</param>
        /// <returns>Oportunidad creada.</returns>

        public Opportunity CreateOpportunity(string product, string price, string state, string clientid)
        {
            Client client = this.SearchClientById(clientid);
            if (client == null)
            {
                throw new ArgumentException("No existe un cliente con le ID ingresado.");
            }
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
        /// Crea un nuevo Tag y lo guarda mediante el repositorio de tags.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoTag es el experto en la información y persistencia de los tags, por eso realiza la creación real.
        /// - SRP: La responsabilidad de este método es recibir el nombre del tag desde la capa de comandos y delegar su creación y guardado al repositorio de tags.
        /// </summary>
        /// <param name="tagName">Nombre del Tag.</param>

        public Tag CreateTag(string tagName)
        {
            return repoTag.CreateTag(tagName);
        }

        /// <summary>
        /// Asocia un tag a un cliente existente utilizando sus identificadores.
        /// Aplicación de los patrones y principios:
        /// - Expert: Client es el experto en sus propios tags, por eso la asociación final se realiza mediante su método AddTag.
        /// - SRP: La responsabilidad de este método es obtener el cliente y el tag a partir de sus ids y pedir al cliente que agregue dicho tag.
        /// </summary>

        /// <param name="clientId">Id del Cliente</param>
        /// <param name="tagName">Nombre del Tag a asociar</param>
        public void AddTag(string clientId, string tagName)
        {
            Client client = this.SearchClientById(clientId);
            Tag tag = repoTag.Search(tagName);
            if (tag == null)
            {
                tag = repoTag.CreateTag(tagName);
            }
            client.AddTag(tag);
        }

        /// <summary>
        /// Retorna una IReadOnlyList con todos los Tags creados.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoTag es el experto en la información y almacenamiento de los tags, por eso provee la lista completa.
        /// - SRP: La responsabilidad de este método es devolver a la capa superior la colección de tags obtenida del repositorio sin modificarla.
        /// </summary>
        /// <returns>Lista de tags creados.</returns>

        public IReadOnlyList<Tag> GetTags()
        {
            return repoTag.GetAll();
        }

        /// <summary>
        /// Registra una llamada realizada a un cliente y la asocia como interacción.
        /// Aplicación de los patrones y principios:
        /// - Expert: La interacción se agrega mediante Client, que es el experto en gestionar sus propias interacciones.
        /// - SRP: La responsabilidad de este método es crear la llamada con los datos recibidos y pedir al cliente correspondiente que la registre como interacción.
        /// </summary>
        /// <param name="content">Contenido de la llamada.</param>
        /// <param name="notes">Notas asociadas a la llamada.</param>
        /// <param name="clientid">Id del cliente involucrado.</param>


        public void RegisterCall(string content, string notes, string clientid)
        {
            Client client = this.SearchClientById(clientid);
            Call call = new Call(content, notes,InteractionOrigin.Origin.Sent ,DateTime.Now);
            client.AddInteraction(call);
        }

        /// <summary>
        /// Registra un email enviado a un cliente y lo asocia como interacción.
        /// Aplicación de los patrones y principios:
        /// - Expert: La interacción se agrega mediante Client, que es el experto en gestionar sus propias interacciones.
        /// - SRP: La responsabilidad de este método es interpretar el origen del email recibido como texto, crear la interacción correspondiente y pedir al cliente que la registre.
        /// </summary>
        /// <param name="content">Contenido del email.</param>
        /// <param name="sender">Origen del email: Sent o Received.</param>
        /// <param name="notes">Notas asociadas al email.</param>
        /// <param name="clientid">Id del cliente involucrado.</param>

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
        /// Registra una reunión con un cliente y la asocia como interacción.
        /// Aplicación de los patrones y principios:
        /// - Expert: La interacción se agrega mediante Client, que es el experto en gestionar sus propias interacciones y reuniones.
        /// - SRP: La responsabilidad de este método es interpretar el estado y la fecha de la reunión recibidos como texto, crear la reunión correspondiente y pedir al cliente que la registre.
        /// </summary>
        /// <param name="content">Resumen de la reunión.</param>
        /// <param name="notes">Notas asociadas a la reunión.</param>
        /// <param name="location">Lugar de la reunión.</param>
        /// <param name="type">Estado de la reunión: Done, Canceled o Programmed.</param>
        /// <param name="clientid">Id del cliente involucrado.</param>
        /// <param name="date">Fecha de la reunión en formato texto.</param>

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
        /// Registra un mensaje enviado o recibido de un cliente y lo asocia como interacción.
        /// Aplicación de los patrones y principios:
        /// - Expert: La interacción se agrega mediante Client, que es el experto en gestionar sus propias interacciones y mensajes.
        /// - SRP: La responsabilidad de este método es interpretar el origen del mensaje recibido como texto, crear el mensaje correspondiente y pedir al cliente que lo registre.
        /// </summary>
        /// <param name="content">Contenido del mensaje.</param>
        /// <param name="notes">Notas asociadas al mensaje.</param>
        /// <param name="sender">Origen del mensaje: Sent o Received.</param>
        /// <param name="channel">Canal de contacto utilizado.</param>
        /// <param name="clientid">Id del cliente involucrado.</param>

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

        /// <summary>
        /// Devuelve el panel de información general de clientes generado por RepoClients.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients es el experto en la información consolidada de los clientes y construye el panel.
        /// - SRP: La responsabilidad de este método es obtener el panel ya generado por RepoClients y retornarlo a la capa superior.
        /// </summary>
        /// <returns>Texto con el panel de información de clientes.</returns>
        public string GetPanel()
        {
            return this.repoClients.GetPanel();
        }

        /// <summary>
        /// Cambia el estado de actividad de un cliente (activo/inactivo) según su Id.
        /// Aplicación de los patrones y principios:
        /// - Expert: El cambio de estado se realiza sobre Client, que es el experto en su propia información y estado de actividad.
        /// - SRP: La responsabilidad de este método es localizar al cliente por su Id en el repositorio y alternar su estado de actividad entre activo e inactivo.
        /// </summary>
        /// <param name="id">Id del cliente cuyo estado de actividad se va a cambiar.</param>

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

        
        /// <summary>
        /// Agrega o actualiza las notas de una interacción específica de un cliente.
        /// Aplicación de los patrones y principios:
        /// - Expert: La nota se modifica sobre la propia Interaction del cliente, que es el experto en su información de detalle.
        /// - SRP: La responsabilidad de este método es localizar la interacción dentro de un cliente por su Id y actualizar su campo de notas.
        /// </summary>
        /// <param name="interactionid">Id de la interacción a la que se agregarán las notas.</param>
        /// <param name="note">Texto de la nota a guardar.</param>
        /// <param name="clientid">Id del cliente que contiene la interacción.</param>
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

