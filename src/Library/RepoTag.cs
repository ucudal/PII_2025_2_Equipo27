using System.Collections.Generic;
using System.Diagnostics;

namespace Library
{
    public class RepoTag
    {
        public List<Tag> tagList = new List<Tag>();
        
        /// <summary>
        /// Crea la tag que luego se le asignara a los clientes
        /// </summary>
        /// <param name="tagname"></param>
        /// <param name="repo"></param>
        /// <returns></returns>
        public Tag CreateTag(string tagname, RepoTag repo)
        {
            Tag tag = new Tag(tagname);
            repo.tagList.Add(tag);
            return tag;
        }
        
        /// <summary>
        /// Busca las tags existentes con el nombre del parametro
        /// </summary>
        /// <param name="tagname"></param>
        /// <returns></returns>
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