using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class Interaction
    {
        public DateTime InteractionDate { get; set; }
        public string Content { get; set; }
        public string Notes { get; set; }
        public int Id { get; set; }
        protected Interaction(String content, String notes, DateTime date)
        {
            if (date == null)
            {
                date = DateTime.Now;
            }
            this.Content = content;
            this.Notes = notes;
            this.InteractionDate = date; 
        }
    }
}