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

        public IReadOnlyList<ClientInteraction> Interactions
        {
            get
            {
                return interactions;
            }
        }

        private List<ClientInteraction> interactions = new List<ClientInteraction>();

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
            male,
            Female
        }

        public enum TypeOfData
        {
            Name,
            LastName,
            Email,
            Phone
        }

        public void ModifyClient(TypeOfData modified, string modification)
        {
            if (modified == TypeOfData.Name)
            {
                this.Name = modification;
            }
            else if (modified == TypeOfData.LastName)
            {
                this.LastName = modification;
            }
            else if (modified == TypeOfData.Email)
            {
                this.Email = modification;
            }
            else
            {
                this.Phone = modification;
            }
        }


        //////////////////////////////
        ///     Tag                ///
        //////////////////////////////

        public void AddTag(Tag tag)
        {
            tags.Add(tag);
        }


        public void CreateOportunity(string Product, int price, Opportunity.States states, Client client,
            DateTime? Date = null)
        {
            Opportunity oportunity = new Opportunity(Product, price, states, client, Date);
            opportunities.Add(oportunity);

        }

        //////////////////////////////
        ///     Interactions       ///
        //////////////////////////////
        public void AddInteraction(ClientInteraction interaction)
        {
            this.interactions.Add(interaction);
        }
    }
}