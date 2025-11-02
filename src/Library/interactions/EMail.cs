using System;

namespace Library.interactions
{
    public class Email : Interaction
    {
     
        public InteractionOrigin.Origin Sender { get; set; }
        
        public Email(string content, InteractionOrigin.Origin sender, string notes, DateTime? interactionDate = null)
            : base(content, notes, interactionDate) 
        {
            this.Sender = sender;
        }
    }
}