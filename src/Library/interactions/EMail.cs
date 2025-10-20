using System;

namespace Library.interactions
{
    public class Email : ClientInteraction
    {
        public enum MailType
        {
            Sent,
            Received
        }
        public MailType Sender { get; set; }
        
        public Email(string content, MailType sender, string notes, DateTime? interactionDate = null)
            : base(content, notes, interactionDate) 
        {
            this.Sender = sender;
        }
    }
}