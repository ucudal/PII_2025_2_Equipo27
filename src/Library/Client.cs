using System;
using System.Collections.Generic;
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
                return opportunities;
            } 
        }

        public IReadOnlyList<Interaction> Interactions
        {
            get
            {
                return interactions;
            }
        }

        private List<Interaction> interactions = new List<Interaction>();

        public IReadOnlyList<Tag> Tags
        {
            get
            {
                return tags;
            }
        }

        private List<Tag> tags = new List<Tag>();
        private List<Opportunity> opportunities = new List<Opportunity>();
        public Client(int id, string name, string lastName, string email, string phone, GenderType gender, string birthDate, Seller seller)

        {
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

        private Seller _asignedSeller;
        public Seller AsignedSeller 
        {
            get
            {
                return _asignedSeller;
            }
            set
            {
                _asignedSeller = value;
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

        public void AddTag(Tag tag)
        {
            tags.Add(tag);
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
            opportunities.Add(oportunity);
        }

        /// <summary>
        /// Agrega una nueva interaccion, pudiendo ser mensaje, EMail, llamada o reunion
        /// </summary>
        /// <param name="interaction"></param>
        public void AddInteraction(Interaction interaction)
        {
            this.interactions.Add(interaction);
        }
    }
}