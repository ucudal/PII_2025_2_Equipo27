using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using Library.interactions;
using Microsoft.VisualBasic;

namespace Library
{
    public class Client
    {
        /// <summary>
        /// Se crean opportunities privado y el IReadOnlyList Opportunities para mejorar la encapsulación de las listas.
        /// </summary>
        public IReadOnlyList<Opportunity> Opportunities
        {
            get { return this.opportunities; }
        }
        private List<Opportunity> opportunities = new List<Opportunity>();
        
        /// <summary>
        /// Se crean interactions privado y el IReadOnlyList Interactions para mejorar la encapsulación de las listas.
        /// </summary>
        public IReadOnlyList<Interaction> Interactions
        {
            get { return this.interactions; }
        }

        private List<Interaction> interactions = new List<Interaction>();
        
        /// <summary>
        /// Se crean tags privado y el IReadOnlyList Tags para mejorar la encapsulación de las listas.
        /// </summary>
        public IReadOnlyList<Tag> Tags
        {
            get { return this.tags; }
        }

        private List<Tag> tags = new List<Tag>();
        
        /// <summary>
        /// Crea una nueva instancia de cliente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        /// <param name="seller"></param>
        /// <exception cref="ArgumentException"></exception>
        public Client(int id, string name, string lastName, string email, string phone, GenderType gender,
            string birthDate, Seller seller)

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

            if (string.IsNullOrEmpty(birthDate))
            {
                throw new ArgumentException("El cliente debe tener una fecha de nacimiento", nameof(birthDate));
            }

            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Inactive = false;
            this.Waiting = false;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.AsignedSeller = seller;
        }

        public Seller AsignedSeller { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Inactive { get; set; }
        public bool Waiting { get; set; }
        public GenderType Gender { get; set; }
        public string BirthDate { get; set; }

        public enum GenderType
        {
            Male,
            Female
        }

        /// <summary>
        /// Agrega la etiqueta al cliente, solamente permitiendo las que se encuentran creadas dentro del repoTags.
        /// Se utiliza el patrón  Expert, ya que la clase Client es la responsable de gestionar sus propias etiquetas.
        /// Además, se sigue el principio de SRP, asegurando que la clase Client tenga una única razón para cambiar.
        /// </summary>
        /// <param name="tag">La etiqueta a agregar.</param>
        /// <exception cref="InvalidOperationException">
        /// Se lanza si el tag ya está agregado.
        /// </exception>


        public void AddTag(Tag tag)
        {
            if (this.tags.Contains(tag))
            {
                throw new InvalidOperationException("Este tag ya está añadido");
            }

            this.tags.Add(tag);
        }


        /// <summary>
        /// Crea una nueva oportunidad, pudiendo ser una venta o una potencial venta.
        /// Aplicación de los patrones y principios:
        /// - Creator: Client es responsable de crear oportunidades porque posee la colección y la información necesaria.
        /// - Expert: Client conoce todos los datos requeridos para asociar correctamente la oportunidad.
        /// - SRP: El método mantiene la responsabilidad clara y acotada, sin mezclar otras tareas.
        /// </summary>
        /// <param name="product">Producto asociado a la oportunidad.</param>
        /// <param name="price">Precio de la oportunidad.</param>
        /// <param name="states">Estado de la oportunidad.</param>
        /// <param name="client">Cliente asociado a la oportunidad.</param>
        /// <param name="date">Fecha de la oportunidad.</param>
        /// <returns>La oportunidad creada.</returns>


        public Opportunity CreateOpportunity(string product, int price, Opportunity.States states, Client client,
            DateTime date)
        {
            Opportunity opportunity = new Opportunity(product, price, states, client, date);
            this.opportunities.Add(opportunity);
            return opportunity;
        }

        /// <summary>
        /// Agrega una nueva interacción, pudiendo ser mensaje, email, llamada o reunión.
        /// Aplicación de los patrones y principios:
        /// - Expert: Client gestiona la colección y sabe determinar si la interacción es válida.
        /// - LCHC: La lógica está centrada en la clase responsable.
        /// - Demeter: El método sólo interactúa con sus propios datos.
        /// - SRP: La responsabilidad está perfectamente delimitada.
        /// </summary>
        /// <param name="interaction">Interacción a agregar.</param>
        /// <exception cref="InvalidOperationException">
        /// Se lanza si la interacción ya está añadida.
        /// </exception>

        public void AddInteraction(Interaction interaction)
        {
            if (this.interactions.Contains(interaction))
            {
                throw new InvalidOperationException("Esta interacción ya está añadida");
            }

            this.interactions.Add(interaction);
        }
        /// <summary>
        /// Devuelve la cantidad de interacciones totales del mes actual.
        /// Este método existe para no violar el principio de Demeter,
        /// evitando que otras clases accedan directamente a la colección interna.
        /// Aplicación de los patrones y principios:
        /// - Demeter: Expone la información necesaria y limita dependencias externas.
        /// - Expert: Client posee los datos y la lógica para calcular la cantidad.
        /// - SRP: La responsabilidad es única.
        /// </summary>
        /// <returns>Cantidad de interacciones totales en el mes actual.</returns>

        public int GetInteractions()
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;
            int recentInteractions = 0;
            foreach (var interaction in this.Interactions)
            {
                if (interaction.InteractionDate.Month == month && interaction.InteractionDate.Year == year &&
                    interaction.InteractionDate <= DateTime.Now)
                {
                    recentInteractions += 1;
                }
            }

            return (recentInteractions);
        }

        /// <summary>
        /// Devuelve la cantidad de reuniones próximas en el mes actual.
        /// Este método existe para no violar el principio de Demeter,
        /// evitando que otras clases accedan directamente a la colección interna.
        /// Aplicación de los patrones y principios:
        /// - Demeter: Expone la información necesaria, limitando las dependencias externas.
        /// - Expert: Client posee los datos y la lógica para calcular la cantidad.
        /// - SRP: La responsabilidad es única.
        /// </summary>
        /// <returns>Cantidad de reuniones futuras en el mes actual.</returns>

        public int GetFutureMeetings()
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;
            int futureMeetings = 0;
            foreach (var interaction in this.Interactions)
            {
                if (interaction.InteractionDate.Month == month && interaction.InteractionDate.Year == year &&
                    interaction.InteractionDate >= DateTime.Now)
                {

                    if (DateTime.Now <= interaction.InteractionDate)
                    {
                        futureMeetings += 1;
                    }
                }
            }

            return (futureMeetings);
        }
        
        /// <summary>
        /// Devuelve el total de ventas en un período determinado.
        /// Este método existe para no violar el principio de Demeter,
        /// evitando que otras clases accedan directamente a la colección interna.
        /// Aplicación de los patrones y principios:
        /// - Demeter: Expone la cantidad total limitando el acceso externo a los datos.
        /// - Expert: Client sabe cómo determinar las ventas en un intervalo temporal.
        /// - SRP: Responsabilidad clara, sólo calcula ventas en el rango dado.
        /// </summary>
        /// <param name="startdate">Fecha de inicio del período.</param>
        /// <param name="finishdate">Fecha de fin del período.</param>
        /// <returns>Total de ventas en el período solicitado.</returns>

        public int GetTotalSales(DateTime startdate, DateTime finishdate)
        {
            int totalSales = 0;
            foreach (var sales in this.Opportunities)
            {
                if (sales.Date.Date >= startdate && sales.Date.Date <= finishdate)
                {
                    totalSales++;
                }
            }

            return (totalSales);
        }
    }
}
