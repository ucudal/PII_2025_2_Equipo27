using System;

namespace Library.interactions
{
    public class Message : ClientInteraction
    {
       
        public InteractionOrigin.Origin Sender { get; set; }
        public string Channel { get; set; }
        
        public Message(string content, string notes, InteractionOrigin.Origin sender, string channel, DateTime? interactionDate = null)
            : base(content, notes, interactionDate)
        {
            this.Sender = sender;
            this.Channel = channel;
        }
    }
}