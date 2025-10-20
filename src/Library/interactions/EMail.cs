using System;

namespace Library.interactions
{
    public class Email : Interaction
    {
        public enum MessageSender
        {
            Sent,
            Received
        }
        public MessageSender Sender { get; set; }
        
        public Email(string content, MessageSender sender, string notes, DateTime? interactionDate = null)
            : base(content, notes, interactionDate) 
        {
            this.Sender = sender;
        }
    }
}