using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using Library.interactions;

namespace Library
{
    public class MainFacade
    {
        private RepoClients repoClients = new RepoClients();

        public List<Client> GetClients()
        {
            return repoClients.Clients;
        }
        
        public void DeleteClient(Client client)
        {
            repoClients.DeleteClient(client);
        }

        public List<Client> SearchClientByName(string name)
        {
            List<Client> result = repoClients.SearchClientByName(name);
            return result;
        }
        
        public List<Client> SearchClientByLastName(string lastname)
        {
            List<Client> result = repoClients.SearchClientByLastName(lastname);
            return result;
        }
        
        public List<Client> SearchClientByEmail(string email)
        {
            List<Client> result = repoClients.SearchClientByEmail(email);
            return result;
        }
        
        public List<Client> SearchClientByPhone(string phone)
        {
            List<Client> result = repoClients.SearchClientByPhone(phone);
            return result;
        }
        
        public List<Client> InactiveClients()
        {
            List<Client> result = repoClients.InactiveClients();
            return result;
        }

        public List<Client> WaitingClients()
        {
            List<Client> result = repoClients.WaitingClients();
            return result;
        }
        
        public void ModifyClient(Client client, Client.TypeOfData modified, string modification)
        {
            client.ModifyClient(modified,modification);
        }

        public void CreateOportunity(string Product, int price, Opportunity.State state, Client client)
        {
            client.CreateOportunity(Product,price,state,client,DateTime.Now);
        }

        public void AddTag(Client client, Tag tag)
        {
            client.AddTag(tag);
        }
        
        
        //////////////////////////////
        ///     Interactions       ///
        //////////////////////////////
        public void RegisterCall(string content, string notes, Client client,DateTime? interactionDate = null)
        {
            Call call = new Call(content,notes,DateTime.Now);
            client.AddInteraction(call);

        }
        
        public void RegisterEmail(string content, Email.MailType sender, string notes, Client client,DateTime? interactionDate = null)
        {
            Email email = new Email(content,sender, notes,DateTime.Now);
            client.AddInteraction(email);
            
        }
        public void RegisterMeeting(string content, string notes, string location, Meeting.MeetingState type, Client client,DateTime? interactionDate = null)
        {
            Meeting meeting = new Meeting(content,notes,location,type,DateTime.Now);
            client.AddInteraction(meeting);
            
        }
        public void RegisterMessage(string content, string notes, Message.MessageType type, string channel, Client client,DateTime? interactionDate = null)
        {
            Message message = new Message(content,notes,type,channel,DateTime.Now);
            client.AddInteraction(message);
            
        }
    }
}