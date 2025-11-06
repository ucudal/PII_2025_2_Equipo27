using Library.interactions; 
namespace Library.Tests;

public class MainFacadeTests
{
    [Test]
    public void ModifyOportunityWorksCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.ModifyClient(client, Client.TypeOfData.LastName, "Gutierrez");
        Assert.That(client.LastName,Is.EqualTo("Gutierrez"));
    }
    
    [Test]
    public void CreateOportunityWorksCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.ModifyClient(client, Client.TypeOfData.LastName, "Gutierrez");
        mainFacade.CreateOportunity("Product", 100 , Opportunity.States.Open, client);
        Assert.That(client.Opportunities.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void AddTagAddsATag()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
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
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.RegisterCall("contenido","llamada a juan", client, DateTime.Now);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterEmailRegistersAnEmail()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.RegisterEmail("contenido",InteractionOrigin.Origin.Sent, "Email a juan",client, DateTime.Now);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterMeetingRegistersAMeeting()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.RegisterMeeting("Expulsion de juan","Rechazada","Edificio de la empresa",Meeting.MeetingState.Done,client,DateTime.Now);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterMessageRegistersAMessage()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
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
        Client mario = mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        // Assert 
        Assert.That(mainFacade.GetClients(), Is.Not.Empty);
    }

    [Test]
    public void GetClientTest()
    {
        // Arrange
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Jose");
        Client mario = mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        Client mariano = mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        List<Client> expected = new List<Client>();
        Client client1 = new Client(0, "Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        expected.Add(client1);
        Client client2 = new Client(1, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        expected.Add(client2);
        // Act
        List<Client> actual = mainFacade.GetClients();
        // Assert
        Assert.That(actual.Count, Is.EqualTo(expected.Count));
    }

    [Test]
    public void DeleteClientTest()
    {
        // Arrange
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Jose");
        Client mario = mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        Client mariano = mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        
        // Act
        mainFacade.DeleteClient(0);
        
        //Assert
        Assert.That(mainFacade.GetClients().Count, Is.EqualTo(1));
    }

    [Test]
    public void SerchClientByNameTest()
    {
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Lucas");
        Client mario = mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        Client mariano = mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        List<Client> expected = new List<Client>();
        expected.Add(mario);
        // Act
        List<Client> actual = mainFacade.SearchClientByName("Mario");
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SerchClientByLastNameTest()
    {
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Lucas");
        Client mario = mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        Client mariano = mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        List<Client> expected = new List<Client>();
        expected.Add(mariano);
        // Act
        List<Client> actual = mainFacade.SearchClientByLastName("Dominguez");
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void SerchClientByEmailTest()
    {
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Lucas");
        Client mario = mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        Client mariano = mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        List<Client> expected = new List<Client>();
        expected.Add(mario);
        // Act
        List<Client> actual = mainFacade.SearchClientByEmail("abcdefg");
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void SerchClientByPhoneTest()
    {
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Lucas");
        Client mario = mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        Client mariano = mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        List<Client> expected = new List<Client>();
        expected.Add(mariano);
        // Act
        List<Client> actual = mainFacade.SearchClientByPhone("987654321");
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}

