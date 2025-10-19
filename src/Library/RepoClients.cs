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

        public List<Client> SearchClientByName(string name)
        {
            List<Client> result = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Name == name)
                {
                    result.Add(client);
                }
            }
            return result;
        }
        
        public List<Client> SearchClientByLastName(string lastname)
        {
            List<Client> result = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.LastName == lastname)
                {
                    result.Add(client);
                }
            }
            return result;
        }
        
        public List<Client> SearchClientByEmail(string email)
        {
            List<Client> result = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Email == email)
                {
                    result.Add(client);
                }
            }

            return result;
        }
        
        public List<Client> SearchClientByNumber(string number)
        {
            List<Client> result = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Number == number)
                {
                    result.Add(client);
                }
            }
            return result;
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