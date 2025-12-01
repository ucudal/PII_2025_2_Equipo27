using System;

namespace Library.interactions
{
        /// <summary>
        /// Representa una reunión (presencial o virtual) con un cliente.
        /// Hereda de Interaction.
        /// </summary>
        public class Meeting : Interaction
        {
            /// <summary>
            /// Estados posibles de una reunión.
            /// </summary>
            public enum MeetingState
            {
                /// <summary>
                /// La reunión está agendada pero aún no ha ocurrido.
                /// </summary>
                Programmed, 
                
                /// <summary>
                /// La reunión ya se llevó a cabo.
                /// </summary>
                Done, 
                
                /// <summary>
                /// La reunión fue cancelada.
                /// </summary>
                Canceled
            }
            
            /// <summary>
            /// Ubicación física o enlace virtual de la reunión.
            /// </summary>
            public string Location { get; set; } 
            
            /// <summary>
            /// Estado actual de la reunión (Programada, Realizada, Cancelada).
            /// </summary>
            public MeetingState Type { get; set; }
            
            /// <summary>
            /// Crea una nueva instancia de una reunión.
            /// </summary>
            /// <param name="content">Temas a tratar en la reunión.</param>
            /// <param name="notes">Notas o minutas de la reunión.</param>
            /// <param name="location">Lugar o link de la reunión.</param>
            /// <param name="type">Estado inicial de la reunión.</param>
            /// <param name="date">Fecha y hora de la reunión.</param>
            public Meeting(string content, string notes, string location, MeetingState type, DateTime date) 
                : base(content, notes, date)
            {
                this.Location = location;
                this.Type = type;
            }
        }
}