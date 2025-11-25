using System;

namespace Library.interactions
{
    public class Email : Interaction
    {
     
        public InteractionOrigin.Origin Sender { get; set; }
        
        public Email(string content, InteractionOrigin.Origin sender, string notes, DateTime date)
            : base(content, notes, date) 
        {
            this.Sender = sender;
        }
    }
}