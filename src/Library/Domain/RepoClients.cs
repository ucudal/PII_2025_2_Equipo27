using System;
using System.Collections.Generic;

namespace Library
{
    public class RepoClients
    {
        /// <summary>
        /// Para una mejor encapsulación de las listas se utiliza IReadOnlyList y otra lista privada.
        /// </summary>

        private static RepoClients instance = null;

        public static RepoClients Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepoClients();
                }

                return instance;
            }
        }
        public static void ResetInstance()
        {
            instance = null;
        }
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

        private RepoClients()
        {
            // Intencionalmente en blanco
        }
        
        /// <summary>
        /// Crea y registra un nuevo cliente en el sistema.
        /// RepoClients contiene instancias de Client y debe crearlos siguiendo el patrón Creator.
        /// Aplicación de los patrones y principios:
        /// - Creator: RepoClients es responsable de crear clientes porque gestiona la colección y su ciclo de vida.
        /// - Expert: RepoClients tiene la información y lógica para asignar datos y generar identificadores.
        /// - SRP: Responsabilidad clara, solo crea y registra un cliente.
        /// </summary>
        /// <param name="name">Nombre del Cliente.</param>
        /// <param name="lastName">Apellido del Cliente.</param>
        /// <param name="email">Email del Cliente.</param>
        /// <param name="phone">Número de teléfono del Cliente.</param>
        /// <param name="gender">Sexo del Cliente.</param>
        /// <param name="birthDate">Fecha de nacimiento del Cliente.</param>
        /// <param name="seller">Vendedor asignado al Cliente.</param>
        /// <returns>Cliente creado.</returns>

        public Client CreateClient(string name, string lastName, string email, string phone, Seller seller)
        {
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

            if (seller == null)
            {
                throw new ArgumentException("El cliente debe tener un seller", nameof(seller));
            }
            
            int id = this.NextId;
            Client client = new Client(id, name, lastName, email, phone, seller);
            clients.Add(client);
            this.NextId += 1;
            return client;
        }
            
        /// <summary>
        /// Elimina un cliente del repositorio de clientes utilizando su identificador.
        /// De acuerdo al patrón Expert, RepoClients tiene la información necesaria porque gestiona la colección y los identificadores.
        /// Aplicación de los patrones y principios:
        /// - Expert : RepoClients sabe cómo y a quién eliminar, gracias a que mantiene la colección y los IDs.
        /// - SRP : La responsabilidad del método es única, eliminar un cliente.
        /// </summary>
        /// <param name="id">El id del cliente que se va a eliminar.</param>
        
        public bool DeleteClient(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentException("Debe escribir un id válido", nameof(id));
            }
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

            return clientFound;
        } 
        public enum TypeOfData
        {
            Name,
            LastName,
            Email,
            Phone,
            Gender,
            BirthDate
        }

        /// <summary>
        /// Busca y devuelve el cliente cuya Id coincide con la solicitada.
        /// Según el patrón Expert, RepoClients tiene la información y controla la colección, por lo que es responsable de la búsqueda.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients gestiona y tiene acceso a todos los clientes e identificadores.
        /// - SRP: El método tiene una única responsabilidad, buscar un cliente por id.
        /// </summary>
        /// <param name="id">Id del cliente.</param>
        /// <returns>Cliente correspondiente al id proporcionado, o null si no existe.</returns>
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
        /// Busca y devuelve los clientes que cumplan con el criterio especificado.
        /// Según el patrón Expert, RepoClients controla la colección y Client la información, por lo que RepoCLients es responsable de la búsqueda validando con un método de Client.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients contiene a los clientes, entonces debería ser quien los busque.
        /// - SRP: El método tiene una responsabilidad única, buscar clientes por un dato específico.
        /// </summary>
        /// <param name="datasearched">Tipo de dato a buscar: Nombre, Apellido, Email o Teléfono.</param>
        /// <param name="searched">Valor del dato a buscar.</param>
        /// <returns>Lista de clientes que cumplen con el criterio especificado.</returns>

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
            foreach (Client client in this.clients)
            {
                if (client.IsTheSearchedClient(datasearched,searched))
                {
                    result.Add(client);
                }
            }
            return result;
        }

        /// <summary>
        /// Devuelve una lista con los clientes cuyo estado es inactivo.
        /// RepoClients contiene los clientes y, por lo tanto, tiene los datos suficientes para identificar los inactivos.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients gestiona la colección y los datos de los clientes, así que puede identificar los inactivos.
        /// - SRP : El método tiene responsabilidad única, encontrar todos los clientes inactivos.
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
        /// Devuelve una lista con los clientes cuyo estado es “esperando por respuesta”.
        /// RepoClients contiene todos los clientes y tiene los datos suficientes para identificarlos.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients posee la información y controla el acceso para identificar los clientes esperando por respuesta.
        /// - SRP: La responsabilidad de este método es devolver la lista de clientes en estado de espera.
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
        /// Devuelve un mensaje con la cantidad de clientes, interacciones recientes y reuniones futuras.
        /// Al contener a los clientes, RepoClients es el experto en información necesaria para consolidar estos datos.
        /// Para no violar Demeter, se crearon en Client los métodos GetInteractions y GetFutureMeetings.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients es el experto en la información de los clientes y cómo obtener sus datos.
        /// - SRP : La responsabilidad de este método es recopilar y retornar en formato texto las estadísticas principales de los clientes del repositorio.
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
        /// Calcula la cantidad de ventas entre un período dado y la devuelve en formato de mensaje.
        /// Al contener a los clientes, RepoClients es el experto en la información de ventas consolidada.
        /// Para no violar Demeter, la consulta de ventas por período se realiza usando GetTotalSales en Client.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoClients posee y gestiona la colección, así que consolida la información de ventas.
        /// - SRP: La responsabilidad de este método es calcular y retornar la cantidad global de ventas registradas entre dos fechas para todos los clientes del repositorio.
        /// </summary>
        /// <param name="startdate">Fecha inicial del período.</param>
        /// <param name="finishdate">Fecha final del período.</param>
        /// <returns>Un mensaje con la cantidad de ventas.</returns>



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