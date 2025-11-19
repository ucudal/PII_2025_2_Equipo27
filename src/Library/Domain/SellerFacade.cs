using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Library
{
    public class SellerFacade : MainFacade
    {
        private static SellerFacade instance = null;

        public static SellerFacade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SellerFacade();
                }

                return instance;
            }
        }
        public static void ResetInstance() 
        {
            instance = null;
        }
        private SellerFacade()
        {
            
        }
        /// <summary>
        /// Instancia de administrador usada para búsqueda y asignación entre sellers.
        /// </summary>
        public Admin admin = new Admin("Luciano");

        /// <summary>
        /// Asigna un cliente de este seller a otro seller.
        /// </summary>
        /// <param name="sellernameMy">Nombre de usuario del seller actual</param>
        /// <param name="sellernameOther">Nombre de usuario del seller destino</param>
        /// <param name="client">Cliente que se desea asignar</param>
        /// <returns>Mensaje con resultado de la operación</returns>
        public void AssignClient(string sellernameMy, string sellernameOther, string id)
        {
            int clientId;
            if (!int.TryParse(id, out clientId))
                return;
            
            Seller seller1 = repoSellers.SearchSeller(sellernameMy);
            Seller seller2 = repoSellers.SearchSeller(sellernameOther);
            Client client = repoClients.SearchClientById(clientId);

            if (seller1 != null && seller2 != null && client != null)
            {
                seller1.AsignClient(seller2, client);
            }
        }
    }
}
