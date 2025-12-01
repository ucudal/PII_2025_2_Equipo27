using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase abstracta que representa una interacción genérica con un cliente.
    /// <br/>
    /// <b>Polimorfismo:</b> Permite tratar llamadas, mensajes, emails y reuniones de manera uniforme en las listas del cliente.
    /// </summary>
    public abstract class Interaction
    {
        /// <summary>
        /// Obtiene o establece la fecha en la que ocurrió la interacción.
        /// </summary>
        public DateTime InteractionDate { get; set; }
        
        /// <summary>
        /// Obtiene o establece el contenido principal o descripción de la interacción.
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// Obtiene o establece notas adicionales o comentarios sobre la interacción.
        /// </summary>
        public string Notes { get; set; }
        
        /// <summary>
        /// Identificador único de la interacción.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Constructor base para inicializar las propiedades comunes de una interacción.
        /// </summary>
        /// <param name="content">Descripción de la interacción.</param>
        /// <param name="notes">Notas adicionales.</param>
        /// <param name="date">Fecha de la interacción. Si es null, se asigna la fecha actual.</param>
        protected Interaction(string content, string notes, DateTime date)
        {
            this.Content = content;
            this.Notes = notes;
            this.InteractionDate = date; 
        }
        
        /// <summary>
        /// Crea una interaccion asignando automáticamente la fecha actual.
        /// </summary>
        protected Interaction(string content, string notes) 
            : this(content, notes, DateTime.Now)
        {
            // espacio intencionalmente vacio
        }
    }
}