namespace Library.interactions
{
    
    /// <summary>
    /// Clase contenedora para definir el origen de una interacción.
    /// </summary>
    public class InteractionOrigin
    {
        /// <summary>
        /// Enumera los posibles orígenes de una interacción.
        /// </summary>
        public enum Origin
        {
            /// <summary>
            /// La interacción fue enviada por un usuario.
            /// </summary>
            Sent,
            /// <summary>
            /// La interacción fue recibida desde el Cliente.
            /// </summary>
            Received
        }
    }
}