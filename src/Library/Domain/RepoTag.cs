using System.Collections.Generic;
using System.Diagnostics;

namespace Library
{
    public class RepoTag
    {
        private List<Tag> tagList = new List<Tag>();

        public IReadOnlyList<Tag> TagList
        {
            get
            {
                return tagList;
            }
        }

        /// <summary>
        /// Crea una nueva etiqueta y la agrega al repositorio especificado.
        /// </summary>
        /// <param name="tagname">El nombre de la nueva etiqueta.</param>
        /// <returns>La etiqueta creada.</returns>
        public Tag CreateTag(string tagname)
        {
            Tag tag = new Tag(tagname);
            this.tagList.Add(tag);
            return tag;
        }
        

        /// <summary>
        /// Busca y devuelve las etiquetas cuyo nombre coincide con el especificado.
        /// </summary>
        /// <param name="tagname">El nombre de la etiqueta por el que buscar.</param>
        /// <returns>Una lista de etiquetas cuyo nombre coincide con <paramref name="tagname"/>.</returns>

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