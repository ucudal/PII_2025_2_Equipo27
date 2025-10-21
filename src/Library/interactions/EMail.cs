using System;

namespace Library.interactions
{
    public class Email : ClientInteraction
    {
     
        public InteractionOrigin Sender { get; set; }
        
        public Email(string content, InteractionOrigin sender, string notes, DateTime? interactionDate = null)
            : base(content, notes, interactionDate) 
        {
            this.Sender = sender;
        }
    }
}