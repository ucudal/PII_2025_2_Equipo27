using System;

namespace Library.interactions
{
    // <summary>
    /// Representa una interacción telefónica con un cliente.
    /// Hereda de Interaction.
    /// </summary>
    public class Call: Interaction
    {
        /// <summary>
        /// Crea una nueva instancia de una llamada.
        /// </summary>
        /// <param name="content">Resumen de lo hablado en la llamada.</param>
        /// <param name="notes">Notas adicionales sobre la llamada.</param>
        /// <param name="date">Fecha en que se realizó la llamada.</param>
        public Call(string content, string notes, DateTime date)
            : base(content, notes, date) 
        {
        }
    }
    

}