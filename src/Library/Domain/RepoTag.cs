using System;
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
        public Tag CreateTag(string tagName)
        {
            string newTagName = tagName.Trim().ToLower();
            try
            {
                if ( string.IsNullOrEmpty(newTagName) )
                {
                    throw new ArgumentException("El nombre ingresado no es valido");
                }
                foreach (var tag in tagList)
                {
                    
                    if (tag.TagName == newTagName)
                    {
                        throw new ArgumentException("Ya existe un tag con ese nombre");
                    }
                }
                Tag newTag = new Tag(newTagName);
                this.tagList.Add(newTag);
                return newTag;
            }
            catch (Exception e)
            {
                throw new Exception("Error al crear exception: " + e.Message);
            }
        }
        

        /// <summary>
        /// Busca y devuelve las etiquetas cuyo nombre coincide con el especificado.
        /// </summary>
        /// <param name="tagname">El nombre de la etiqueta por el que buscar.</param>
        /// <returns>Una lista de etiquetas cuyo nombre coincide con <paramref name="tagname"/>.</returns>

        public Tag Search(string tagName)
        {
            string searchedTag = tagName;
            try
            {
                foreach (var tag in tagList)
                {
                    if (tag.TagName == searchedTag)
                    {
                        return tag;
                    }
                }

                throw new ArgumentException("No se encontro ninguna tag con ese nombre");
            }
            catch (Exception e)
            {
                throw new Exception("Error al encontrar tag: " + e);
            }
        }
    }
    
    
 }