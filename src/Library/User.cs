using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class User
    {
        public string UserName { get; set; }
        public bool Active { get; set; }
        public List<Opportunity> ClosedOpportunities = new List<Opportunity>();

        public User(string username)
        {
            this.UserName = username;
            this.Active = true;
        }

    
        public Tag CreateTag(string tagname, RepoTag repo)
        {
            Tag tag = new Tag(tagname);
            repo.tagList.Add(tag);
            return tag;
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

        public void CloseOpportunity(Opportunity opportunity)
        {
            opportunity.Sell();
            ClosedOpportunities.Add(opportunity);
        }
    }
}