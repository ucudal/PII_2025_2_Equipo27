using System;

namespace Library.interactions
{
    public class Message : Interaction
    {
        public enum MessageType
        {
            Sent,
            Received
        }
        public MessageType Type { get; set; }
        public string Channel { get; set; }
        
        public Message(string content, string notes, MessageType type, string channel, DateTime? interactionDate = null)
            // Llama al constructor de la clase base "Interaction" para inicializar las propiedades comunes.
            : base(content, notes, interactionDate)
        {
            this.Type = type;
            this.Channel = channel;
        }
    }
}