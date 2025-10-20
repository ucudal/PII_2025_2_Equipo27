using System;

namespace Library.interactions
{
    public class Message : ClientInteraction
    {
        public enum MessageType
        {
            Sent,
            Received
        }
        public MessageType Type { get; set; }
        public string Channel { get; set; }
        
        public Message(string content, string notes, MessageType type, string channel, DateTime? interactionDate = null)
            : base(content, notes, interactionDate)
        {
            this.Type = type;
            this.Channel = channel;
        }
    }
}