using System.Collections.Generic;

namespace Library
{
    public class RepoClients
    {
        public List<Client> Clients { get; } = new List<Client>();
        
        public void AddClient(Client client)
        {
            Clients.Add(client);
        }
            
        public void DeleteClient(int id)
        {
            for (int i=0;i<Clients.Count;i++)
            {
                if (Clients[i].Id == id)
                {
                    Clients.Remove(Clients[i]);
                }
            }
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
        
        public List<Client> SearchClientByPhone(string phone)
        {
            List<Client> result = new List<Client>();
            foreach (var client in Clients)
            {
                if (client.Phone == phone)
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