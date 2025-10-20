using System;

namespace Library
{
    public abstract class User
    {
        public string UserName { get; set; }
        public bool Active { get; set; }

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


        public void GetPanel(RepoClients repo)
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
                    if (DateTime.Now <= interaction.Date)
                    {
                        futureMeetings++;
                    }
                
                }
            }
            Console.WriteLine($"Clientes totales: {repo.Clients.Count}");
            Console.WriteLine($"Interacciones en este último mes: {recentInteractions}");
            Console.WriteLine($"Reuniones próximas {futureMeetings}");
        }
        

        public void GetTotalSales(DateTime startdate, DateTime finishdate)
        {
            return 0;
        }
    }
}