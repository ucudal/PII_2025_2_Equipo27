using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class User
    {
        public IReadOnlyList<Opportunity> ClosedOpportunities
        {
            get { return closedOpportunities; }
        }
        private string userName;
        public string UserName {
            get
            {
                return this.userName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(nameof(value));
                }

                userName = value.Trim().ToLower();
            } 
        }
        
        public int Id { get; private set; }
        public bool Active { get; set; }
        
        private List<Opportunity> closedOpportunities = new List<Opportunity>();

        public User(string username, int id)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("El usuario debe tener un nombre", nameof(username));
            }
            this.UserName = username;
            this.Id = id;
            this.Active = true;
        }
       
        
        /// <summary>
        /// Cierra una oportunidad y la agrega a una lista de oportunidades que fueron cerradas.
        /// Principios aplicados:
        /// Expert: User conoce y gestiona las oportunidades.
        /// </summary>
        /// <param name="opportunity">La oportunidad que será cerrada.</param>
        
        public void CloseOpportunity(Opportunity opportunity)
        {
            opportunity.Sell();
            closedOpportunities.Add(opportunity);
        }
    }
}