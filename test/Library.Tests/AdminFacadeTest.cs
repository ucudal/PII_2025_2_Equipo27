namespace Library.Tests;

public class AdminFacadeTest
{
    [SetUp]
    public void SetUp()
    {
        AdminFacade.ResetInstance();
        RepoClients.ResetInstance();
        RepoUsers.ResetInstance();
    }
    [Test]
    public void SuspendUser()
    {
        AdminFacade facade = AdminFacade.Instance;
        
        Seller seller = facade.CreateSeller("Daniela");
        facade.SuspendUser("0");
        
        
        Assert.That(seller.Active, Is.False);
    }
    
    [Test]
    public void ActiveUser()
    {
        AdminFacade facade = AdminFacade.Instance;
        Seller seller = facade.CreateSeller("Laura");

        facade.ActiveUser("0");

        Assert.That(seller.Active, Is.True);
    }
    
  


   
}
       