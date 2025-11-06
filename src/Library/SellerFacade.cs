using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Library
{
    public class SellerFacade
    {
        
        public Admin admin = new Admin("Luciano");
        public RepoClients repo = new RepoClients();
        public string AssignClient(string sellernameMy, string sellernameOther, Client client)
        {
            Seller seller1  = admin.SearchSeller(sellernameMy);
            Seller seller2 = admin.SearchSeller(sellernameOther);

            if (seller1 != null && seller2 != null)
            {
                return seller1.AsignClient(seller2, client);
            }
            else
            {
                return "Hay al menos un usuario no encontrado";
            }
        }
    }
}