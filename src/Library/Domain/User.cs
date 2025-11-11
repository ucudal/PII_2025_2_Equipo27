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

                userName = value;
            } 
        }
        public bool Active { get; set; }
        
        private List<Opportunity> closedOpportunities = new List<Opportunity>();

        public User(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("El usuario debe tener un nombre", nameof(username));
            }
            this.userName = username;
            this.Active = true;
        }
        /// <summary>
        /// Cierra una oportunidad y la agrega a una lista de oportunidades que fueron cerradas.
        /// </summary>
        /// <param name="opportunity">La oportunidad que será cerrada.</param>
        
        public Tag CreateTag(string tagname, RepoTag repo)
        {
            Tag tag = new Tag(tagname);
            repo.tagList.Add(tag);
            return tag;
        }
        
        /// <summary>
        /// Cierra una oportunidad y la agrega a una lista de oportunidades que fueron cerradas.
        /// </summary>
        /// <param name="opportunity">La oportunidad que será cerrada.</param>
        
        public void CloseOpportunity(Opportunity opportunity)
        {
            opportunity.Sell();
            closedOpportunities.Add(opportunity);
        }
    }
}