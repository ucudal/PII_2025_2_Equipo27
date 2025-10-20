using System;

namespace Library.interactions
{
    public class Call: ClientInteraction
    {
        public Call(string content, string notes, DateTime? interactionDate = null)
            : base(content, notes, interactionDate) 
        {
        }
    }
    

}