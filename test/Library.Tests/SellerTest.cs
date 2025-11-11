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
        Admin admin = new Admin("Famapez");
        Seller seller1 = admin.CreateSeller("Peter");
        Seller seller2 = admin.CreateSeller("Matteo");
        
        Client client = new Client(1, "Hugo", "López", "hugolopez@", "555555555", Client.GenderType.Male, "10/10/01",null);
        seller1.AsignClient(seller2,client);
        Assert.That(seller2.Clients.Count,Is.EqualTo(1));
        Assert.That(seller2.Clients[0], Is.EqualTo(client));
        Assert.That(client.AsignedSeller, Is.EqualTo(seller2));
    }
}
