using Library.interactions; 
namespace Library.Tests;

public class MainFacadeTests
{
    [Test]
    public void ModifyOpportunityWorksCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.Male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.ModifyClient(client, Client.TypeOfData.LastName, "Gutierrez");
        Assert.That(client.LastName,Is.EqualTo("Gutierrez"));
    }
    
    [Test]
    public void CreateOpportunityWorksCorrectly()
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
    
    [Test]
    public void CreateClientTest()
    {
        // Arrange
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Jose");
        // Act
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        // Assert 
        Assert.That(mainFacade.GetClients(), Is.Not.Empty);
    }

    [Test]
    public void GetClientTest()
    {
        // Arrange
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Jose");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        // Act
        IReadOnlyCollection<Client> actual = mainFacade.GetClients();
        // Assert
        Assert.That(actual.Count, Is.EqualTo(2));
    }

    [Test]
    public void DeleteClientTest()
    {
        // Arrange
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Jose");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        // Act
        mainFacade.DeleteClient(0);
        //Assert
        Assert.That(mainFacade.GetClients().Count, Is.EqualTo(1));
    }

    [Test]
    public void SearchClient_ByNameTest()
    {
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        // Act
        List<Client> actual = mainFacade.SearchClient(RepoClients.TypeOfData.Name,"Mario");
        // Assert
        Assert.That(actual[0].Name, Is.EqualTo("Mario"));
    }
    
    [Test]
    public void SearchClient_ByLastNameTest()
    {
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        // Act
        List<Client> actual = mainFacade.SearchClient(RepoClients.TypeOfData.LastName,"Dominguez");
        // Assert
        Assert.That(actual[0].LastName, Is.EqualTo("Dominguez"));
    }
    
    [Test]
    public void SearchClient_ByEmailTest()
    {
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        // Act
        List<Client> actual = mainFacade.SearchClient( RepoClients.TypeOfData.Email,"abcdefg");
        // Assert
        Assert.That(actual[0].Email, Is.EqualTo("abcdefg"));
    }
    
    [Test]
    public void SearchClient_ByPhoneTest()
    {
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.Male, "19/03/2000", jose);
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.Male, "02/12/1990", jose);
        // Act
        List<Client> actual = mainFacade.SearchClient( RepoClients.TypeOfData.Phone,"987654321");
        // Assert
        Assert.That(actual[0].Phone, Is.EqualTo("987654321"));
    }
}

