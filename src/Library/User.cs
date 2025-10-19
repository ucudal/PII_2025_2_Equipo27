using System;

namespace Library
{
    public class User
    {
        public string UserName { get; set; }
        public bool Active { get; set; }

        public User(string username)
        {
            this.UserName = username;
            this.Active = true;
        }

        public enum Tags
        {
            Vip,
            Regular,
            Bajo,
            Nuevo,
            Comprador
        
        }
        public void AddTag(Client client, Tags tag)
        {
            client.Tag = tag;
        }


        public void GetPanel(RepoClients repo)
        {
            Console.WriteLine($"Clientes totales: {repo.GetTotalClients()}");
            // Falta mostrar reuniones próximas e interacciones anteriores.

        }

        public double GetTotalSales()
        {
            return 0;
        }
    }
}g