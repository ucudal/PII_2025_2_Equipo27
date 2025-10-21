namespace Library.Tests;

public class MainFacadeTests
{
    [Test]
    public void CreateClientTest()
    {
        // Arrange
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Jose");
        // Act
        Client mario = mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        // Assert 
        Assert.That(mainFacade.GetClients(), Is.Not.Empty);
    }

    [Test]
    public void GetClientTest()
    {
        // Arrange
        MainFacade mainFacade = new MainFacade();
        Seller jose = new Seller("Jose");
        Client mario = mainFacade.CreateClient("Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        Client mariano = mainFacade.CreateClient( "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
        List<Client> expected = new List<Client>();
        Client client1 = new Client(0, "Mario", "Dias", "abcdefg", "123456789", Client.GenderType.male, "19/03/2000", jose);
        expected.Add(client1);
        Client client2 = new Client(1, "Mariano", "Dominguez", "gfedcba", "987654321", Client.GenderType.male, "02/12/1990", jose);
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

    [Test]
    public void SerchClientByNameTest()
    {
        
    }
}