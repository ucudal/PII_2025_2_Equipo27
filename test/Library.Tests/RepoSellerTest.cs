namespace Library.Tests;

public class RepoSellerTest
{
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Verifica que un vendedor sea encontrado en la lista
    /// </summary>

    [Test]
    public void SearchSeller_Existing()
    {
        RepoSeller sellers = new RepoSeller();
        Seller seller = sellers.CreateSeller("Marisol");
        

        Assert.That(seller.UserName, Is.EqualTo("Marisol"));
    }

    /// <summary>
    /// Verifica que un vendedor no sea encontrado porque no existe
    /// </summary>

    [Test]
    public void SearchSeller_NotExisting()
    {
        RepoSeller sellers = new RepoSeller();
        sellers.CreateSeller("Marisol");

        Seller seller = sellers.SearchSeller("Lucas");

        Assert.That(seller, Is.Null);
    }


    /// <summary>
    /// Verifica que se cree un usuario correctamente si este no existe
    /// </summary>

    [Test]
    public void CreateSeller_NotExistUsername()
    {
        RepoSeller sellers = new RepoSeller();
        string username = "Lucas";

        Seller seller = sellers.CreateSeller(username);

        Assert.That(seller.UserName, Is.EqualTo(username));
        Assert.That(sellers.Sellers.Count, Is.EqualTo(1));
        Assert.That(sellers.Sellers[0], Is.EqualTo(seller));
    }

    /// <summary>
    /// Verifica que no se pueda crear un vendedor porque ya se habia creado uno antes
    /// </summary>
    [Test]
    public void CreateSeller_Existing()
    {
        RepoSeller sellers = new RepoSeller();
        Seller seller1 = sellers.CreateSeller("Luciano");

        Seller seller2 = sellers.CreateSeller("Luciano");

        Assert.That(seller2, Is.Null);
        Assert.That(sellers.Sellers.Count, Is.EqualTo(1));
    }

    /// <summary>
    /// Verifica que si se crea un vendedor sin nombre, devuelva null
    /// </summary>

    [Test]
    public void CreateSeller_Exception()
    {
        RepoSeller sellers = new RepoSeller();
        Seller seller = sellers.CreateSeller("");

        Assert.That(seller, Is.Null);
    }

    

  
  

    /// <summary>
    /// Verifica que no se pueda eliminar un vendedor nulo
    /// </summary>
    [Test]
    public void DeleteSeller_Exception()
    {
        RepoSeller sellers = new RepoSeller();

        Assert.Throws<ArgumentNullException>(() => sellers.DeleteSeller(null));
    }


    /// <summary>
    /// Verifica que un vendedor sea eliminado
    /// </summary>

    [Test]
    public void DeleteSeller_Existing()
    {
        RepoSeller sellers = new RepoSeller();
        Seller seller = sellers.CreateSeller("Antonella");

        sellers.DeleteSeller(seller);

        Assert.That(sellers.Sellers.Count, Is.EqualTo(0));
    }
}