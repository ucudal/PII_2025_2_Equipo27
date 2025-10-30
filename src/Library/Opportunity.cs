using System;
using System.Collections.Generic;

namespace Library
{
    public class Opportunity 
    {
        public string Product { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public enum State
        {
            Open, Close, Canceled
        }
        public State OportunityState { get; set; }

        public Client Client { get; set; }

        public Opportunity(string Product, double price, State state, Client client,DateTime? Date = null)
        {
            this.Product = Product;
            this.Date = Date ?? DateTime.Now;
            this.Price = price;
            this.OportunityState = state;
            this.Client = client;

        }

       

        public void Sell()
        {
            this.OportunityState = State.Close;
        }
    }
}