namespace Library.Tests;

public class AdminTest
{
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Verifica en un vendedor sea encontrado en la lista
    /// </summary>

    [Test]
    public void SearchSeller_Existing()
    {
        Admin admin = new Admin("Lucas");
        admin.CreateSeller("Marisol");

        Seller seller = admin.SearchSeller("Marisol");

        Assert.That(seller.UserName, Is.EqualTo("Marisol"));
    }

    /// <summary>
    /// Verifica que un vendedor no sea encontrado porque no existe
    /// </summary>

    [Test]
    public void SearchSeller_NotExisting()
    {
        Admin admin = new Admin("Lucas");
        admin.CreateSeller("Marisol");

        Seller seller = admin.SearchSeller("Lucas");

        Assert.That(seller, Is.Null);
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
        Assert.That(admin.sellers[0], Is.EqualTo(seller));
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
    /// Verifica que si se crea un vendedor sin nombre, devuelva null
    /// </summary>

    [Test]
    public void CreateSeller_Exception()
    {
        Admin admin = new Admin("Alejandra");

        Seller seller = admin.CreateSeller("");

        Assert.That(seller, Is.Null);
    }

    /// <summary>
    /// Verifica que no se pueda activar un vendedor nulo
    /// </summary>
    [Test]
    public void ActiveSeller_Exception()
    {
        Admin admin = new Admin("Julieta");

        Assert.Throws<ArgumentNullException>(() => admin.ActiveSeller(null));
    }


    /// <summary>
    /// Verifica que se pueda activar un vendedor que estaba suspendido
    /// </summary>

    [Test]
    public void ActiveSeller()
    {
        Admin admin = new Admin("Julieta");
        Seller seller = admin.CreateSeller("Juliana");
        seller.Active = false;

        admin.ActiveSeller(seller);

        Assert.That(seller.Active, Is.True);
    }
    

    /// <summary>
    /// Verifica que no se pueda suspender un vendedor nulo
    /// </summary>
    [Test]
    public void suspendSeller_Exception()
    {
        Admin admin = new Admin("Julieta");

        Assert.Throws<ArgumentNullException>(() => admin.SuspendSeller(null));
    }

    /// <summary>
    /// Verifica que un vendedor sea suspendido que estaba en estado activo
    /// </summary>

    [Test]
    public void SuspendSeller()
    {
        Admin admin = new Admin("Ámbar");
        Seller seller = admin.CreateSeller("Lucía");

        admin.SuspendSeller(seller);

        Assert.That(seller.Active, Is.False);


    }

    /// <summary>
    /// Verifica que no se pueda eliminar un vendedor nulo
    /// </summary>
    [Test]
    public void DeleteSeller_Exception()
    {
        Admin admin = new Admin("Julieta");

        Assert.Throws<ArgumentNullException>(() => admin.DeleteSeller(null));
    }


    /// <summary>
    /// Verifica que un vendedor sea eliminado
    /// </summary>

    [Test]
    public void DeleteSeller_Existing()
    {
        Admin admin = new Admin("Juan");
        Seller seller = admin.CreateSeller("Antonella");

        admin.DeleteSeller(seller);

        Assert.That(admin.sellers.Count, Is.EqualTo(0));
    }
    
}
    
