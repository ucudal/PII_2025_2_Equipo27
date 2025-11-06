using System;
using System.Collections.Generic;

namespace Library
{
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

        public States State { get; private set; }
        public Client Client { get; set; }
        public Opportunity(string product, double price, States state, Client client,DateTime date)
        {
            this.Product = product;
            if (date == null)
            {
                date = DateTime.Now;
            }
            this.Date = date;
            this.Price = price;
            this.State = state;
            this.Client = client;

        }


        /// <summary>
        /// Cambia el estado de la oportunidad a cerrada.
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