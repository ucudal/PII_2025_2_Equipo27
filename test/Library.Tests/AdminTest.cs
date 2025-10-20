namespace Library.Tests;

public class AdminTest
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void CreateSeller_NotExistUsername()
    {
        Admin admin = new Admin("Ezequiel");
        string username = "Lucas";

        Seller seller = admin.CreateSeller(username);

        Assert.That(seller.UserName, Is.EqualTo(username));
        Assert.That(admin.sellers.Count, Is.EqualTo(1));
        Assert.That(admin.sellers[0],Is.EqualTo(seller));
    }

    [Test]

    public void CreateSeller_Existing()
    {
        Admin admin = new Admin("Rodrigo");
        Seller seller1 = admin.CreateSeller("Luciano");
        
        Seller seller2 = admin.CreateSeller("Luciano");

        Assert.That(seller2, Is.Null);
        Assert.That(admin.sellers.Count, Is.EqualTo(1));
    }
    

    [Test]
    public void SuspendSeller_IfItIsNotSuspended()
    {
        Admin admin = new Admin("Ámbar");
        Seller seller = admin.CreateSeller("Lucía");
        
        admin.SuspendSeller(seller);
        
        Assert.That(seller.Active, Is.False);
    }

    [Test]
    public void SuspendSeller_IfItWasAlredySusspend()
    {
        Admin admin = new Admin("María");
        Seller seller = admin.CreateSeller("Pablo");
        seller.Active = false;

        admin.SuspendSeller(seller);

        Assert.That(seller.Active, Is.False);
    }

    [Test]

    public void DeleteSeller_Existing()
    {
        Admin admin = new Admin("Juan");
        Seller seller = admin.CreateSeller("Antonella");
        
        admin.DeleteSeller(seller);
        
        Assert.That(admin.sellers.Count, Is.EqualTo(0));
    }
}