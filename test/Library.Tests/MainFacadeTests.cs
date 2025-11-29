using Discord;
using Library.interactions; 
namespace Library.Tests;

public class MainFacadeTests
{
    [SetUp]
    public void SetUp()
    {
        RepoClients.ResetInstance();
        AdminFacade.ResetInstance();
        SellerFacade.ResetInstance();
    }
    [Test]
    public void ModifyOpportunityWorksCorrectly()
    {
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        Client client =  mainFacade.CreateClient("Juan", "Perez", "juanperez@gmail.com", "099888222", "Lucas");
        mainFacade.ModifyClient("0", "LastName", "Gutierrez");
        Assert.That(client.LastName,Is.EqualTo("Gutierrez"));
    }
    
    [Test]
    public void CreateOpportunityWorksCorrectly()
    {
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        Client client = mainFacade.CreateClient("Juan", "Perez", "juanperez@gmail.com", "099888222",  "Lucas");
        mainFacade.ModifyClient("0", "LastName", "Gutierrez");
        mainFacade.CreateOpportunity("Product", "100" , "Open", client);
        Assert.That(client.Opportunities.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void AddTagAddsATag()
    {
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        Client client= mainFacade.CreateClient( "Juan", "Perez", "juanperez@gmail.com", "099888222",  "Lucas");
        Tag tag = mainFacade.CreateTag("vip");
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
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        // Act
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", "Lucas");
        // Assert 
        Assert.That(mainFacade.GetClients(), Is.Not.Empty);
    }

    [Test]
    public void GetClientTest()
    {
        // Arrange
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  "Lucas");
        mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321",  "Lucas");
        // Act
        IReadOnlyCollection<Client> actual = mainFacade.GetClients();
        // Assert
        Assert.That(actual.Count, Is.EqualTo(2));
    }

    [Test]
    public void DeleteClientTest()
    {
        // Arrange
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", "Lucas");
        mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321",  "Lucas");
        // Act
        mainFacade.DeleteClient("0");
        //Assert
        Assert.That(mainFacade.GetClients().Count, Is.EqualTo(1));
    }

    [Test]
    public void SearchClient_ByNameTest()
    {
        // Arrange
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  "Lucas");
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  "Lucas");
        // Act
        List<Client> actual = mainFacade.SearchClient("Name","Mario");
        // Assert
        Assert.That(actual[0].Name, Is.EqualTo("Mario"));
    }
    
    [Test]
    public void SearchClient_ByLastNameTest()
    {
        // Arrange
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  "Lucas");
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  "Lucas");
        // Act
        List<Client> actual = mainFacade.SearchClient("LastName","Dominguez");
        // Assert
        Assert.That(actual[0].LastName, Is.EqualTo("Dominguez"));
    }
    
    [Test]
    public void SearchClient_ByEmailTest()
    {
        // Arrange
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  "Lucas");
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  "Lucas");
        // Act
        List<Client> actual = mainFacade.SearchClient( "Email","abcdefg");
        // Assert
        Assert.That(actual[0].Email, Is.EqualTo("abcdefg"));
    }
    
    [Test]
    public void SearchClient_ByPhoneTest()
    {
        // Arrange
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  "Lucas");
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  "Lucas");
        // Act
        List<Client> actual = mainFacade.SearchClient( "Phone","987654321");
        // Assert
        Assert.That(actual[0].Phone, Is.EqualTo("987654321"));
    }

    [Test]
    public void AddData_WorksinFacade()
    {
        Seller seller = AdminFacade.Instance.CreateSeller("kiki");
        SellerFacade.Instance.CreateClient("Antonie", "Griezmann", "Griezmann7@gmail.com", "123456789",  "kiki"); 
        IReadOnlyList<Client> clients = SellerFacade.Instance.GetClients();
        SellerFacade.Instance.AddData("0","Gender","Male");
        SellerFacade.Instance.AddData("0","BirthDate","21/03/1991");

        // Act
        string actualClientBirthDate = clients[0].BirthDate;
        Client.GenderType actualClientGender = clients[0].Gender;
        // Assert
        Assert.That(actualClientBirthDate, Is.EqualTo("21/03/1991"));
        Assert.That(actualClientGender, Is.EqualTo(Client.GenderType.Male));
    }
}

