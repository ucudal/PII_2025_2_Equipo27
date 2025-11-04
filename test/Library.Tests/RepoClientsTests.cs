using Library.interactions;

namespace Library.Tests;

public class RepoClientsTests
{
    [Test]
    public void TestGetClients()
    {
        // Arrange
        Seller jose = new Seller("Jose");
        RepoClients repoClients = new RepoClients();
        Client mario = new Client(1,"Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client(2, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        repoClients.AddClient(mario);
        repoClients.AddClient(mariano);
        List<Client> expected = new List<Client>();
        expected.Add(mario);
        expected.Add(mariano);
        // Act 
        List<Client> actual = repoClients.Clients;
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestAddClient()
    {
        // Arrange
        Seller jose = new Seller("Matteo");
        RepoClients repoClients = new RepoClients();
        Client mariano = new Client(2, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        List<Client> expected = new List<Client>();
        expected.Add(mariano);
        // Act
        repoClients.AddClient(mariano);
        // Assert
        Assert.That(repoClients.Clients, Is.EqualTo(expected));
    }

    [Test]
    public void TestDeleteClient()
    {
        // Arrange
        Seller jose = new Seller("Facundo");
        RepoClients repoClients = new RepoClients();
        Client mariano = new Client(2, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        repoClients.AddClient(mariano);
        // Act
        repoClients.DeleteClient(2);
        // Assert
        Assert.That(repoClients.Clients.Count, Is.EqualTo(0));
    }
    
    [Test]
    public void TestSerchClientByName()
    {
        // Arrange
        Seller jose = new Seller("Lucas");
        RepoClients repoClients = new RepoClients();
        Client mario = new Client(1,"Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client(2, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        repoClients.AddClient(mario);
        repoClients.AddClient(mariano);
        List<Client> expected = new List<Client>();
        expected.Add(mario);
        // Act
        List<Client> actual = repoClients.SearchClientByName("Mario");
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestSerchClientByLastName()
    {
        // Arrange
        Seller jose = new Seller("Peter");
        RepoClients repoClients = new RepoClients();
        Client mario = new Client(1,"Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client(2, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        repoClients.AddClient(mario);
        repoClients.AddClient(mariano);
        List<Client> expected = new List<Client>();
        expected.Add(mariano);
        // Act
        List<Client> actual = repoClients.SearchClientByLastName("Dominguez");
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestSerchClientByEmail()
    {
        // Arrange
        Seller jose = new Seller("Thomas");
        RepoClients repoClients = new RepoClients();
        Client mario = new Client(1,"Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client(2, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        repoClients.AddClient(mario);
        repoClients.AddClient(mariano);
        List<Client> expected = new List<Client>();
        expected.Add(mariano);
        // Act
        List<Client> actual = repoClients.SearchClientByEmail("gfedcba");
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestSerchClientByPhone()
    {
        // Arrange
        Seller jose = new Seller("Ezequiel");
        RepoClients repoClients = new RepoClients();
        Client mario = new Client(1,"Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client(2, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        repoClients.AddClient(mario);
        repoClients.AddClient(mariano);
        List<Client> expected = new List<Client>();
        expected.Add(mario);
        // Act
        List<Client> actual = repoClients.SearchClientByPhone("123456789");
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestInactiveClients()
    {
        // Arrange
        Seller jose = new Seller("Ezequiel");
        RepoClients repoClients = new RepoClients();
        Client mario = new Client(1,"Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client(2, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        Client josue = new Client(3, "Josue", "Nunes", "acbdegf", "132457689", Client.GenderType.male, "07/04/1950", jose);
        Client oscar = new Client(4, "Oscar", "Piastri", "gefdcba", "978653421", Client.GenderType.male, "31/10/2024", jose);
        repoClients.AddClient(mario);
        repoClients.AddClient(mariano);
        repoClients.AddClient(josue);
        repoClients.AddClient(oscar);
        mario.Inactive = true;
        oscar.Inactive = true;
        List<Client> expected = new List<Client>();
        expected.Add(mario);
        expected.Add(oscar);
        // Act
        List<Client> actual = repoClients.InactiveClients();
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestWaitingClients()
    {
        Seller jose = new Seller("Ezequiel");
        RepoClients repoClients = new RepoClients();
        Client mario = new Client(1,"Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client(2, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        Client josue = new Client(3, "Josue", "Nunes", "acbdegf", "132457689", Client.GenderType.male, "07/04/1950", jose);
        Client oscar = new Client(4, "Oscar", "Piastri", "gefdcba", "978653421", Client.GenderType.male, "31/10/2024", jose);
        repoClients.AddClient(mario);
        repoClients.AddClient(mariano);
        repoClients.AddClient(josue);
        repoClients.AddClient(oscar);
        mariano.Waiting = true;
        josue.Waiting = true;
        List<Client> expected = new List<Client>();
        expected.Add(mariano);
        expected.Add(josue);
        // Act
        List<Client> actual = repoClients.WaitingClients();
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
        
    [Test]
    public void GetPanel()
    {
        RepoClients repo = new RepoClients();
        Client client1 = new Client(1, "Ezequiel", "Pastorino", "eze@example.com", "099999999", Client.GenderType.male, "12/12/12", null);
        Client client2 = new Client(2, "Lucía", "García", "lucia@example.com", "098888888", Client.GenderType.Female, "1995-05-05", null);
        client1.AddInteraction(new Call("Llamada 1", "Notas 1", DateTime.Now.AddDays(-1)));
        client1.AddInteraction(new Meeting("Reunión 1", "Notas 2", "Sala A", Meeting.MeetingState.Programmed, DateTime.Now.AddDays(2))); 
        client2.AddInteraction(new Email("Email 1", InteractionOrigin.Origin.Sent, "Notas", DateTime.Now.AddDays(-1)));
        
        repo.AddClient(client1);
        repo.AddClient(client2);

        
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
        RepoClients repo = new RepoClients();
        Client client = new Client(1, "Ezequiel", "Pastorino", "eze@example.com", "099999999", Client.GenderType.male, "12/12/12", null);
        
        client.CreateOportunity("Azúcar",60,Opportunity.States.Open,client, new DateTime(2025,10,20));
        client.CreateOportunity("Arroz",60,Opportunity.States.Open,client, new DateTime(2025,10,20));

        repo.AddClient(client);
        DateTime startdate = new DateTime(2025, 10, 18);
        DateTime finishdate = new DateTime(2026, 10, 22);

        string exepted = "Cantidad de ventas dentro del período: 2";

        string panel = repo.GetTotalSales( startdate, finishdate);
        
        Assert.That(panel, Is.EqualTo(exepted));
    }
} 