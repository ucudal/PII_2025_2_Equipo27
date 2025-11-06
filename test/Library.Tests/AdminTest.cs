namespace Library.Tests;

public class AdminTest
{
    [SetUp]
    public void Setup()
    {
    }


    /// <summary>
    /// Verifica que se cree un usuario correctamente si este no existe
    /// </summary>
    
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

    /// <summary>
    /// Verifica que no se pueda crear un vendedor porque ya se habia creado uno antes
    /// </summary>
    [Test]
    public void CreateSeller_Existing()
    {
        Admin admin = new Admin("Rodrigo");
        Seller seller1 = admin.CreateSeller("Luciano");
        
        Seller seller2 = admin.CreateSeller("Luciano");

        Assert.That(seller2, Is.Null);
        Assert.That(admin.sellers.Count, Is.EqualTo(1));
    }

    /// <summary>
    /// Verifica que se pueda activar un vendedor que estaba suspendido
    /// </summary>
    
    [Test]
    public void ActiveSeller_IfItIsNotActive()
    {
        Admin admin = new Admin("Julieta");
        Seller seller = admin.CreateSeller("Juliana");
        seller.Active = false;

        string example = admin.ActiveSeller(seller);
        
        Assert.That(seller.Active, Is.True);
        Assert.That(example,Is.EqualTo("El vendedor dejó de estar suspendido"));
    }
    
    /// <summary>
    /// Verifica que no se pueda activar un vendedor porque ya estaba en estado activo
    /// </summary>
    
    [Test]
    public void ActiveSeller_IfItWasAlredyActive()
    {
        Admin admin = new Admin("Silvia");
        Seller seller = admin.CreateSeller("Nahuel");
        seller.Active = true;

        string example = admin.ActiveSeller(seller);
        
        Assert.That(seller.Active, Is.True);
        Assert.That(example,Is.EqualTo("El vendedor ya estaba activo"));

    }
    
    /// <summary>
    /// Verifica que un vendedor sea suspendido que estaba en estado activo
    /// </summary>

    [Test]
    public void SuspendSeller_IfItIsNotSuspended()
    {
        Admin admin = new Admin("Ámbar");
        Seller seller = admin.CreateSeller("Lucía");
        
        string example = admin.SuspendSeller(seller);
        
        Assert.That(seller.Active, Is.False);
        Assert.That(example, Is.EqualTo("Vendedor suspendido"));
        
    }
    
    /// <summary>
    /// Verifica que no se pueda suspender un vendedor porque ya estaba suspendido
    /// </summary>
    [Test]
    public void SuspendSeller_IfItWasAlredySusspend()
    {
        Admin admin = new Admin("María");
        Seller seller = admin.CreateSeller("Pablo");
        seller.Active = false;

        string example = admin.SuspendSeller(seller);

        Assert.That(seller.Active, Is.False);
        Assert.That(example, Is.EqualTo("El vendedor ya estaba suspendido"));
    }

    /// <summary>
    /// Verifica que un vendedor sea eliminado
    /// </summary>
    
    [Test]
    public void DeleteSeller_Existing()
    {
        Admin admin = new Admin("Juan");
        Seller seller = admin.CreateSeller("Antonella");
        
        string example = admin.DeleteSeller(seller);
        
        Assert.That(admin.sellers.Count, Is.EqualTo(0));
        Assert.That(example, Is.EqualTo("Vendedor eliminado"));
    }
    
    /// <summary>
    /// Verifica que el vendedor no pueda ser eliminado porque no existe
    /// </summary>
    
    [Test]
    public void DeleteSeller_IfNotExist()
    {
        Admin admin = new Admin("Luca");
        Seller seller = new Seller("Matías");

        string example = admin.DeleteSeller(seller);
        
        Assert.That(example, Is.EqualTo("Ese vendedor no existe"));
    }
}