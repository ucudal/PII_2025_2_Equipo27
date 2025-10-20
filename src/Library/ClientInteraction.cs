using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class ClientInteraction
    {
        public DateTime InteractionDate { get; set; }
        public string Content { get; set; }
        public string Notes { get; set; }

        protected ClientInteraction(String content, String notes, DateTime? interactionDate = null)
        {
            this.Content = content;
            this.Notes = notes;
            this.InteractionDate = interactionDate ?? DateTime.Now; 
        }
        
    }
}