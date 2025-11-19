using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Fachada para operaciones específicas del administrador (Admin).
    /// Extiende la lógica de MainFacade agregando gestión de sellers.
    /// </summary>
    public class AdminFacade : MainFacade
    {
        
        
        private static AdminFacade instance = null;
        public static AdminFacade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AdminFacade();
                }

                return instance;
            }
        }
        public static void ResetInstance()
        {
            instance = null;
        }
        private AdminFacade()
        {
            
        }

        public Admin admin = new Admin("Fachada");
        /// <summary>
        /// Crea un nuevo seller en el sistema.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        public Seller CreateSeller(string username)
        {
            return repoSellers.CreateSeller(username);
        }

        public Seller SearchSeller(string userName)
        {
            return repoSellers.SearchSeller(userName);
        }

        public IReadOnlyList<Seller> GetSellers()
        {
            return repoSellers.Sellers;
        }

        public IReadOnlyList<Seller> GetSuspendedSellers()
        {
            return repoSellers.GetSuspendedSellers();
        }

        /// <summary>
        /// Suspende un seller existente por su username.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void SuspendSeller(string username)
        {
            Seller seller = repoSellers.SearchSeller(username);
            if (seller != null)
            {
                admin.SuspendSeller(seller);
            }
            
        }

        /// <summary>
        /// Activa un seller previamente suspendido por su username.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void ActiveSeller(string username)
        {
            Seller seller = repoSellers.SearchSeller(username);
            if (seller != null)
            {
                admin.ActiveSeller(seller);
            }

        }

        /// <summary>
        /// Elimina un seller del sistema por su username.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void DeleteSeller(string username)
        {
            Seller seller = repoSellers.SearchSeller(username);
            if (seller != null)
            {
                repoSellers.DeleteSeller(seller);
            }
            
        }

    }
}
