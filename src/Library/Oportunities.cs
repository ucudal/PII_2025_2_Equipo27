using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Library
{
    public class Oportunity 
    {
        public string Product { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public enum State
        {
            Open, Close, Canceled
        }
        public State OportunityState { get; set; }

        public Client Client { get; set; }
        public Oportunity(string Product, int price, State state, Client client,DateTime? Date = null)
        {
            this.Product = Product;
            this.Date = Date ?? DateTime.Now;
            this.Price = price;
            this.OportunityState = state;
            this.Client = client;

        }
        public void sell(string Product, int Price, State State, Client client, DateTime? Date = null)
        {
            Oportunity sale = new Oportunity(Product, Price, State, client, Date);
        }
    }
}