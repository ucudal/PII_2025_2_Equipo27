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
        /// Crea un nuevo admin en el sistema.
        /// Principios aplicados:
        /// Expert: AdminFacade administra la gestión de usuarios.
        /// SRP: El metodo solo crea un administrador.
        /// </summary>
        /// <param name="username">Nombre de usuario del admin</param>
        public Admin CreateAdmin(string username)
        {
            return RepoUsers.CreateAdmin(username);
        }

        /// <summary>
        /// Crea un nuevo seller en el sistema.
        /// Principios aplicados:
        /// Expert: AdminFacade administra la gestión de usuarios.
        /// SRP: El metodo solo crea un vendedor.
        /// </summary>
        /// <param name="username">Nombre de usuario del seller</param>
        public Seller CreateSeller(string username)
        {

            return RepoUsers.CreateSeller(username);
        }

        /// <summary>
        /// Busca un administador o un vendedor.
        /// Principios aplicados:
        /// Expert: AdminFacade centraliza la busqueda de usuarios.
        /// SRP: El metodo solo se encarga de buscar un usuario.
        /// Polymorphism: El método usa genéricos y trabaja con subtipos de User
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
        /// Principios aplicados:
        /// Expert: AdminFacade tiene acceso a la información de usuarios.
        /// SRP: El metodo solo devuelve una lista con los usuarios.
        /// Demeter: El método envia un mesaje directo al colaborador.
        /// </summary>
        /// <returns>La lista creada</returns>
        public IReadOnlyList<User> GetUsers()
        {
            return RepoUsers.GetAll();
        }

        /// <summary>
        /// Crea una lista con todos los usuarios suspendidos.
        /// Principios aplicados:
        /// Expert: AdminFacade tiene acceso a la información de usuarios.
        /// SRP: El metodo solo devuelve una lista con los usuarios suspendidos.
        /// Demeter: El método envia un mesaje directo al colaborador.
        /// </summary>
        /// <returns>La lista creada</returns>
        public IReadOnlyList<User> GetSuspendedUsers()
        {
            return RepoUsers.GetSuspendedUsers();

        }

        /// <summary>
        /// Suspende un usuario existente por su username.
        /// Principios aplicados:
        /// Expert: AdminFacade gestiona la suspensión junto al admin.
        /// SRP: Solo suspende a un usuario.
        /// Polymorphism: Funciona con los subtipos de User.
        /// </summary>
        /// <param name="id">La id del usuario</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void SuspendUser(string id)
        {
            User user = this.SearchUser<User>(id);
            if (user != null)
            {
                Admin.SuspendUser(user);
            }
        }

        /// <summary>
        /// Activa un usuario previamente suspendido por su username.
        /// Principios aplicados:
        /// Expert: AdminFacade gestiona el quitar la suspensión junto al admin.
        /// SRP: El método solo activa a un usuario.
        /// Polymorphism: Funciona con los subtipos de User.
        /// </summary>
        /// <param name="id">La id del usuario</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void ActiveUser(string id)
        {

            User user = this.SearchUser<User>(id);
            if (user != null)
            {
                Admin.ActiveUser(user);
            }

        }

        /// <summary>
        /// Elimina un usuario del sistema por su username.
        /// Principios aplicados:
        /// Expert: AdminFacade es responsable de gestionar usuarios.
        /// SRP: El método solo elimina un usuario.
        /// Polymorphism: Funciona con los subtipos de User.
        /// </summary>
        /// <param name="id">La Id del usuario</param>
        /// <returns>Mensaje de resultado (éxito o error)</returns>
        public void DeleteUser(string id)
        {

            User user = this.SearchUser<User>(id);
            if (user != null)
            {
                RepoUsers.Remove(user.Id);
            }
            
        }

    }
}
