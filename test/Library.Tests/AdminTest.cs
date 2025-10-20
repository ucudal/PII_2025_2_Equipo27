namespace Library.Tests;

public class AdminTest
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void CreateSeller()
    {
        Admin admin = new Admin("Ezequiel");
        string name = "Lucas";

        Seller seller = admin.CreateSeller(name);

        Assert.That(seller.UserName, Is.EqualTo(name));
    }

    [Test]
    public void SuspendUser()
    {
        Admin admin = new Admin("Ezequiel");
        Seller user = admin.CreateSeller("Lucas");
        
        admin.SuspendSeller(user);
        
        Assert.That(user.Active, Is.False);
    }
}