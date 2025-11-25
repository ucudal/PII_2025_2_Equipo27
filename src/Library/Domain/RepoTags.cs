using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Library
{
    /// <summary>
    /// Repositorio de etiquetas (tags).
    /// Implementa IRepository<Tag> directamente sin interfaz intermedia.
    /// Aplica patrón Repository y principio Information Expert (GRASP).
    /// </summary>
    public class RepoTags : IRepo<Tag>
    {
        private readonly List<Tag> _tagList = new List<Tag>();
        

        private int NextId = 1;
        
        /// <summary>
        /// Propiedad calculada para cumplir con IRepo.Count
        /// </summary>
        public int Count => _tagList.Count;
        

        /// <summary>
        /// Obtiene un tag por su ID (Cumple con IRepo.GetById)
        /// </summary>
        public Tag GetById(int id)
        {
            // Busca el primero que coincida con el ID, o devuelve null
            return _tagList.FirstOrDefault(t => t.Id == id);
        }
        /// <summary>
        /// Obtiene todas las etiquetas del repositorio (solo lectura).
        /// </summary>
        public IReadOnlyList<Tag> GetAll() => _tagList.AsReadOnly();
        
        
        
        /// <summary>
        /// Crea una nueva etiqueta y la agrega al repositorio especificado.
        /// </summary>
        /// <param name="tagname">El nombre de la nueva etiqueta.</param>
        public void Add(Tag entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            // Validar nombre vacío
            if (string.IsNullOrWhiteSpace(entity.TagName))
            {
                throw new ArgumentException("El nombre de la etiqueta no es válido");
            }

            // Validar duplicados (usando LINQ es más limpio)
            if (_tagList.Any(t => t.TagName.ToLower() == entity.TagName.Trim().ToLower()))
            {
                throw new InvalidOperationException("Ya existe un tag con ese nombre");
            }

            // Asignar ID y aumentar contador
            entity.Id = NextId;
            NextId++;

            _tagList.Add(entity);
        }
        public void Remove(int id)
        {
            // Reutilizamos GetById para encontrarlo
            Tag tagToRemove = GetById(id);

            if (tagToRemove == null)
            {
                throw new KeyNotFoundException($"No existe un tag con el ID {id}");
            }

            _tagList.Remove(tagToRemove);
        }
        
        /// <summary>
        /// Busca y devuelve las etiquetas cuyo nombre coincide con el especificado.
        /// </summary>
        /// <param name="tagName">El nombre de la etiqueta por el que buscar.</param>
        /// <returns>Una lista de etiquetas cuyo nombre coincide con <paramref name="tagName"/>.</returns>

        public Tag Search(string tagName)
        {
            string searchedTag = tagName;
            try
            {
                foreach (var tag in _tagList)
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
        
        public Tag CreateTag(string tagName)
        {
            try
            {
                
                foreach (var tag in _tagList)
                {
                    if (tag.TagName == tagName)
                    {
                        throw new Exception("Ya existe un tag con ese nombre");
                    }
                }
                // Creamos la instancia (el ID se asignará dentro de Add)
                Tag newTag = new Tag(0, tagName); // Asumimos que el constructor acepta (id, nombre)
                
                // Llamamos a Add para reutilizar la lógica de validación y asignación de ID
                this.Add(newTag);
            
                return newTag;
            }
            catch (Exception e)
            {
                
                throw new Exception("Error: "+ e);
            }
        }

        
        
        
        
    }
    
    
 }