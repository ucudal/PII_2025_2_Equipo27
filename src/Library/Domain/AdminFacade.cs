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
            // Intencionalmente en blanco
        }

        public Admin admin = new Admin("Fachada" );
        /// <summary>
        /// Crea un nuevo seller en el sistema.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        public Seller CreateSeller(string username)
        {

            return RepoUsers.CreateSeller(username);
        }

        public T SearchUser<T>(string userName) where T : User
        {
            return RepoUsers.SearchUser<T>(userName);
        }

        public IReadOnlyList<User> GetUsers()
        {
            return RepoUsers.Users;
        }

        public IReadOnlyList<User> GetSuspendedSellers()
        {
            return RepoUsers.GetSuspendedUsers();

        }

        /// <summary>
        /// Suspende un usuario existente por su username.
        /// </summary>
        /// <param name="username">Nombre del usuario</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void SuspendUser(string username)
        {

            User user = RepoUsers.SearchUser<User>(username);
            if (user != null)
            {
                admin.SuspendUser(user);
            }
            
        }

        /// <summary>
        /// Activa un usuario previamente suspendido por su username.
        /// </summary>
        /// <param name="username">Nombre del usuario</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void ActiveUser(string username)
        {

            User user = RepoUsers.SearchUser<User>(username);
            if (user != null)
            {
                admin.ActiveUser(user);
            }

        }

        /// <summary>
        /// Elimina un usuario del sistema por su username.
        /// </summary>
        /// <param name="username">Nombre del usuario</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void DeleteUser(string username)
        {

            User user = RepoUsers.SearchUser<User>(username);
            if (user != null)
            {
                RepoUsers.DeleteUser(user.UserName);
            }
            
        }

    }
}
