using System;

namespace Library.interactions
{
    public class Call: Interaction
    {
        public Call(string content, string notes, DateTime? interactionDate = null)
            : base(content, notes, interactionDate) 
        {
        }
    }
    

}