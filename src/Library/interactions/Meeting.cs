using System;

namespace Library.interactions
{
        public class Meeting : ClientInteraction
        {
            public enum MeetingState
            {
                Programmed, 
                Done, 
                Canceled
            }
            public string Location { get; set; } 
            public MeetingState Type { get; set; }
            
            
            public Meeting(string content, string notes, string location, MeetingState type, DateTime? interactionDate = null) 
                : base(content, notes, interactionDate)
            {
                this.Location = location;
                this.Type = type;
            }
        }
}