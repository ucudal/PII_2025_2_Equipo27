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

        public Admin Admin = new Admin("Famapez", 0);

        /// <summary>
        /// Crea un nuevo seller en el sistema.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        public Seller CreateSeller(string username)
        {

            return RepoUsers.CreateSeller(username);
        }

        /// <summary>
        /// Busca un administador o un vendedor.
        /// </summary>
        /// <param name="id">La id del administrador o vendedor.</param>
        /// <typeparam name="T">Administrador o vendedor.</typeparam>
        /// <returns>El administrador o vendedor deseado o nada si no existe</returns>
        public T SearchUser<T>(string id) where T : User
        {
            return RepoUsers.SearchUser<T>(int.Parse(id));
        }

        /// <summary>
        /// Crea una lista con todos los usuarios.
        /// </summary>
        /// <returns>La lista creada</returns>
        public IReadOnlyList<User> GetUsers()
        {
            return RepoUsers.Users;
        }

        /// <summary>
        /// Crea una lista con todos los usuarios suspendidos.
        /// </summary>
        /// <returns>La lista creada</returns>
        public IReadOnlyList<User> GetSuspendedUsers()
        {
            return RepoUsers.GetSuspendedUsers();

        }

        /// <summary>
        /// Suspende un usuario existente por su username.
        /// </summary>
        /// <param name="id">La id del usuario</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void SuspendUser(string id)
        {
            User user = RepoUsers.SearchUser<User>(int.Parse(id));
            if (user != null)
            {
                Admin.SuspendUser(user);
            }
        }

        /// <summary>
        /// Activa un usuario previamente suspendido por su username.
        /// </summary>
        /// <param name="id">La id del usuario</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void ActiveUser(string id)
        {

            User user = RepoUsers.SearchUser<User>(int.Parse(id));
            if (user != null)
            {
                Admin.ActiveUser(user);
            }

        }

        /// <summary>
        /// Elimina un usuario del sistema por su username.
        /// </summary>
        /// <param name="id">La Id del usuario</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void DeleteUser(string id)
        {

            User user = RepoUsers.SearchUser<User>(int.Parse(id));
            if (user != null)
            {
                RepoUsers.DeleteUser(int.Parse(id));
            }
            
        }

    }
}
