using System;
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
        public string GetPanel()
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int recentInteractions = 0;
            int futureMeetings = 0;

            foreach (var client in this.Clients)
            {
                foreach (var interaction in client.Interactions)
                {
                    if (interaction.InteractionDate.Month == month && interaction.InteractionDate.Year == year && interaction.InteractionDate <= DateTime.Now)
                    {
                        recentInteractions++;
                    }
                    if (DateTime.Now <= interaction.InteractionDate)
                    {
                        futureMeetings++;
                    }
                
                }
            }
            return ($"Clientes totales: {this.Clients.Count}\n" + $"Interacciones en este último mes: {recentInteractions}\n" + $"Reuniones próximas {futureMeetings}");
        }

        public string GetTotalSales( DateTime startdate, DateTime finishdate)
        {
            int totalSales = 0;
            foreach (var client in this.Clients)
            {
                foreach (var sales in client.Opportunities)
                {
                    if (sales.Date.Date >= startdate && sales.Date.Date <= finishdate)
                    {
                        totalSales++;
                    }
                }
            }
            return $"Cantidad de ventas dentro del período: {totalSales}";
        }
    }
}