namespace Library.Tests;

public class RepoUserTest
{
    [SetUp]
    public void Setup()
    {
        RepoUser.ResetInstance();
    }

    /// <summary>
    /// Verifica que un usuario sea encontrado en la lista
    /// </summary>

    [Test]
    public void SearchUser_Existing()
    {
        RepoUser users = RepoUser.Instance;
        Seller seller = users.CreateSeller("Marisol");
        

        Assert.That(seller.UserName, Is.EqualTo("Marisol"));
    }

    /// <summary>
    /// Verifica que un vendedor no sea encontrado porque no existe
    /// </summary>

    [Test]
    public void SearchUser_NotExisting()
    {
        RepoUser users = RepoUser.Instance;
        users.CreateSeller("Marisol");

        Seller seller = users.SearchUser<Seller>(1);

        Assert.That(seller, Is.Null);
    }
    
    /// <summary>
    /// Verifica que se cree un administrador correctamente si este no existe
    /// </summary>

    [Test]
    public void CreateAdmin_NotExistUsername()
    {
        RepoUser users = RepoUser.Instance;
        string username = "Lucas";

        Admin admin = users.CreateAdmin(username);

        Assert.That(admin.UserName, Is.EqualTo(username));
        Assert.That(users.Users.Count, Is.EqualTo(1));
        Assert.That(users.Users[0], Is.EqualTo(admin));
    }

    /// <summary>
    /// Verifica que no se pueda crear un administrador porque
    /// ya se habia creado uno antes con el mismo nombre
    /// </summary>
    [Test]
    public void CreateAdmin_Existing()
    {
        RepoUser users = RepoUser.Instance;
        Admin seller1 = users.CreateAdmin("Luciano");

        Admin seller2 = users.CreateAdmin("Luciano");

        Assert.That(seller2, Is.Null);
        Assert.That(users.Users.Count, Is.EqualTo(1));
    }
    
    /// <summary>
    /// Verifica que si se crea un administrador sin nombre, devuelva null
    /// </summary>

    [Test]
    public void CreateAdmin_Exception()
    {
        RepoUser users = RepoUser.Instance;
        Admin admin = users.CreateAdmin("");

        Assert.That(admin, Is.Null);
    }

    /// <summary>
    /// Verifica que se cree un vendedor correctamente si este no existe
    /// </summary>

    [Test]
    public void CreateSeller_NotExistUsername()
    {
        RepoUser users = RepoUser.Instance;
        string username = "Lucas";

        Seller seller = users.CreateSeller(username);

        Assert.That(seller.UserName, Is.EqualTo(username));
        Assert.That(users.Users.Count, Is.EqualTo(1));
        Assert.That(users.Users[0], Is.EqualTo(seller));
    }

    /// <summary>
    /// Verifica que no se pueda crear un vendedor porque
    /// ya se habia creado uno antes con el mismo nombre
    /// </summary>
    [Test]
    public void CreateSeller_Existing()
    {
        RepoUser users = RepoUser.Instance;
        Seller seller1 = users.CreateSeller("Luciano");

        Seller seller2 = users.CreateSeller("Luciano");

        Assert.That(seller2, Is.Null);
        Assert.That(users.Users.Count, Is.EqualTo(1));
    }

    /// <summary>
    /// Verifica que si se crea un vendedor sin nombre, devuelva null
    /// </summary>

    [Test]
    public void CreateSeller_Exception()
    {
        RepoUser users = RepoUser.Instance;
        Seller seller = users.CreateSeller("");

        Assert.That(seller, Is.Null);
    }

    


    /// <summary>
    /// Verifica que un usuario sea eliminado
    /// </summary>

    [Test]
    public void DeleteUser_Existing()
    {
        RepoUser users = RepoUser.Instance;
        Seller seller = users.CreateSeller("Antonella");

        users.DeleteUser(0);

        Assert.That(users.Users.Count, Is.EqualTo(0));
    }
    
}