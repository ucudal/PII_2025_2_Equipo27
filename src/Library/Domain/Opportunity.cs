using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Representa una oportunidad de venta o negocio asociada a un cliente.
    /// <br/>
    /// <b>Expert:</b> Esta clase actúa como experta en la información de la venta, gestionando sus propios datos (precio, producto, fecha) y controlando su ciclo de vida.
    /// </summary>
    public class Opportunity
    {
        public string Product { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }

        public enum States
        {
            Open,
            Close,
            Canceled
        }

        /// <summary>
        /// Obtiene el estado actual de la oportunidad.
        /// <br/>
        /// <b>Encapsulamiento:</b> El setter es privado para asegurar que el estado solo pueda cambiar a través de los métodos de lógica de negocio, garantizando la integridad de los datos.
        /// </summary>
        public States State { get; private set; }
        public Client Client { get; set; }
        
        /// <summary>
        /// Crea una nueva oportunidad especificando la fecha exacta.
        /// </summary>
        public Opportunity(string product, double price, States state, Client client,DateTime date)
        {
            this.Product = product;
            this.Date = date;
            this.Price = price;
            this.State = state;
            this.Client = client;
        }
        
        /// <summary>
        /// Crea una oportunidad asignando automáticamente la fecha actual.
        /// </summary>
        public Opportunity(string product, double price, States state, Client client) : this(product,price,state,client,DateTime.Now)
        {
            // espacio intencionalmente vacio
        }
       
        /// <summary>
        /// Cambia el estado de la oportunidad a cerrada (Close).
        /// <br/>
        /// <b>Expert:</b> La clase Opportunity es la experta en conocer su estado actual, por lo tanto, es su responsabilidad validar y ejecutar la transición a 'Cerrada'.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Se lanza si la oportunidad ya está cerrada.
        /// </exception>
        public void Sell()
        {
            if (this.State == States.Close)
                throw new InvalidOperationException("La oportunidad ya está cerrada.");
            this.State = States.Close;
        }
        public void Cancel()
        {
            if (this.State == States.Canceled)
                throw new InvalidOperationException("La oportunidad ya está cancelada.");
            this.State = States.Canceled;
        }

        
        /// <summary>
        /// Metodo creado para la defensa del proyecto
        /// Devuelve true si la oportunidad está cerrada.
        /// Este método devuelve true si la oportunidad está cerrada (vendida) y false en cualquier otro caso.
        /// Expert: Opportunity es el experto de su propia información, entonces es la clase encargada de verificar sus datos.
        /// SRP: El método solo tiene una responsabilidad, devolver si el producto es el correcto, por lo que tiene razón de cambio única.
        /// Demeter: Para "no hablar con extraños", todas las acciones se delegan al experto en cada cosa.
        /// </summary>
        /// <returns></returns>
        public bool IsClosed()
        {
            if (this.State == States.Close)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Metodo creado para la defensa del proyecto
        /// Devuelve true si el producto es el buscado.
        /// Este método devuelve true si el producto es correcto y false en cualquier otro caso.
        /// Patrones y principios:
        /// Expert: Opportunity es el experto de su propia información, entonces es la clase encargada de verificar sus datos.
        /// SRP: El método solo tiene una responsabilidad, devolver si el producto es el correcto, por lo que tiene razón de cambio única.
        /// Demeter: Para "no hablar con extraños", todas las acciones se delegan al experto en cada cosa.
        /// </summary>
        /// <param name="product">producto a verificar</param>
        /// <returns></returns>
        public bool IsTheProduct(string product)
        {
            if (string.IsNullOrEmpty(product))
            {
                throw new ArgumentException("Debe ingresar un producto válido", nameof(product));
            }
            if (this.Product == product)
            {
                return true;
            }

            return false;
        }
    }
}
