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
        
        Seller seller = facade.CreateSeller("Daniela");
        facade.SuspendSeller("Daniela");
        
        
        Assert.That(seller.Active, Is.False);
    }
    
    [Test]
    public void ActiveSeller()
    {
        AdminFacade facade = AdminFacade.Instance;
        Seller seller = facade.CreateSeller("Laura");

        facade.ActiveSeller("Laura");

        Assert.That(seller.Active, Is.True);
    }
    
  


   
}
       