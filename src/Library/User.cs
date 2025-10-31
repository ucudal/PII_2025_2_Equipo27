using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class User
    {
        private string userName;
        public string UserName {
            get
            {
                return this.userName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("El usuario debe tener un nombre", nameof(value));
                }

                userName = value;
            } 
        }
        public bool Active { get; set; }
        public List<Opportunity> ClosedOpportunities = new List<Opportunity>();

        public User(string username)
        {
            this.userName = username;
            this.Active = true;
        }
        
        public string GetPanel(RepoClients repo)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int recentInteractions = 0;
            int futureMeetings = 0;

            foreach (var client in repo.Clients)
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
            return ($"Clientes totales: {repo.Clients.Count}\n" + $"Interacciones en este último mes: {recentInteractions}\n" + $"Reuniones próximas {futureMeetings}");
        }
        

        public string GetTotalSales(RepoClients repo, DateTime startdate, DateTime finishdate)
        {
            int totalSales = 0;
            foreach (var client in repo.Clients)
            {
                foreach (var sales in client.Oportunities)
                {
                    if (sales.Date.Date >= startdate && sales.Date.Date <= finishdate)
                    {
                        totalSales++;
                    }
                }
            }
            return $"Cantidad de ventas dentro del período: {totalSales}";
        }

        public void CloseOpportunity(Opportunity opportunity)
        {
            opportunity.Sell();
            ClosedOpportunities.Add(opportunity);
        }
    }
}