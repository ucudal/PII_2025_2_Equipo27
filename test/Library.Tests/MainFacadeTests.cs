using Discord;
using Library.interactions; 
namespace Library.Tests;

public class MainFacadeTests
{
    [SetUp]
    public void SetUp()
    {
        RepoClients.ResetInstance();
    }
    [Test]
    public void ModifyOpportunityWorksCorrectly()
    {
        MainFacade mainFacade = new MainFacade();
        Seller seller = new Seller("Seller");
        Client client =  mainFacade.CreateClient("Juan", "Perez", "juanperez@gmail.com", "099888222", seller);
        mainFacade.ModifyClient("0", "LastName", "Gutierrez");
        Assert.That(client.LastName,Is.EqualTo("Gutierrez"));
    }
    
    [Test]
    public void CreateOpportunityWorksCorrectly()
    {
        MainFacade mainFacade = new MainFacade();
        Seller seller = new Seller("Seller");
        Client client = mainFacade.CreateClient("Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        mainFacade.ModifyClient("0", "LastName", "Gutierrez");
        mainFacade.CreateOpportunity("Product", 100 , Opportunity.States.Open, client);
        Assert.That(client.Opportunities.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void AddTagAddsATag()
    {
        MainFacade mainFacade = new MainFacade();
        Seller seller = new Seller("Seller");
        Client client= mainFacade.CreateClient( "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        Tag tag = new Tag("Electrodomesticos");
        mainFacade.ModifyClient("0", "LastName", "Gutierrez");
        mainFacade.AddTag(client,tag);
        Assert.That(client.Tags.Count,Is.EqualTo(1));
        Assert.That(client.Tags[0], Is.EqualTo(tag));
    }

    [Test]
    public void RegisterCallRegistersACall()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.RegisterCall("contenido","llamada a juan", client, DateTime.Now);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterEmailRegistersAnEmail()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.RegisterEmail("contenido",InteractionOrigin.Origin.Sent, "Email a juan",client, DateTime.Now);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterMeetingRegistersAMeeting()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.RegisterMeeting("Expulsion de juan","Rechazada","Edificio de la empresa",Meeting.MeetingState.Done,client,DateTime.Now);
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterMessageRegistersAMessage()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client(0, "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller);
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
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", jose);
        // Assert 
        Assert.That(mainFacade.GetClients(), Is.Not.Empty);
    }

    [Test]
    public void GetClientTest()
    {
        // Arrange
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Jose");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321",  jose);
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
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", jose);
        mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321",  jose);
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
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  jose);
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
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  jose);
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
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  jose);
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
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  jose);
        // Act
        List<Client> actual = mainFacade.SearchClient( RepoClients.TypeOfData.Phone,"987654321");
        // Assert
        Assert.That(actual[0].Phone, Is.EqualTo("987654321"));
    }

    [Test]
    public void AddData_WorksinFacade()
    {
        Seller seller = new Seller("Kiki");
        SellerFacade.Instance.CreateClient("Antonie", "Griezmann", "Griezmann7@gmail.com", "123456789",  seller); 
        IReadOnlyList<Client> clients = SellerFacade.Instance.GetClients();
        clients[0].AddData("Gender","Male");
        clients[0].AddData("birthdate","21/03/1991");

        // Act
        string actualClientBirthDate = clients[0].BirthDate;
        Client.GenderType actualClientGender = clients[0].Gender;
        // Assert
        Assert.That(actualClientBirthDate, Is.EqualTo("21/03/1991"));
        Assert.That(actualClientGender, Is.EqualTo(Client.GenderType.Male));
    }
}

