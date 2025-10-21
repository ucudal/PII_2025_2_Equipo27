using Library.interactions;

namespace Library.Tests;

public class ClientTests
{
    [Test]
    public void ClientShouldCreateCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,
            "09/10/08", seller);
        Assert.That(client.Id, Is.EqualTo("Juan24"));
        Assert.That(client.Name, Is.EqualTo("Juan"));
        Assert.That(client.LastName, Is.EqualTo("Perez"));
        Assert.That(client.Email, Is.EqualTo("juanperez@gmail.com"));
        Assert.That(client.Phone, Is.EqualTo("099888222"));
        Assert.That(client.Gender, Is.EqualTo(Client.GenderType.male));
        Assert.That(client.BirthDate, Is.EqualTo("09/10/08"));
        Assert.That(client.AsignedSeller, Is.EqualTo(seller));

    }
    
    [Test]
    public void ModifyClientModifiesCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        client.ModifyClient(Client.TypeOfData.LastName, "Gutierrez");
        Assert.That(client.LastName,Is.EqualTo("Gutierrez"));
    }
    
    [Test]
    public void AddInteractionAddsAnInteraction()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        ClientInteraction message = new Message("Hola", "nota", InteractionOrigin.Origin.Sent, "Whatsapp", DateTime.Now);
        //string content, string notes, InteractionOrigin sender, string channel, DateTime? interactionDate = null
        client.AddInteraction(message);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void AddTagAddsATag()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        Tag tag = new Tag("Electrodomesticos");
        client.AddTag(tag);
        Assert.That(client.Tags.Count,Is.EqualTo(1));
        Assert.That(client.Tags[0], Is.EqualTo(tag));
    }
    
    [Test]
    public void CreateOportunityWorksCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        client.CreateOportunity("Product", 100 , Opportunity.State.Open, client, DateTime.Now);
        Assert.That(client.Oportunities.Count,Is.EqualTo(1));
    }
}

