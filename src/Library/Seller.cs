<<<<<<< HEAD
namespace Library
{
    public class Seller
    {
        
=======
using System;
using System.Collections.Generic;

namespace Library
{
    public class Seller : User
    {
        public List<Client> thisClients = new List<Client>();

        public Seller(string username) : base(username)
        {
            
        }

        public void AsignClient(Seller other, Client client)
        {
            if (other.Active)
            {
                other.thisClients.Add(client);
            }
            else
            {
                Console.WriteLine("No se le puede asignar un cliente debido a que el vendedor está suspendido");
            }
        }
>>>>>>> EzeBranch
    }
}