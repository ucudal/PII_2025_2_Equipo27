namespace Library.Tests;

public class RepoClientsTests
{
    [Test]
    public void TestGetClients()
    {
        // Arrange
        RepoClients repoClients = new RepoClients();
        Client mario = new Client("Mario", "Dias", "abcdefg", "123456789");
        Client mariano = new Client("Mariano", "Dominguez", "gfedcba", "987654321");
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
        RepoClients repoClients = new RepoClients();
        Client mariano = new Client("Mariano", "Dominguez", "gfedcba", "987654321");
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
        RepoClients repoClients = new RepoClients();
        Client mariano = new Client("Mariano", "Dominguez", "gfedcba", "987654321");
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
        RepoClients repoClients = new RepoClients();
        Client mario = new Client("Mario", "Dias", "abcdefg", "123456789");
        Client mariano = new Client("Mariano", "Dominguez", "gfedcba", "987654321");
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
        RepoClients repoClients = new RepoClients();
        Client mario = new Client("Mario", "Dias", "abcdefg", "123456789");
        Client mariano = new Client("Mariano", "Dominguez", "gfedcba", "987654321");
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
        RepoClients repoClients = new RepoClients();
        Client mario = new Client("Mario", "Dias", "abcdefg", "123456789");
        Client mariano = new Client("Mariano", "Dominguez", "gfedcba", "987654321");
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
        RepoClients repoClients = new RepoClients();
        Client mario = new Client("Mario", "Dias", "abcdefg", "123456789");
        Client mariano = new Client("Mariano", "Dominguez", "gfedcba", "987654321");
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