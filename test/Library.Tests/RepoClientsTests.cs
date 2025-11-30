using Library.interactions;

namespace Library.Tests;

public class RepoClientsTests
{
    [SetUp]
    public void SetUp()
    {
        RepoClients.ResetInstance();
    }
    
    [Test]
    public void TestCreateClient()
    {
        // Arrange
        Seller jose = new Seller("Jose", 0);
        RepoClients repoClients = RepoClients.Instance;
        // Act
        repoClients.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        // Assert
        Assert.That(repoClients.Clients.Count, Is.EqualTo(1));
        Assert.That(repoClients.Clients[0].Id, Is.EqualTo(0));
    }

    [Test]
    public void TestGetClients()
    {
        // Arrange
        Seller jose = new Seller("Jose", 0);
        RepoClients repoClients = RepoClients.Instance;
        repoClients.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        repoClients.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  jose); 
        // Act 
        IReadOnlyList<Client> actual = repoClients.Clients;
        // Assert
        Assert.That(actual.Count, Is.EqualTo(2));
    }

    [Test]
    public void TestDeleteClient()
    {
        // Arrange
        Seller jose = new Seller("Facundo", 0);
        RepoClients repoClients = RepoClients.Instance;
        repoClients.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  jose);
        // Act
        repoClients.DeleteClient(0);
        // Assert
        Assert.That(repoClients.Clients.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestSearchClient_ByName()
    {
            //Arrange
            Seller jose = new Seller("Lucas", 0);
            RepoClients repoClients = RepoClients.Instance;
            repoClients.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
            repoClients.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  jose);
            // Act
            List<Client> actual = repoClients.SearchClient(RepoClients.TypeOfData.Name, "Mario");
            // Assert
            Assert.That(actual[0].Name, Is.EqualTo("mario"));
    }
    
    [Test]
    
    public void TestSearchClient_ByLastName()
    {
        // Arrange
        Seller jose = new Seller("Peter", 0);
        RepoClients repoClients = RepoClients.Instance;
        repoClients.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        repoClients.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  jose);
        // Act
        List<Client> actual = repoClients.SearchClient(RepoClients.TypeOfData.LastName,"Dominguez");
        // Assert
        Assert.That(actual[0].LastName, Is.EqualTo("dominguez"));
    }
    
    [Test]
    public void TestSearchClient_ByEmail()
    {
        // Arrange
        Seller jose = new Seller("Thomas", 0);
        RepoClients repoClients = RepoClients.Instance;
        repoClients.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        repoClients.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321", jose);
        // Act
        List<Client> actual = repoClients.SearchClient(RepoClients.TypeOfData.Email,"gfedcba");
        // Assert
        Assert.That(actual[0].Email, Is.EqualTo("gfedcba"));
    }
    
    [Test]
    public void TestSearchClient_ByPhone()
    {
        // Arrange
        Seller jose = new Seller("Ezequiel", 0);
        RepoClients repoClients = RepoClients.Instance;
        repoClients.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        repoClients.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  jose);
        // Act
        List<Client> actual = repoClients.SearchClient(RepoClients.TypeOfData.Phone,"123456789");
        // Assert
        Assert.That(actual[0].Phone, Is.EqualTo("123456789"));
    }
    
    [Test]
    public void TestInactiveClients()
    {
        // Arrange
        Seller jose = new Seller("Ezequiel", 0);
        RepoClients repoClients = RepoClients.Instance;
        repoClients.CreateClient("Mario", "Dias", "abcdefg", "123456789",  jose);
        repoClients.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321",  jose);
        repoClients.CreateClient("Josue", "Nunes", "acbdegf", "132457689", jose);
        repoClients.CreateClient("Oscar", "Piastri", "gefdcba", "978653421",  jose);
        List<Client> mario = repoClients.SearchClient(RepoClients.TypeOfData.Name, "Mario");
        List<Client> oscar = repoClients.SearchClient(RepoClients.TypeOfData.Name, "Oscar");
        mario[0].Inactive = true;
        oscar[0].Inactive = true;
        List<Client> expected = new List<Client>();
        expected.Add(mario[0]);
        expected.Add(oscar[0]);
        // Act
        List<Client> actual = repoClients.InactiveClients();
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestWaitingClients()
    {
        Seller jose = new Seller("Ezequiel", 0);
        RepoClients repoClients = RepoClients.Instance;
        repoClients.CreateClient("Mario", "Dias", "abcdefg", "123456789", jose);
        repoClients.CreateClient("Mariano", "Dominguez", "gfedcba", "987654321", jose);
        repoClients.CreateClient("Josue", "Nunes", "acbdegf", "132457689",  jose);
        repoClients.CreateClient("Oscar", "Piastri", "gefdcba", "978653421", jose);
        List<Client> mariano = repoClients.SearchClient(RepoClients.TypeOfData.Name, "Mariano");
        List<Client> josue = repoClients.SearchClient(RepoClients.TypeOfData.Name, "Josue");
        mariano[0].Waiting = true;
        josue[0].Waiting = true;
        List<Client> expected = new List<Client>();
        expected.Add(mariano[0]);
        expected.Add(josue[0]);
        // Act
        List<Client> actual = repoClients.WaitingClients();
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
        
    [Test]
    public void GetPanel()
    {
        RepoClients repo = RepoClients.Instance;
        Client client1 = repo.CreateClient( "Ezequiel", "Pastorino", "eze@example.com", "099999999",  null);
        Client client2 = repo.CreateClient( "Lucía", "García", "lucia@example.com", "098888888",  null);
        client1.AddInteraction(new Call("Llamada 1", "Notas 1", DateTime.Now.AddDays(-1)));
        client1.AddInteraction(new Meeting("Reunión 1", "Notas 2", "Sala A", Meeting.MeetingState.Programmed, DateTime.Now.AddDays(2))); 
        client2.AddInteraction(new Email("Email 1", InteractionOrigin.Origin.Sent, "Notas", DateTime.Now.AddDays(-1)));
        
        string expected = 
            $"Clientes totales: 2\n" +
            $"Interacciones en este último mes: 2\n" +
            $"Reuniones próximas 1";
        
        string panel = repo.GetPanel();
        
        Assert.That(panel, Is.EqualTo(expected) );
    }

    [Test]
    public void GetTotalSales()
    {
        RepoClients repo = RepoClients.Instance;
        Client client = repo.CreateClient( "Ezequiel", "Pastorino", "eze@example.com", "099999999",  null);

        client.CreateOpportunity("Azúcar",60,Opportunity.States.Open,client, new DateTime(2025,10,20));
        client.CreateOpportunity("Arroz",60,Opportunity.States.Open,client, new DateTime(2025,10,20));
        
        DateTime startdate = new DateTime(2025, 10, 18);
        DateTime finishdate = new DateTime(2026, 10, 22);

        string exepted = "Cantidad de ventas dentro del período: 2";

        string panel = repo.GetTotalSales( startdate, finishdate);
        
        Assert.That(panel, Is.EqualTo(exepted));
    }
} 