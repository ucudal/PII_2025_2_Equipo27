namespace Library.Tests;

public class RepoClientsTests
{
    [Test]
    public void TestGetClients()
    {
        // Arrange
        Seller jose = new Seller("Jose");
        RepoClients repoClients = new RepoClients();
        Client mario = new Client("1","Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client("2", "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
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
        Client mariano = new Client("2", "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
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
        Client mariano = new Client("2", "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        List<Client> expected = new List<Client>();
        repoClients.AddClient(mariano);
        // Act
        repoClients.DeleteClient(mariano);
        // Assert
        Assert.That(repoClients.Clients, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestSerchClientByName()
    {
        // Arrange
        Seller jose = new Seller("Lucas");
        RepoClients repoClients = new RepoClients();
        Client mario = new Client("1","Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client("2", "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
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
        Client mario = new Client("1","Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client("2", "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
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
        Client mario = new Client("1","Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client("2", "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
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
        Client mario = new Client("1","Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = new Client("2", "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
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
        
    }
    
    [Test]
    public void TestWaitingClients()
    {
        
    }
} 