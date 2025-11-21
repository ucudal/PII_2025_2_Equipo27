namespace Library.Tests;

public class SellerTest
{
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Verifica que sea asignado un cliente a un vendedor correctamente
    /// </summary>
    
    [Test]
    public void AsignNewClient()
    {
        RepoUser repoUsers = new RepoUser();
        Seller seller1 = repoUsers.CreateSeller("Peter");
        Seller seller2 = repoUsers.CreateSeller("Matteo");
        
        Client client = new Client(1, "Hugo", "López", "hugolopez@", "555555555", Client.GenderType.Male, "10/10/01",null);
        seller1.AsignClient(seller2,client);
        Assert.That(seller2.Clients.Count,Is.EqualTo(1));
        Assert.That(seller2.Clients[0], Is.EqualTo(client));
        Assert.That(client.AsignedSeller, Is.EqualTo(seller2));
    }

    /// <summary>
    /// Verifica que se lance una excepción si el vendedor es nulo
    /// </summary>
    [Test]
    public void AsignClient_IfTheClientIsNull()
    {
        RepoUser repoUsers = new RepoUser();
        Seller seller1 = repoUsers.CreateSeller("Facundo");
        Seller seller2 = repoUsers.CreateSeller("Matteo");

        Assert.Throws<ArgumentNullException>(() => seller1.AsignClient(seller2, null));
    }
    
    /// <summary>
    /// Verifica que se lance una excepcion si el cliente es nulo
    /// </summary>
    [Test]
    public void AsignClient_IfTheSellerIsNull()
    {
        RepoUser repoUsers = new RepoUser();
        Seller seller1 = repoUsers.CreateSeller("Thomas");
        
        Client client = new Client(1, "Hugo", "López", "hugolopez@", "555555555", Client.GenderType.Male, "10/10/01",null);

        Assert.Throws<ArgumentNullException>(() => seller1.AsignClient(null, client));
    }
}
