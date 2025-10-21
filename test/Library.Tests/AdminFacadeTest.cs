namespace Library.Tests;

public class AdminFacadeTest
{
    [Test]
    public void SuspendSeller_ValidName()
    {
        AdminFacade facade = new AdminFacade();
        facade.admin.CreateSeller("Daniela");

        string example = facade.SuspendSeller("Daniela");
        
        Assert.That(example, Is.EqualTo("Vendedor suspendido"));
    }
    
    [Test]
    public void SuspendSeller_InvalidName()
    {
        
        AdminFacade facade = new AdminFacade();
        facade.admin.CreateSeller("Laura");

        string example = facade.SuspendSeller("José");
        
        Assert.That(example, Is.EqualTo("El nombre de usuario ingresado no existe"));
    }

    [Test]
    public void ActiveSeller_ValidName()
    {
        AdminFacade facade = new AdminFacade();
        facade.admin.CreateSeller("Laura");

        string example = facade.ActiveSeller("Laura");
        
        Assert.That(example, Is.EqualTo("El vendedor ya estaba activo"));
    }

    [Test]
    public void ActiveSeller_InvalidName()
    {
        AdminFacade facade = new AdminFacade();
        facade.admin.CreateSeller("Laura");

        string example = facade.ActiveSeller("José");
        
        Assert.That(example, Is.EqualTo("El nombre de usuario ingresado no existe"));
    }
    
    [Test]
    public void DeleteSeller_ValidName()
    {
        AdminFacade facade = new AdminFacade();
        facade.admin.CreateSeller("Daniela");

        string example = facade.DeleteSeller("Daniela");
        Assert.That(example, Is.EqualTo("Vendedor eliminado"));

    }


    [Test]
    public void DeleteSeller_InvalidName()
    {
        Admin admin = new Admin("Martín");
        Seller seller = admin.CreateSeller("Daniela");
        AdminFacade facade = new AdminFacade();

        string example = facade.DeleteSeller("José");
        
        Assert.That(example, Is.EqualTo("El nombre de usuario ingresado no existe"));
    }
}