using Library.interactions;

namespace Library.Tests;

public class ClientTests
{
    [Test]
    public void ClientShouldCreateCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male, "09/10/08", seller);
        Assert.That(client.Id, Is.EqualTo(0));
        Assert.That(client.Name, Is.EqualTo("Juan"));
        Assert.That(client.LastName, Is.EqualTo("Perez"));
        Assert.That(client.Email, Is.EqualTo("juanperez@gmail.com"));
        Assert.That(client.Phone, Is.EqualTo("099888222"));
        Assert.That(client.Gender, Is.EqualTo(Client.GenderType.Male));
        Assert.That(client.BirthDate, Is.EqualTo("09/10/08"));
        Assert.That(client.AsignedSeller, Is.EqualTo(seller));

    }
    [Test]
    public void AddInteractionAddsAnInteraction()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        Interaction message = new Message("Hola", "nota", InteractionOrigin.Origin.Sent, "Whatsapp", DateTime.Now);
        client.AddInteraction(message);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void AddTagAddsATag()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        RepoTags repoTags = new RepoTags();
        Tag tag = repoTags.CreateTag("vip");
        client.AddTag(tag);
        Assert.That(client.Tags.Count,Is.EqualTo(1));
        Assert.That(client.Tags[0], Is.EqualTo(tag));
    }
    
    [Test]
    public void CreateOportunityWorksCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        client.CreateOpportunity("Product", 100 , Opportunity.States.Open, client, DateTime.Now);
        Assert.That(client.Opportunities.Count,Is.EqualTo(1));
    }

    [Test]
    public void ClientConstructorThrowsIfStringsNullOrEmpty()
    {
        Seller seller = new Seller("Pedrito");
        Assert.Throws<ArgumentException>(() => new Client(1, "", "", "", null,
            Client.GenderType.Male,
            null, seller));
    }

    [Test]
    public void AddTagThrowsIfIsAlreadyAdded()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        RepoTags repoTags = new RepoTags();
        Tag tag = repoTags.CreateTag("vip");
        client.AddTag(tag);
        Assert.Throws<InvalidOperationException>(() => client.AddTag(tag));
    }
    [Test]
    public void AddInteractionThrowsIfIsAlreadyAdded()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        Interaction message = new Message("Hola", "nota", InteractionOrigin.Origin.Sent, "Whatsapp", DateTime.Now);
        client.AddInteraction(message);
        Assert.Throws<InvalidOperationException>(() => client.AddInteraction(message));
    }
}

