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
        public Client(string id, string name, string lastName, string email, string phone, gender gender, string birthDate, Seller seller)
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
        public string Tag { get; set; }
        public string Phone { get; set; }
        public bool Inactive { get; set; }
        public bool Waiting { get; set; }
        public gender Gender { get; set; }
        public string BirthDate { get; set; }

        public enum gender
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

        //////////////////////////////
        ///     Oportunity         ///
        //////////////////////////////
        public void CreateOportunity(string product, DateTime date, int price, Opportunity.State state, Client client)
        {
            Opportunity opportunity = new Opportunity(product, date, price, state, client);
            Oportunities.Add(opportunity);
        }
        
        //////////////////////////////
        ///     Interactions       ///
        //////////////////////////////
        public void RegisterCall(string content, string notes, DateTime? interactionDate = null)
        {
            Call call = new Call(content, notes, interactionDate);
            this.Interactions.Add(call);
        }
        
        public void RegisterEmail(string content, Email.MailType sender, string notes, DateTime? interactionDate = null)
        {
            Email eMail = new Email(content, sender,notes, interactionDate);
            this.Interactions.Add(eMail);
        }
        public void RegisterMeeting(string content, string notes, string location, Meeting.MeetingState type, DateTime? interactionDate = null)
        {
            Meeting meeting = new Meeting( content,notes, location, type, interactionDate);
            this.Interactions.Add(meeting);
        }
         public void RegisterMessage(string content, string notes, Message.MessageType type, string channel, DateTime? interactionDate = null)
        {
            Message message = new Message( content,notes, type, channel,interactionDate);
            this.Interactions.Add(message);
        }


    }
}