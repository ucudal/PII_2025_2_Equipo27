using System;
using System.Collections.Generic;

namespace Library
{
    public class Admin : User
    {
        public Admin(string username) : base(username)
        {
            // Itencionalmente en blanco
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
                seller.Active = true;
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
                seller.Active = false;
            }
        }
    }
}

        

        