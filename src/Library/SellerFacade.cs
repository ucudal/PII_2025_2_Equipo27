using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Library
{
    public class SellerFacade : MainFacade
    {
        
        /// <summary>
        /// Instancia de administrador usada para búsqueda y asignación entre sellers.
        /// </summary>
        public Admin admin = new Admin("Luciano");
        public RepoClients repo = new RepoClients();

        /// <summary>
        /// Asigna un cliente de este seller a otro seller.
        /// </summary>
        /// <param name="sellernameMy">Nombre de usuario del seller actual</param>
        /// <param name="sellernameOther">Nombre de usuario del seller destino</param>
        /// <param name="client">Cliente que se desea asignar</param>
        /// <returns>Mensaje con resultado de la operación</returns>
        public string AssignClient(string sellernameMy, string sellernameOther, Client client)
        {
            Seller seller1 = admin.SearchSeller(sellernameMy);
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
