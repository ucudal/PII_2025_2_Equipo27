using System;

namespace Library.interactions
{
    /// <summary>
    /// Representa una interacción por correo electrónico.
    /// Hereda de Interaction.
    /// </summary>
    public class Email : Interaction
    {
        /// <summary>
        /// Indica el origen del email (si fue Enviado por nosotros o Recibido del cliente).
        /// </summary>
        
        public InteractionOrigin.Origin Sender { get; set; }
        
        /// <summary>
        /// Crea una nueva instancia de un email.
        /// </summary>
        /// <param name="content">Asunto o cuerpo del correo.</param>
        /// <param name="sender">Indica si el email fue enviado o recibido.</param>
        /// <param name="notes">Notas internas sobre el correo.</param>
        /// <param name="date">Fecha del correo.</param>
        public Email(string content, InteractionOrigin.Origin sender, string notes, DateTime date)
            : base(content, notes, date) 
        {
            this.Sender = sender;
        }
    }
}