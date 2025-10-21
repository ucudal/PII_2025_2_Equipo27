using System;
using System.Collections.Generic;

namespace Library
{
    public class SellerFacade
    {
        
        private Admin admin = new Admin("Luciano");
        private RepoClients repo = new RepoClients();
        public void AssignClient(string sellernameMy, string sellernameOther, Client client)
        {
            Seller seller1  = admin.ScreachSeller(sellernameMy);
            Seller seller2 = admin.ScreachSeller(sellernameOther);

            seller1.AsignClient(seller2,client);

            List<Client> clients = repo.SearchClientByName(clientname);

            
            if (clients.Count > 0)
            {
                Client client = clients[0];
                seller1.AsignClient(seller2, client);
            }
            else
            {
                Console.WriteLine("No se encontró ningún cliente con ese nombre");
            }

        }
    }
}