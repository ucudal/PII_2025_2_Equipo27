namespace Library.Tests;

public class AdminTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateUser()
    {
        Admin admin = new Admin("Ezequiel");
        string name = "Lucas";

        User user = admin.CreateUser(name);

        Assert.That(user.UserName, Is.EqualTo(name));
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
        User user = admin.CreateUser("Lucas");
        
        admin.SuspendUser(user);
        
        Assert.That(user.Active, Is.False);
    }
}