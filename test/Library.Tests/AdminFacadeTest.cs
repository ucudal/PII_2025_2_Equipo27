namespace Library.Tests;

public class AdminFacadeTest
{
    [SetUp]
    public void SetUp()
    {
        AdminFacade.ResetInstance();
    }
    [Test]
    public void SuspendSeller()
    {
        AdminFacade facade = AdminFacade.Instance;
        
        Seller seller = facade.admin.CreateSeller("Daniela");
        facade.SuspendSeller("Daniela");
        
        
        Assert.That(seller.Active, Is.False);
    }
    
    [Test]
    public void ActiveSeller()
    {
        AdminFacade facade = AdminFacade.Instance;
        Seller seller = facade.admin.CreateSeller("Laura");

        facade.ActiveSeller("Laura");

        Assert.That(seller.Active, Is.True);
    }
    
    [Test]
    public void DeleteSeller_ValidName()
    {
        AdminFacade facade = AdminFacade.Instance;
        Seller seller = facade.admin.CreateSeller("Daniela");

        facade.DeleteSeller("Daniela");
        
        Assert.That(facade.admin.sellers.Count, Is.EqualTo(0));

    }


   
}
       