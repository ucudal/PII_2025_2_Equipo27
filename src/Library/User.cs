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

    
        public void CreateTag(string tagname, RepoTag repo)
        {
            Tag tag = new Tag(tagname);
            repo.tagList.Add(tag);
        }


        public void GetPanel(RepoClients repo)
        {
            Console.WriteLine($"Clientes totales: {repo.Clients.Count}");

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int recentInteractions = 0;

            foreach (var client in repo.Clients)
            {
                foreach (var interaction in client.Interactions)
                {
                    if (interaction.Date.Month == month && interaction.Date.Year == year && interaction.Date <= DateTime.Now)
                    {
                        recentInteractions++;
                    }
                }
            }

            Console.WriteLine($"Interacciones en este último mes: {recentInteractions}");
        }

        public double GetTotalSales()
        {
            return 0;
        }
    }
}