namespace Library.Tests;

public class SellerTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AsignNewClient()
    {
        Admin admin = new Admin("Famapez");
        Seller seller1 = admin.CreateSeller("Peter");
        Seller seller2 = admin.CreateSeller("Matteo");
        Client client = new Client("1", "Hugo", "López", "hugolopez@", "555555555", Client.GenderType.male, "10/10/01",null);
        

        string experiment = seller1.AsignClient(seller2,client);
        
        Assert.That(seller2.thisClients.Count,Is.EqualTo(1));
        Assert.That(seller2.thisClients[0], Is.EqualTo(client));
        Assert.That(experiment, Is.EqualTo("Cliente agregado"));
    }
}
