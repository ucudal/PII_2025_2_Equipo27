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
        public Admin admin = new Admin("Luciano", 0);

        /// <summary>
        /// Asigna un cliente de este seller a otro seller.
        /// </summary>
        /// <param name="sellernameMy">Nombre de usuario del seller actual</param>
        /// <param name="sellernameOther">Nombre de usuario del seller destino</param>
        /// <param name="client">Cliente que se desea asignar</param>
        /// <returns>Mensaje con resultado de la operación</returns>
        public void AssignClient(string sellerIdMy, string sellerIdOther, string clientId)
        {

            int ClientId;
            if (!int.TryParse(clientId, out ClientId))
                throw new ArgumentException("El id no es válido");
            
            Seller seller1 = RepoUsers.SearchUser<Seller>(int.Parse(sellerIdMy));
            Seller seller2 = RepoUsers.SearchUser<Seller>(int.Parse(sellerIdOther));
            Client client = repoClients.SearchClientById(ClientId);

            if (seller1 != null && seller2 != null && client != null)
            {
                seller1.AsignClient(seller2, client);
            }
            
        }
    }
}
