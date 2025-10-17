using System.Collections.Generic;

namespace Library
{
    public class RepoClients
    {
        private List<Client> Clients { get; } = new List<Client>();
        
        public void AddClient(Client client)
        {
            Clients.Add(client);
        }
            
        public void DeleteClient(Client client)
        {
            Clients.Remove(client);
        }

        public Client SearchClientByName(string name)
        {
            foreach (var client in Clients)
            {
                if (client.Name == name)
                {
                    return client;
                }
            }
        }
        
        public Client SearchClientByLastName(string lastname)
        {
            foreach (var client in Clients)
            {
                if (client.LastName == lastname)
                {
                    return client;
                }
            }
        }
        
        public Client SearchClientByEmail(string email)
        {
            foreach (var client in Clients)
            {
                if (client.Email == email)
                {
                    return client;
                }
            }
        }
        
        public Client SearchClientByNumber(string number)
        {
            foreach (var client in Clients)
            {
                if (client.Number == number)
                {
                    return client;
                }
            }
        }

        public List<Client> InactiveClients()
        {
            List<Client> inactiveClients = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Inactive)
                {
                    inactiveClients.Add(client);
                }
            }

            return inactiveClients;
        }

        public List<Client> WaitingClients()
        {
            List<Client> waitingClients = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Waiting)
                {
                    waitingClients.Add(client);
                }
            }
            return waitingClients;
        }
    }
}