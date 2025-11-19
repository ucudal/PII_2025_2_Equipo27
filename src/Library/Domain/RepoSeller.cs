using System;
using System.Collections.Generic;

namespace Library
{
    public class RepoSeller
    {
        private List<Seller> sellers = new List<Seller>();

        public IReadOnlyList<Seller> Sellers
        {
            get { return this.sellers; }
        }

        //private List<Seller> suspendedSellers = new List<Seller>();

        //public IReadOnlyList<Seller> SuspendedSellers
        //{
        //    get { return suspendedSellers; }
        //}


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
                    return null;
                }
            }

            try
            {
                Seller seller = new Seller(username);
                sellers.Add(seller);
                return seller;
            }
            catch (ArgumentException e)
            {
                return null;
            }
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
        /// Crea una lista con solo los vendedores suspendidos.
        /// </summary>
        /// <returns>Una lista con todos los vendedores suspendidos.</returns>
        public IReadOnlyList<Seller> GetSuspendedSellers()
        {
            List<Seller> suspendSellers = new List<Seller>();

            foreach (var seller in sellers)
            {
                if (!seller.Active)
                {
                    suspendSellers.Add(seller);
                }
            }

            return suspendSellers;
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
                this.sellers.Remove(seller);
            }
        }
    }

        
    
}