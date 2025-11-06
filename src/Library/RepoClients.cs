using System.Collections.Generic;

namespace Library
{
    public class RepoClients
    {
        public IReadOnlyList<Client> Clients
        {
            get
            {
                return clients;
            }
            
        }

        private List<Client> clients = new List<Client>();
        private int NextId = 0;
        
        public void CreateClient(string name, string lastName, string email, string phone, Client.GenderType gender, string birthDate, Seller seller)
        {
            int id = this.NextId;
            Client client = new Client(id, name, lastName, email, phone, gender, birthDate, seller);
            clients.Add(client);
            this.NextId += 1;
        }

        public void AddClient(Client client)
        {
            clients.Add(client);
        }
        
        public void DeleteClient(int id)
        {
            for (int i=0;i<clients.Count;i++)
            {
                if (clients[i].Id == id)
                {
                    clients.Remove(clients[i]);
                }
            }
        }

        public List<Client> SearchClientByName(string name)
        {
            List<Client> result = new List<Client>();
            foreach (var client in clients)
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
            foreach (var client in clients)
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
            foreach (var client in clients)
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
            foreach (var client in clients)
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
            foreach (var client in clients)
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
            foreach (var client in clients)
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