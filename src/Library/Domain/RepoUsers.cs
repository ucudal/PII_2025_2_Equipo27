using System;
using System.Collections.Generic;
using System.Linq;


namespace Library
{
    public class RepoUsers : IRepo<User>
    {
        private static RepoUsers instance = null;

        public static RepoUsers Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepoUsers();
                }

                return instance;
            }
        }

        public static void ResetInstance()
        {
            instance = null;
        }

        private RepoUsers()
        {
            // Intencionalmente en blanco
        }

        private List<User> users = new List<User>();

        public IReadOnlyList<User> Users
        {
            get { return users; }
        }

        public int Count
        {
            get { return users.Count; }
        }

        private int nextId = 0;

        //private List<Seller> suspendedSellers = new List<Seller>();

        //public IReadOnlyList<Seller> SuspendedSellers
        //{
        //    get { return suspendedSellers; }
        //}

        /// <summary>
        /// Crea un nuevo administrador y lo agrega a la lista de usuario.
        /// Principios aplicados:
        /// Expert: RepoUsers es quien conoce la lista de usuarios.
        /// SRP: El método solo crea y guarda un administrador.
        /// Creator: RepoUsers es responsable de crear Admin porque gestiona la colección.
        /// Polymorphism: Admin es subtipo de User, el metodo en la lista lo añade como User.
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
        /// Principios aplicados:
        /// Expert: RepoUsers es quien conoce la lista de usuarios.
        /// SRP: El método solo crea y guarda un vendedor.
        /// Creator: RepoUsers es responsable de crear Seller porque gestiona la colección.
        /// Polymorphism: Seller es subtipo de User, el metodo en la lista lo añade como User.
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
        /// Añade un usuario a la lista.
        /// Principios aplicados:
        /// Expert: RepoUsers es quien gestiona la lista de usuarios.
        /// SRP: El método solo guarda un usuario en la lista.
        /// Polymorphism: El metodo recibe cualquier subtipo de User.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(User entity)
        {
            users.Add(entity);
        }
        
        /// <summary>
        /// Se obtiene un usuario por su Id.
        /// Principios aplicados:
        /// Expert: AdminFacade es quien gestiona la lista de usuarios.
        /// SRP: El método solo devuelve el primer usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return users.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Busca un administrador o vendedor especifico en la lista de vendedores.
        /// Principios aplicados:
        /// Expert: AdminFacade es quien gestiona la lista de usuarios.
        /// SRP: El método solo devuelve un usuario.
        /// Polymorphism: El método trabaja con subtipos de User.
        /// </summary>
        /// <param name="id">La id del usuario.</param>
        /// <returns>El administrador o vendedor deseado a buscar o nada si no existe.</returns>

        public T SearchUser<T>(int id) where T : User
        {
            foreach (var user in users)
            {
                if (user.Id == id && user is T)
                {
                    return (T)user;
                }
            }

            return null;
        }

        
        /// <summary>
        /// Crea una lista con todos los usuarios.
        /// Principios aplicados:
        /// Expert: AdminFacade es quien gestiona la lista de usuarios.
        /// SRP: El método solo crea una lista con todos los usuarios.
        /// </summary>
        /// <returns>La lista creada.</returns>
        public IReadOnlyList<User> GetAll()
        {
            List<User> allUsers = new List<User>();
            foreach (var user in users)
            {
                allUsers.Add(user);
            }

            return allUsers;
        }



        /// <summary>
        /// Crea una lista con todos los usuarios suspendidos.
        /// /// Principios aplicados:
        /// Expert: AdminFacade es quien gestiona la lista de usuarios.
        /// SRP: El método solo crea una lista con todos los suspendidos.
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
        /// Principios aplicados:
        /// Expert: AdminFacade es quien gestiona la lista de usuarios.
        /// SRP: El método solo elimina un usuario de la lista.
        /// </summary>
        /// <param name="id">Id del usario</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>

        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El ID no puede ser negativo.", nameof(id));
            }

            var user = GetById(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"No existe un usuario con el ID {id}.");
            }

            users.Remove(user);
        }
    }
}