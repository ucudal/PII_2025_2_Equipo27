using System.Collections.Generic;
using System.Diagnostics;

namespace Library
{
    public class RepoTag
    {
        public List<Tag> tagList = new List<Tag>();
        
        public List<Tag> Screach(string tagname)
        {
            List<Tag> result = new List<Tag>();
            foreach (var tag in tagList)
            {
                if (tag.TagName == tagname)
                {
                    result.Add(tag);
                }
                 
            }
 
            return result;
        }
    }
    
    
 }