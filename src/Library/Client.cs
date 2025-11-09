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
        public IReadOnlyList<Opportunity> Opportunities 
        {
            get
            {
                return this.opportunities;
            } 
        }

        public IReadOnlyList<Interaction> Interactions
        {
            get
            {
                return this.interactions;
            }
        }

        private List<Interaction> interactions = new List<Interaction>();

        public IReadOnlyList<Tag> Tags
        {
            get
            {
                return this.tags;
            }
        }

        private List<Tag> tags = new List<Tag>();
        private List<Opportunity> opportunities = new List<Opportunity>();
        public Client(int id, string name, string lastName, string email, string phone, GenderType gender, string birthDate, Seller seller)

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
            this.asignedSeller = seller;
        }

        private Seller asignedSeller;
        public Seller AsignedSeller 
        {
            get
            {
                return this.asignedSeller;
            }
        }
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

        public enum TypeOfData
        {
            Name,
            LastName,
            Email,
            Phone
        }

        /// <summary>
        /// Permite modificar los datos del cliente
        /// </summary>
        /// <param name="modified"></param>
        /// <param name="modification"></param>
        
        
        // public void ModifyClient(TypeOfData modified, string modification)
        // {
        //     if (modified == TypeOfData.Name)
        //     {
        //         this.Name = modification;
        //     }
        //     else if (modified == TypeOfData.LastName)
        //     {
        //         this.LastName = modification;
        //     }
        //     else if (modified == TypeOfData.Email)
        //     {
        //         this.Email = modification;
        //     }
        //     else
        //     {
        //         this.Phone = modification;
        //     }
        // }


        /// <summary>
        /// Agrega la etiqueta al cliente, solamente permitiendo las que se encuentran creadas dentro del repoTags
        /// </summary>
        /// <param name="tag"></param>
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
        ///  Crea una nueva oportunidad, pudiendo ser una venta o una potencial venta
        /// </summary>
        /// <param name="Product"></param>
        /// <param name="price"></param>
        /// <param name="states"></param>
        /// <param name="client"></param>
        /// <param name="Date"></param>
        public void CreateOportunity(string product, int price, Opportunity.States states, Client client,
            DateTime date)
        { 
            Opportunity oportunity = new Opportunity(product, price, states, client, date);
            this.opportunities.Add(oportunity);
        }

        /// <summary>
        /// Agrega una nueva interaccion, pudiendo ser mensaje, EMail, llamada o reunion
        /// </summary>
        /// <param name="interaction"></param>
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
    }
}