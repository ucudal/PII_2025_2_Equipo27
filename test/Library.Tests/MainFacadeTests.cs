using Discord;
using Library.interactions; 
namespace Library.Tests;

public class MainFacadeTests
{
    [SetUp]
    public void SetUp()
    {
        RepoClients.ResetInstance();
        RepoUsers.ResetInstance();
        AdminFacade.ResetInstance();
        SellerFacade.ResetInstance();
    }
    [Test]
    public void ModifyOpportunityWorksCorrectly()
    {
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        Client client =  mainFacade.CreateClient("Juan", "Perez", "juanperez@gmail.com", "099888222", "0");
        mainFacade.ModifyClient("0", "LastName", "Gutierrez");

        Assert.That(client.LastName,Is.EqualTo("gutierrez"));
    }
    
    [Test]
    public void CreateOpportunityWorksCorrectly()
    {
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        Client client = mainFacade.CreateClient("Juan", "Perez", "juanperez@gmail.com", "099888222",  "0");
        mainFacade.ModifyClient("0", "LastName", "Gutierrez");
        mainFacade.CreateOpportunity("Product", "100" , "Open", client.Id.ToString());

        Assert.That(client.Opportunities.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void AddTagAddsATag()
    {
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        Client client= mainFacade.CreateClient( "Juan", "Perez", "juanperez@gmail.com", "099888222",  "0");
        mainFacade.ModifyClient("0", "LastName", "Gutierrez");
        Tag tag = mainFacade.CreateTag("vip");
        mainFacade.AddTag(client.Id.ToString(),tag.Id.ToString());
        Assert.That(client.Tags.Count,Is.EqualTo(1));
        Assert.That(client.Tags[0], Is.EqualTo(tag));
    }

    [Test]
    public void RegisterCallRegistersACall()
    {
        MainFacade mainFacade = new MainFacade();
        AdminFacade adminFacade = AdminFacade.Instance;
        Seller seller = adminFacade.CreateSeller("seller");
        Client client = mainFacade.CreateClient( "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller.Id.ToString());
        mainFacade.RegisterCall("contenido","llamada a juan", client.Id.ToString());
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterEmailRegistersAnEmail()
    {
        MainFacade mainFacade = new MainFacade();
        AdminFacade adminFacade = AdminFacade.Instance;
        Seller seller = adminFacade.CreateSeller("seller");
        Client client = mainFacade.CreateClient( "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller.Id.ToString());
        mainFacade.RegisterEmail("contenido","Sent", "Email a juan",client.Id.ToString());
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterMeetingRegistersAMeeting()
    {
        
        MainFacade mainFacade = new MainFacade();
        AdminFacade adminFacade = AdminFacade.Instance;
        Seller seller = adminFacade.CreateSeller("seller");
        Client client = mainFacade.CreateClient( "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller.Id.ToString());
        mainFacade.RegisterMeeting("Expulsion de juan","Rechazada","Edificio de la empresa","Done",client.Id.ToString(),"10/12/2025");
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void RegisterMessageRegistersAMessage()
    {
        MainFacade mainFacade = new MainFacade();
        AdminFacade adminFacade = AdminFacade.Instance;
        Seller seller = adminFacade.CreateSeller("seller");
        Client client = mainFacade.CreateClient( "Juan", "Perez", "juanperez@gmail.com", "099888222",  seller.Id.ToString());
        mainFacade.RegisterMessage("contenido", "Email a juan", "Received","Whatsapp",client.Id.ToString());
        Assert.That(client.Interactions.Count,Is.EqualTo(1));
    }
    
    [Test]
    public void CreateClientTest()
    {
        // Arrange
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        // Act
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", "0");

        // Assert 
        Assert.That(mainFacade.GetClients(), Is.Not.Empty);
    }

    [Test]
    public void GetClientTest()
    {
        // Arrange
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  "0");
        mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321",  "0");

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
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", "0");
        mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321",  "0");

        // Act
        mainFacade.DeleteClient("0");
        //Assert
        Assert.That(mainFacade.GetClients().Count, Is.EqualTo(1));
    }

    [Test]
    public void SearchClient_ByNameTest()
    {
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  "0");
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  "0");

        // Act
        List<Client> actual = mainFacade.SearchClient("Name","Mario");
        // Assert
        Assert.That(actual[0].Name, Is.EqualTo("mario"));
    }
    
    [Test]
    public void SearchClient_ByLastNameTest()
    {
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  "0");
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  "0");

        // Act
        List<Client> actual = mainFacade.SearchClient("LastName","Dominguez");
        // Assert
        Assert.That(actual[0].LastName, Is.EqualTo("dominguez"));
    }
    
    [Test]
    public void SearchClient_ByEmailTest()
    {
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  "0");
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  "0");

        // Act
        List<Client> actual = mainFacade.SearchClient( "Email","abcdefg");
        // Assert
        Assert.That(actual[0].Email, Is.EqualTo("abcdefg"));
    }
    
    [Test]
    public void SearchClient_ByPhoneTest()
    {
        AdminFacade mainFacade = AdminFacade.Instance;
        Seller jose = mainFacade.CreateSeller("Lucas");
        mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789",  "0");
        mainFacade.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  "0");

        // Act
        List<Client> actual = mainFacade.SearchClient( "Phone","987654321");
        // Assert
        Assert.That(actual[0].Phone, Is.EqualTo("987654321"));
    }

    [Test]
    public void AddData_WorksinFacade()
    {
        Seller seller = AdminFacade.Instance.CreateSeller("kiki");
        SellerFacade.Instance.CreateClient("Antonie", "Griezmann", "Griezmann7@gmail.com", "123456789",  "0"); 
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

