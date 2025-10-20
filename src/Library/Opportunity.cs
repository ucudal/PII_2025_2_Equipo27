using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Library
{
    public class Opportunity 
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
        public Opportunity(string product, DateTime date, int price, State state, Client client)
        {
            this.Product = product;
            this.Date = date;
            this.Price = price;
            this.OportunityState = state;
            this.Client = client;

        }
        public void Sell(string product, DateTime date, int price, State state, Client client)
        {
            Opportunity sale = new Opportunity(product, date, price, state, client);
        }
    }
}