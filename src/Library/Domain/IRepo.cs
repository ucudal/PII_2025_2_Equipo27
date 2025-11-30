using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Interfaz genérica base para repositorios.
    /// Implementa el patrón Repository y aplica DIP (SOLID).
    /// </summary>
    /// <typeparam name="T">El tipo de entidad que gestiona el repositorio.</typeparam>
    public interface IRepo<T> where T : class
    {
        /// <summary>
        /// Obtiene todos los elementos del repositorio (solo lectura).
        /// </summary>
        IReadOnlyList<T> GetAll();

        /// <summary>
        /// Agrega un nuevo elemento al repositorio.
        /// </summary>
        void Create(T entity);
        
        /// <summary>
        /// Obtiene un elemento por su identificador único.
        /// </summary>
        T GetById(int id);

        /// <summary>
        /// Elimina un elemento del repositorio por su ID.
        /// </summary>
        void Remove(int id);

        /// <summary>
        /// Obtiene la cantidad total de elementos.
        /// </summary>
        int Count { get; }
        
    }
}