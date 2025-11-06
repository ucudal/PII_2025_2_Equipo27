using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class User
    {
        public string UserName { get; set; }
        public bool Active { get; set; }
        public List<Opportunity> ClosedOpportunities = new List<Opportunity>();

        public User(string username)
        {
            this.UserName = username;
            this.Active = true;
        }

    
        public Tag CreateTag(string tagname, RepoTag repo)
        {
            Tag tag = new Tag(tagname);
            repo.tagList.Add(tag);
            return tag;
        }
        public void CloseOpportunity(Opportunity opportunity)
        {
            opportunity.Sell();
            ClosedOpportunities.Add(opportunity);
        }
    }
}