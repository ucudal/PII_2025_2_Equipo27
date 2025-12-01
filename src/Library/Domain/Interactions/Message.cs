using System;

namespace Library.interactions
{
    /// <summary>
    /// Representa un mensaje de texto por Whatsapp, sms, Instagram, etc.
    /// Hereda de Interaction.
    /// </summary>
    public class Message : Interaction
    {
        /// <summary>
        /// Indica quién envió el mensaje (Enviado o Recibido).
        /// </summary>
        public InteractionOrigin.Origin Sender { get; set; }
        
        /// <summary>
        /// Canal por el cual se envió el mensaje
        /// </summary>
        public string Channel { get; set; }
        
        /// <summary>
        /// Crea una nueva instancia de un mensaje.
        /// </summary>
        /// <param name="content">Contenido del mensaje de texto.</param>
        /// <param name="notes">Notas adicionales.</param>
        /// <param name="sender">Origen del mensaje.</param>
        /// <param name="channel">Canal utilizado.</param>
        /// <param name="date">Fecha y hora del mensaje.</param>
        public Message(string content, string notes, InteractionOrigin.Origin sender, string channel, DateTime date)
            : base(content, notes, date)
        {
            this.Sender = sender;
            this.Channel = channel;
        }
    }
}