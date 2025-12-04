using Library.interactions;

namespace Library.Tests;

public class ClientTests
{
    [SetUp]
    public void Setup()
    {
        // Antes de empezar cualquier test, aseguramos que el repo esté vacío
        RepoTags.ResetInstance();
    }
    
    [Test]
    public void ClientShouldCreateCorrectly()
    {
        Seller seller = new Seller("Seller",0);
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com",  "099888222", seller);
        Assert.That(client.Id, Is.EqualTo(0));
        Assert.That(client.Name, Is.EqualTo("Juan"));
        Assert.That(client.LastName, Is.EqualTo("Perez"));
        Assert.That(client.Email, Is.EqualTo("juanperez@gmail.com"));
        Assert.That(client.Phone, Is.EqualTo("099888222"));
        Assert.That(client.AsignedSeller, Is.EqualTo(seller));

    }
    [Test]
    public void AddInteractionAddsAnInteraction()
    {
        Seller seller = new Seller("Seller",0);
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "09/10/08", seller);

        Interaction message = new Message("Hola", "nota", InteractionOrigin.Origin.Received, "Whatsapp", DateTime.Now);
        client.AddInteraction(message);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
        Assert.That(client.Waiting,Is.EqualTo(true));
    }
    
    [Test]
    public void AddTagAddsATag()
    {
        Seller seller = new Seller("Seller", 0);
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        RepoTags repoTags = RepoTags.Instance;
        Tag tag = repoTags.CreateTag("vip");
        client.AddTag(tag);
        Assert.That(client.Tags.Count,Is.EqualTo(1));
        Assert.That(client.Tags[0], Is.EqualTo(tag));
    }
    
    [Test]
    public void CreateOportunityWorksCorrectly()
    {
        Seller seller = new Seller("Seller",0);
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);

        client.CreateOpportunity("Product", 100 , Opportunity.States.Open, client, DateTime.Now);
        Assert.That(client.Opportunities.Count,Is.EqualTo(1));
    }

    [Test]
    public void ClientConstructorThrowsIfStringsNullOrEmpty()
    {
        Seller seller = new Seller("Pedrito", 0);
        Assert.Throws<ArgumentException>(() => new Client(1, "", "", "", null,
             seller));
    }

    [Test]
    public void AddTagThrowsIfIsAlreadyAdded()
    {
        Seller seller = new Seller("Seller", 0);
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        RepoTags repoTags = RepoTags.Instance;
        Tag tag = repoTags.CreateTag("vip");
        client.AddTag(tag);
        Assert.Throws<InvalidOperationException>(() => client.AddTag(tag));
    }
    [Test]
    public void AddInteractionThrowsIfIsAlreadyAdded()
    {
        Seller seller = new Seller("Seller",0);
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", seller);

        Interaction message = new Message("Hola", "nota", InteractionOrigin.Origin.Sent, "Whatsapp", DateTime.Now);
        client.AddInteraction(message);
        Assert.Throws<InvalidOperationException>(() => client.AddInteraction(message));
    }

    [Test]
    public void AddData_AddsDataCorrectly()
    {
        Seller seller = new Seller("pip",0);
        Client client = new Client(0, "Julian", "Rod", "jaujad@", "099", seller);
        client.AddData(RepoClients.TypeOfData.Gender,"Male");
        client.AddData(RepoClients.TypeOfData.BirthDate,"21/03/1991");

        // Act
        string actualClientBirthDate = client.BirthDate;
        Client.GenderType actualClientGender = client.Gender;
        // Assert
        Assert.That(actualClientBirthDate, Is.EqualTo("21/03/1991"));
        Assert.That(actualClientGender, Is.EqualTo(Client.GenderType.Male));
    }
    
    // Tests Desfensa Historia 1

    [Test]
    public void HigherThanSell_ReturnsTrue()
    {
        // Arrange
        Seller seller = new Seller("Seller",0);
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        client.CreateOpportunity("Mate", 25, Opportunity.States.Close, client, DateTime.Now);
        client.CreateOpportunity("Moto", 750, Opportunity.States.Close, client, DateTime.Now);
        double amount = 100;
        bool expected = true;
        // Act
        bool actual = client.HigherThanSell(amount);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void HigherThanSell_ReturnsFalse_WhenOpportunitiesIsEmpty()
    {
        // Arrange
        Seller seller = new Seller("Seller",0);
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        double amount = 100;
        bool expected = false;
        // Act
        bool actual = client.HigherThanSell(amount);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void HigherThanSell_ReturnsFalse_WhenAmountIsHigher()
    {
        // Arrange
        Seller seller = new Seller("Seller",0);
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        client.CreateOpportunity("Mate", 25, Opportunity.States.Close, client, DateTime.Now);
        client.CreateOpportunity("Moto", 750, Opportunity.States.Close, client, DateTime.Now);
        double amount = 1000;
        bool expected = false;
        // Act
        bool actual = client.HigherThanSell(amount);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void HigherThanSell_ReturnsFalse_WhenStateIsNotClose()
    {
        // Arrange
        Seller seller = new Seller("Seller",0);
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        client.CreateOpportunity("Mate", 25, Opportunity.States.Open, client, DateTime.Now);
        client.CreateOpportunity("Moto", 750, Opportunity.States.Canceled, client, DateTime.Now);
        double amount = 5;
        bool expected = false;
        // Act
        bool actual = client.HigherThanSell(amount);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}

