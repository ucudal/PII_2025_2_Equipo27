using System;
using System.Collections.Generic;
using System.Linq;


namespace Library
{
    
    /// <summary>
    /// Repositorio de usuarios (users).
    /// Implementa IRepository<user> directamente sin interfaz intermedia.
    /// Aplica patrón Repository y principio Information Expert (GRASP).
    /// </summary>
    public class RepoUsers : IRepo<User>
    {
        /// <summary>
        /// Repositorio de usuarios (users).
        /// <br/>
        /// <b>Patrones y Principios aplicados:</b>
        /// <list type="bullet">
        /// <item><b>Singleton:</b> Garantiza una única instancia del repositorio para mantener la consistencia de los datos en memoria.</item>
        /// <item><b>Repository:</b> Abstrae la lógica de almacenamiento y acceso a datos.</item>
        /// <item><b>Information Expert (GRASP):</b> Es la clase experta en gestionar la colección de users y sus IDs.</item>
        /// <item><b>DIP (SOLID):</b> Implementa la abstracción para reducir el acoplamiento.</item>
        /// </list>
        /// </summary>
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

        private List<User> users = new List<User>();
        
        private RepoUsers()
        {
            // Intencionalmente en blanco
        }

        /// <summary>
        /// NextId aumenta en uno cada vez que se crea un tag, así todos los tags tienen un número identificador diferente.
        /// </summary>
        private int NextId = 0;
        
        /// <summary>
        /// Obtiene todos los usuarios del repositorio (solo lectura).
        /// </summary>
        public IReadOnlyList<User> GetAll() => users.AsReadOnly();
        


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
            Admin admin = new Admin(username, NextId);
            this.Create(admin);
            NextId++;
            return admin;
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
            Seller seller = new Seller(username.Trim().ToLower(), NextId);
            this.Create(seller);
            NextId++;
            return seller;
        }
        
        /// <summary>
        /// Guarda users: Verifica duplicados y lo guarda.
        /// Aplicación de los patrones y principios:
        /// - Creator: RepoUsers es responsable de crear users porque gestiona la colección y su ciclo de vida.
        /// - Expert: RepoUsers tiene la información y lógica para asignar datos y generar identificadores.
        /// - SRP: Responsabilidad clara, solo crea y registra un User.
        /// - Polymorphism: El metodo recibe cualquier subtipo de User.
        /// </summary>
        /// <param name="newUser">nuevo usuario a guardar.</param>
        /// <exception cref="InvalidOperationException">Si ya existe un user con ese nombre.</exception>
        
        public void Create(User newUser)
        {
            foreach (User user in users)
            {
                if (user.UserName == newUser.UserName)
                {
                    throw new InvalidOperationException("Ya existe un user con ese nombre");
                }
            }
            users.Add(newUser);
        }
        
        /// <summary>
        /// Se obtiene un usuario por su Id.
        /// Principios aplicados:
        /// Expert: AdminFacade es quien gestiona la lista de usuarios.
        /// SRP: El método solo devuelve el primer usuario.
        /// </summary>
        /// <param name="id">Id del user</param>
        /// <returns>Usuario correspondiente al user buscado o null si existe</returns>
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
            if (id < 0)
            {
                throw new ArgumentException("El número de Id no puede ser negativo", nameof(id));
            }

            var userSearch = GetById(id);
            if (userSearch == null)
            {
                throw new KeyNotFoundException("No existe un usuario con esa Id");
            }
            if (userSearch is T)
            {
                return (T)userSearch;
            }

            throw new InvalidCastException($"El usuario con la id {id} no es del tipo {typeof(T).Name}.");
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
        
        /// <summary>
        /// Propiedad calculada para cumplir con IRepo.Count
        /// </summary>
        public int Count => users.Count;
    }
}