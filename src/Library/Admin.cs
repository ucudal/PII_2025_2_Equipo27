using System;
using System.Collections.Generic;

namespace Library
{
    public class Admin : User
    {
        public List<Seller> sellers = new List<Seller>();

        public Admin(string username) : base(username)
        {
            // Itencionalmente en blanco
        }

        /// <summary>
        /// Busca un vendedor especifico en la lista de vendedores.
        /// </summary>
        /// <param name="username">Nombre de usuario del vendedor.</param>
        /// <returns>El vendedor deseado a buscar o nada si el vendedor no existe.</returns>
        
        public Seller SearchSeller(string username)
        {
            foreach (var seller in sellers)
            {
                if (seller.UserName == username)
                { 
                    return seller;
                }
            }
            return null;
        }

        /// <summary>
        /// Crea un nuevo vendedor y lo agrega a la lista de vendedores.
        /// </summary>
        /// <param name="username">El nombre de usuario del nuevo vendedor.</param>
        /// <returns>El vendedor creado o nada si ya hay un vendedor con el nombre de usuario ingresado</returns>
        
        public Seller CreateSeller(string username)
        {
            foreach (Seller s in sellers)
            {
                if (s.UserName == username)
                {
                    Console.WriteLine("Ya hay un vendedor con ese nombre de usuario");
                    return null;
                }
            }

            try
            {
                Seller seller = new Seller(username);
                sellers.Add(seller);
                Console.WriteLine("Vendedor creado");
                return seller;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("No se pudo crear el vendedor");
                return null;
            }
        }

        /// <summary>
        /// Activa a un vendedor que esté suspendido.
        /// </summary>
        /// <param name="seller">El vendedor que se desee activar.</param>
        /// <returns>Un mensaje de que el vendedor dejó de estar suspendido o que ya estaba activo</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el vendedor es nulo</exception>
        
        public string ActiveSeller(Seller seller)
        {
            if (seller == null)
            {
                throw new ArgumentNullException(nameof(seller), "El vendedor no puede ser nulo.");
            }
            if (!seller.Active)
            {
                seller.Active = true;
                return "El vendedor dejó de estar suspendido";
            }
            else 
            {
                return "El vendedor ya estaba activo";
            }
        }
        
        /// <summary>
        /// Suspende a un vendedor que esté activo.
        /// </summary>
        /// <param name="seller">El vendedor que se desee suspender.</param>
        /// <returns>Un mensaje de que el vendedor ha sido suspendido o que ya estaba suspendido.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el vendedor es nulo.</exception>

        public string SuspendSeller(Seller seller)
        {
            if (seller == null)
            {
                throw new ArgumentNullException(nameof(seller), "El vendedor no puede ser nulo.");
            }
            if (seller.Active)
            {
                seller.Active = false;
                return "Vendedor suspendido";
            }
            else
            {
                return "El vendedor ya estaba suspendido";
            }
        }
        
        /// <summary>
        /// Elimina un vendedor y lo elimina de la lista de vendedores.
        /// </summary>
        /// <param name="seller">El vendedor que se desee eliminar.</param>
        /// <returns>Un mensaje si el vendedor fue eliminado o si no existe.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si el vendedor es nulo.</exception>

        public string DeleteSeller(Seller seller)
        {
            if (seller == null)
            {
                throw new ArgumentNullException(nameof(seller), "El vendedor no puede ser nulo.");
            }

            if (sellers.Contains(seller))
            {
                sellers.Remove(seller);
                return "Vendedor eliminado";
            }
            else
            {
                return "Ese vendedor no existe";
            }
        }
    }
}