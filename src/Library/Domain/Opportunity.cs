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
    }
}