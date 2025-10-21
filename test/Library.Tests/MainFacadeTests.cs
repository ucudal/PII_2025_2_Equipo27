using Library.interactions; 
namespace Library.Tests;

public class MainFacadeTests
{
    [Test]
    public void ModifyOportunityWorksCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.ModifyClient(client, Client.TypeOfData.LastName, "Gutierrez");
        Assert.That(client.LastName,Is.EqualTo("Gutierrez"));
    }
    
    [Test]
    public void CreateOportunityWorksCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.ModifyClient(client, Client.TypeOfData.LastName, "Gutierrez");
        mainFacade.CreateOportunity("Product", 100 , Opportunity.State.Open, client);
        Assert.That(client.Oportunities.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void AddTagAddsATag()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        Tag tag = new Tag("Electrodomesticos");
        MainFacade mainFacade = new MainFacade();
        mainFacade.ModifyClient(client, Client.TypeOfData.LastName, "Gutierrez");
        mainFacade.AddTag(client,tag);
        Assert.That(client.Tags.Count,Is.EqualTo(1));
        Assert.That(client.Tags[0], Is.EqualTo(tag));
    }

    [Test]
    public void RegisterCallRegistersACall()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.RegisterCall("contenido","llamada a juan", client, DateTime.Now);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterEmailRegistersAnEmail()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.RegisterEmail("contenido",InteractionOrigin.Origin.Sent, "Email a juan",client, DateTime.Now);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterMeetingRegistersAMeeting()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.RegisterMeeting("Expulsion de juan","Rechazada","Edificio de la empresa",Meeting.MeetingState.Done,client,DateTime.Now);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterMessageRegistersAMessage()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.RegisterMessage("contenido", "Email a juan", InteractionOrigin.Origin.Received,"Whatsapp",client,DateTime.Now);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    public void CreateClientTest()
    {
        // Arrange
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Jose");
        // Act
        mainFacade.CreateClient("1","Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        // Assert 
        Assert.That(mainFacade.GetClients(), Is.Not.Empty);
    }

    [Test]
    public void GetClientTest()
    {
        // Arrange
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Jose");
        mainFacade.CreateClient("1","Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        mainFacade.CreateClient("2", "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        List<Client> expected = new List<Client>();
        Client client1 = new Client("1", "Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        expected.Add(client1);
        Client client2 = new Client("2", "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        expected.Add(client2);
        // Act
        List<Client> actual = mainFacade.GetClients();
        // Assert
        Assert.That(actual.Count, Is.EqualTo(expected.Count));
    }

    [Test]
    public void DeleteClientTest()
    {
        
    }
}

