using System;

namespace Library.interactions
{
    public class Message : Interaction
    {
       
        public InteractionOrigin.Origin Sender { get; set; }
        public string Channel { get; set; }
        
        public Message(string content, string notes, InteractionOrigin.Origin sender, string channel, DateTime date)
            : base(content, notes, date)
        {
            this.Sender = sender;
            this.Channel = channel;
        }
    }
}