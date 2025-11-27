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
        /// Principios aplicados:
        /// Expert: Admin es el rol que sabe y debe encargarse de activar usuarios.
        /// SRP: El metodo tiene solo una resposbilidad, que es activar usuarios.
        /// Polymorphism: El metodo acepta parámetros de la base User, lo cual funciona con cualquer subtipo de User.
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
        /// Principios aplicados:
        /// Expert: Admin es el rol que sabe y debe encargarse de suspender usuarios.
        /// SRP: El metodo tiene solo una resposbilidad, que es suspender usuarios.
        /// Polymorphism: El metodo acepta parámetros de la base User, lo cual funciona con cualquer subtipo de User.
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

        

        