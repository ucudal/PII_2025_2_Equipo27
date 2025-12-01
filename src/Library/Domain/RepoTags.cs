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
        
        /// <summary>
        /// Repositorio de etiquetas (tags).
        /// <br/>
        /// <b>Patrones y Principios aplicados:</b>
        /// <list type="bullet">
        /// <item><b>Singleton:</b> Garantiza una única instancia del repositorio para mantener la consistencia de los datos en memoria.</item>
        /// <item><b>Repository:</b> Abstrae la lógica de almacenamiento y acceso a datos.</item>
        /// <item><b>Information Expert (GRASP):</b> Es la clase experta en gestionar la colección de tags y sus IDs.</item>
        /// <item><b>DIP (SOLID):</b> Implementa la abstracción para reducir el acoplamiento.</item>
        /// </list>
        /// </summary>

        private static RepoTags instance = null;

        public static RepoTags Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepoTags();
                }

                return instance;
            }
        }
        public static void ResetInstance()
        {
            instance = null;
        }

        private List<Tag> tags = new List<Tag>();
        
        private RepoTags()
        {
            // Intencionalmente en blanco
        }
        
        /// <summary>
        /// NextId aumenta en uno cada vez que se crea un tag, así todos los tags tienen un número identificador diferente.
        /// </summary>
        private int NextId = 0;
        
        /// <summary>
        /// Obtiene todas las etiquetas del repositorio (solo lectura).
        /// </summary>
        public IReadOnlyList<Tag> GetAll() => tags.AsReadOnly();
       
        /// <summary>
        /// Agrega un tag ya existente al repositorio.
        /// Implementación del contrato de la interfaz IRepo.
        /// Aplicación de patrones y principios:
        /// - Repository: Se encarga exclusivamente de la lógica de almacenamiento (agregar a la lista).
        /// - DIP (SOLID): Implementa la abstracción, permitiendo que el sistema dependa de la interfaz y no de la implementación concreta.
        /// - SRP: Su única responsabilidad es guardar una entidad válida.
        /// </summary>
        /// <param name="entity">Entidad del Tag.</param>
        public void Create(Tag entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "No se puede agregar un tag nulo.");
            }
            tags.Add(entity);
        }
        
        /// <summary>
        /// Método para crear un nuevo tag.
        /// Genera el ID único, instancia el objeto y lo registra automáticamente.
        /// Aplicación de patrones y principios:
        /// - Creator (GRASP): RepoClients es el responsable de crear instancias de tags porque es quien las contiene y gestiona.
        /// - Expert (GRASP): Posee la información necesaria (como el NextId y la lista para validar) para crear un tag válido.
        /// </summary>
        /// <param name="name">Nombre del tag a crear.</param>
        /// <returns>El Tag recién creado.</returns>
        /// <exception cref="InvalidOperationException">Si ya existe un tag con ese nombre.</exception>
        public Tag CreateTag(string name)
        {
            string tagName = name.Trim().ToLower();
            foreach (var tag in tags)
            {
                if (tag.TagName == tagName)
                {
                    throw new InvalidOperationException("Ya existe un tag con ese nombre");
                }
            }
            Tag newTag = new Tag(this.NextId,tagName);
            this.Create(newTag);
            this.NextId += 1;
            return newTag;
        }
        
        /// <summary>
        /// Busca y devuelve el tag cuya Id coincide con la solicitada.
        /// Según el patrón Expert, RepoTags tiene la información y controla la colección, por lo que es responsable de la búsqueda.
        /// Aplicación de los patrones y principios:
        /// - Expert: RepoTags gestiona y tiene acceso a todos los tags e identificadores.
        /// - SRP: El método tiene una única responsabilidad, buscar un tag por id.
        /// </summary>
        /// <param name="id">Id del tag.</param>
        /// <returns>Tag correspondiente al id proporcionado, o null si no existe.</returns>
        public Tag GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El número de Id no puede ser negativo", nameof(id));
            }
            Tag result = null;
            foreach (var tag in tags)
            {
                if (tag.Id == id)
                {
                    result = tag;
                    break;
                }
            }
            return result;
        }
        
        /// <summary>
        /// Elimina un tag del repositorio de tags utilizando su identificador.
        /// De acuerdo al patrón Expert, RepoTags tiene la información necesaria porque gestiona la colección y los identificadores.
        /// Aplicación de los patrones y principios:
        /// - Expert : RepoTags sabe cómo y a quién eliminar, gracias a que mantiene la colección y los IDs.
        /// - SRP : La responsabilidad del método es única, eliminar un tag.
        /// - DRY : usa GetById() para encontrar el tag
        /// </summary>
        /// <param name="id">El id del tag que se va a eliminar.</param>
        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("El ID no puede ser negativo.", nameof(id));
            }
            Tag tagToRemove = GetById(id);

            if (tagToRemove != null)
            {
                tags.Remove(tagToRemove);
            }
        }

        /// <summary>
        /// Busca y devuelve las etiquetas cuyo nombre coincide con el especificado.
        /// </summary>
        /// <param name="tagName">El nombre de la etiqueta por el que buscar.</param>
        /// <returns>Una lista de etiquetas cuyo nombre coincide con <paramref name="tagName"/>.</returns>

        public Tag Search(string name)
        {
            Tag searchedTag = null;
            string tagName = name.Trim().ToLower();
            foreach (var tag in tags)
            {
                if (tag.TagName == tagName )
                {
                    searchedTag = tag;
                    break;
                }
            }
            if (searchedTag == null)
            {
                throw new ArgumentException("No se encontró ninguna tag con ese nombre");
            }

            return searchedTag;
        }
        
         
        /// <summary>
        /// Propiedad calculada para cumplir con IRepo.Count
        /// </summary>
        public int Count => tags.Count;
        
    }
    
    
 }