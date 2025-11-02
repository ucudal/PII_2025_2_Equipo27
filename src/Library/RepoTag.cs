using System.Collections.Generic;
using System.Diagnostics;

namespace Library
{
    public class RepoTag
    {
        public List<Tag> tagList = new List<Tag>();
        
        
        public Tag CreateTag(string tagname, RepoTag repo)
        {
            Tag tag = new Tag(tagname);
            repo.tagList.Add(tag);
            return tag;
        }
        public List<Tag> Search(string tagname)
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