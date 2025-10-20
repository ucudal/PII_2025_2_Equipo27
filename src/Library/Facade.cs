using Microsoft.VisualBasic;

namespace Library
{
    public class Facade
    {
        public void ModifyClient(Client client, Client.TypeOfData modified, string modification)
        {
            client.ModifyClient(modified,modification);
        }

        public void CreateOportunity(string Product, DateAndTime Date, int price, Oportunity.State state, Client client)
        {
            client.CreateOportunity(Product,Date,price,state,client);
        }

        public void AddTag(Client client, Tag tag)
        {
            client.AddTag(tag);
        }
    }
}