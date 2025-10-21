using System;
using Microsoft.VisualBasic;

namespace Library
{
    public class Facade
    {
        public void ModifyClient(Client client, Client.TypeOfData modified, string modification)
        {
            client.ModifyClient(modified,modification);
        }

        public void CreateOportunity(string Product, int price, Oportunity.State state, Client client, DateTime? Date = null)
        {
            client.CreateOportunity(Product,price,state,client,Date);
        }

        public void AddTag(Client client, Tag tag)
        {
            client.AddTag(tag);
        }
    }
}