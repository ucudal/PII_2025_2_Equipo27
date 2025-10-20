using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Library
{
    public class Oportunity 
    {
        public string Product { get; set; }
        public DateAndTime Date { get; set; }
        public int Price { get; set; }
        public enum State
        {
            Open, Close, Canceled
        }
        public State OportunityState { get; set; }

        public Client Client { get; set; }
        public Oportunity(string Product, DateAndTime Date, int price, State state, Client client)
        {
            this.Product = Product;
            this.Date = Date;
            this.Price = price;
            this.OportunityState = state;
            this.Client = client;

        }
        public void sell(string Product, DateAndTime Date, int Price, State State, Client client)
        {
            Oportunity sale = new Oportunity(Product, Date, Price, State, client);
        }
    }
}