using System;
using System.Collections.Generic;

namespace Library
{
    public class RepoUser
    {
        private static RepoUser instance = null;

        public static RepoUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepoUser();
                }

                return instance;
            }
        }

        public static void ResetInstance()
        {
            instance = null;
        }

        private RepoUser()
        {
            // Intencionalmente en blanco
        }

        private List<User> users = new List<User>();

        public IReadOnlyList<User> Users
        {
            get { return users; }
        }

        private int nextId = 0;

        //private List<Seller> suspendedSellers = new List<Seller>();

        //public IReadOnlyList<Seller> SuspendedSellers
        //{
        //    get { return suspendedSellers; }
        //}

        /// <summary>
        /// Crea un nuevo administrador y lo agrega a la lista de usuario.
        /// </summary>
        /// <param name="username">El nombre de usuario del nuevo usuario.</param>
        /// <returns>El administrador creado o nada si ya hay un usuario con el nombre de usuario ingresado</returns>

        public Admin CreateAdmin(string username)
        {
            foreach (User user in users)
            {
                if (user.UserName == username)
                {
                    return null;
                }
            }

            try
            {
                Admin admin = new Admin(username, nextId);
                users.Add(admin);
                nextId++;
                return admin;
            }
            catch (ArgumentException e)
            {
                return null;
            }
        }

        /// <summary>
        /// Crea un nuevo vendedor y lo agrega a la lista de usuarios.
        /// </summary>
        /// <param name="username">El nombre de usuario del nuevo vendedor.</param>
        /// <returns>El vendedor creado o nada si ya hay un vendedor con el nombre de usuario ingresado</returns>

        public Seller CreateSeller(string username)
        {
            foreach (User user in users)
            {
                if (user.UserName == username)
                {
                    return null;
                }
            }

            try
            {
                Seller seller = new Seller(username, nextId);
                users.Add(seller);
                nextId++;
                return seller;
            }
            catch (ArgumentException e)
            {
                return null;
            }
        }

        /// <summary>
        /// Busca un administrador o vendedor especifico en la lista de vendedores.
        /// </summary>
        /// <param name="id">La id del usuario.</param>
        /// <returns>El administrador o vendedor deseado a buscar o nada si no existe.</returns>

        public T SearchUser<T>(int id) where T : User
        {
            foreach (var user in users)
            {
                Type type = user.GetType();
                if (user.Id == id && user is T)
                {
                    return (T)user;
                }
            }

            return null;
        }



        /// <summary>
        /// Crea una lista con solo los usuarios suspendidos.
        /// </summary>
        /// <returns>Una lista con todos los usuarios suspendidos.</returns>
        public IReadOnlyList<User> GetSuspendedUsers()
        {
            List<User> suspendedUsers = new List<User>();

            foreach (var user in users)
            {
                if (!user.Active)
                {
                    suspendedUsers.Add(user);
                }
            }

            return suspendedUsers;
        }

        /// <summary>
        /// Elimina un usuario de la lista de usuarios.
        /// </summary>
        /// <param name="id">La Id del usuario.</param>

        public void DeleteUser(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                throw new ArgumentException("Debe escribir un Id válido");
            }

            int i = 0;
            bool finish = false;
            while (i < users.Count && !finish)
            {
                if (users[i].Id == id)
                {
                    users.Remove(Users[i]);
                    finish=true;
                }

                i++;
            }
        } 
    }

        
    
}