using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using Library.interactions;
using Microsoft.VisualBasic;

namespace Library
{
    public class Client
    {

        public readonly List<Opportunity> Oportunities = new List<Opportunity>();
        public readonly List<ClientInteraction> Interactions = new List<ClientInteraction>();
        public readonly List<Tag> Tags = new List<Tag>();
        public Client(string id, string name, string lastName, string email, string phone, GenderType gender, string birthDate, Seller seller)

        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Inactive = false;
            this.Waiting = true;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.AsignedSeller = seller;
        } 
        public Seller AsignedSeller { get; set; }
        public string Id { get; set; }
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
            male,Female
        }
        public enum TypeOfData
        {
            Name,LastName,Email,Phone
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
            Tags.Add(tag);
        }


        public void CreateOportunity(string Product, int price, Opportunity.State state, Client client, DateTime? Date = null)
        {
            Opportunity oportunity = new Opportunity(Product, price, state, client, Date);
            Oportunities.Add(oportunity);

        }
        
        //////////////////////////////
        ///     Interactions       ///
        //////////////////////////////
        public void AddInteraction(ClientInteraction interaction)
        {
            this.Interactions.Add(interaction);
        }
    }
}