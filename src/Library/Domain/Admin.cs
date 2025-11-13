using System;
using System.Collections.Generic;

namespace Library
{
    public class Admin : User
    {
        public List<Seller> sellers = new List<Seller>();
        private List<Seller> suspendedSellers = new List<Seller>();

        public IReadOnlyList<Seller> SuspendedSellers
        {
            get
            {
                return suspendedSellers;
            }
        }

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
        /// <exception cref="ArgumentNullException">Se lanza si el vendedor es nulo</exception>
        
        public void ActiveSeller(Seller seller)
        {
            if (seller == null)
            {
                throw new ArgumentNullException(nameof(seller), "El vendedor no puede ser nulo.");
            }
            if (!seller.Active)
            {
                Console.WriteLine("Vendedor activado");
                seller.Active = true;

                suspendedSellers.Remove(seller);

            }
            else
            {
                Console.WriteLine("El vendedor ya estaba activo");
            }
        }
        
        /// <summary>
        /// Suspende a un vendedor que esté activo.
        /// </summary>
        /// <param name="seller">El vendedor que se desee suspender.</param>
        /// <exception cref="ArgumentNullException">Se lanza si el vendedor es nulo.</exception>

        public void SuspendSeller(Seller seller)
        {
            if (seller == null)
            {
                throw new ArgumentNullException(nameof(seller), "El vendedor no puede ser nulo.");
            }
            if (seller.Active)
            {   
                Console.WriteLine("Vendedor suspendido");
                seller.Active = false;

                suspendedSellers.Add(seller);
        
            }
            else
            {
                Console.WriteLine("El vendedor ya esyaba suspendido");
            }
        }
        
        /// <summary>
        /// Elimina un vendedor y lo elimina de la lista de vendedores.
        /// </summary>
        /// <param name="seller">El vendedor que se desee eliminar.</param>
        /// <exception cref="ArgumentNullException">Se lanza si el vendedor es nulo.</exception>

        public void DeleteSeller(Seller seller)
        {
            if (seller == null)
            {
                throw new ArgumentNullException(nameof(seller), "El vendedor no puede ser nulo.");
            }

            if (sellers.Contains(seller))
            {
                Console.WriteLine("Vendedor eliminado");
                sellers.Remove(seller);
            }
            else
            {
                Console.WriteLine("Ese vendedor no existe");
            }
        }
    }
}