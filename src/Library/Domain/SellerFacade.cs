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
        /// Principios aplicados:
        /// Expert: SellerFacade tiene el rol de cordina operaciones entre vendedores.
        /// SRP: El método solo se encarga de asignar un cliente.
        /// </summary>
        /// <param name="sellerIdMy">Id de usuario del seller actual</param>
        /// <param name="sellerIdOther">Id de usuario del seller destino</param>
        /// <param name="clientId">Id del liente que se desea asignar</param>
        /// <returns>Mensaje con resultado de la operación</returns>
        public void AssignClient(string sellerIdMy, string sellerIdOther, string clientId)
        {
            Seller seller1 = RepoUsers.SearchUser<Seller>(int.Parse(sellerIdMy));
            Seller seller2 = RepoUsers.SearchUser<Seller>(int.Parse(sellerIdOther));
            Client client = repoClients.GetById(int.Parse(clientId));

            if (seller1 != null && seller2 != null && client != null)
            {
                seller1.AsignClient(seller2, client);
            }
            
        }
    }
}
