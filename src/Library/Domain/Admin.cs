using System;
using System.Collections.Generic;

namespace Library
{
    public class Admin : User
    {
        public Admin(string username, int id) : base(username, id)
        {
            // Itencionalmente en blanco
        }
        
        /// <summary>
        /// Activa a un usuario que esté suspendido.
        /// </summary>
        /// <param name="user">El usuario que se desee activar.</param>
        /// <exception cref="ArgumentNullException">Se lanza si el usuario es nulo</exception>
        
        public void ActiveUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "El vendedor no puede ser nulo.");
            }
            if (!user.Active)
            {
                user.Active = true;
            }
        }
        
        /// <summary>
        /// Suspende a un usuario que esté activo.
        /// </summary>
        /// <param name="user">El usuario que se desee suspender.</param>
        /// <exception cref="ArgumentNullException">Se lanza si el vendedor es nulo.</exception>

        public void SuspendUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "El vendedor no puede ser nulo.");
            }
            if (user.Active)
            {   
                user.Active = false;
            }
        }
    }
}

        

        