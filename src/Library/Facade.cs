using System.Collections.Generic;

namespace Library
{
    public class Facade
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
    }
}