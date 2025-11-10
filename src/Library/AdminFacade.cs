using System;

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
        /// <summary>
        /// Instancia única de administrador principal.
        /// </summary>
        public Admin admin = new Admin("Famapez");

        /// <summary>
        /// Crea un nuevo seller en el sistema.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        public void CreateSeller(string username)
        {
            admin.CreateSeller(username);
        }

        /// <summary>
        /// Suspende un seller existente por su username.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public string SuspendSeller(string username)
        {
            Seller seller = admin.SearchSeller(username);
            if (seller != null)
            {
                return admin.SuspendSeller(seller);
            }
            else
            {
                return "El nombre de usuario ingresado no existe";
            }
        }

        /// <summary>
        /// Activa un seller previamente suspendido por su username.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public string ActiveSeller(string username)
        {
            Seller seller = admin.SearchSeller(username);
            if (seller != null)
            {
                return admin.ActiveSeller(seller);
            }
            else
            {
                return "El nombre de usuario ingresado no existe";
            }
        }

        /// <summary>
        /// Elimina un seller del sistema por su username.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public string DeleteSeller(string username)
        {
            Seller seller = admin.SearchSeller(username);
            if (seller != null)
            {
                return admin.DeleteSeller(seller);
            }
            else
            {
                return "El nombre de usuario ingresado no existe";
            }
        }

    }
}
