namespace Library.Tests;

public class RepoUsersTest
{
    [SetUp]
    public void Setup()
    {
        RepoUsers.ResetInstance();
    }

    /// <summary>
    /// Verifica que un usuario sea encontrado en la lista
    /// </summary>

    [Test]
    public void SearchUser_Existing()
    {
        RepoUsers users = RepoUsers.Instance;
        users.CreateSeller("marisol");

        Seller seller = users.SearchUser<Seller>(0);

        Assert.That(seller.UserName, Is.EqualTo("marisol"));
    }

    /// <summary>
    /// Verifica que un vendedor no sea encontrado porque no existe
    /// </summary>

    [Test]
    public void SearchUser_NotExisting()
    {
        RepoUsers users = RepoUsers.Instance;
        users.CreateSeller("Marisol");
        
        Assert.Throws<KeyNotFoundException>(()=>users.SearchUser<Seller>(1));
    }

    /// <summary>
    /// Verifica que se lance una excepción si el numero es negativo.
    /// </summary>
    [Test]
    public void SearchUser_InvalidId()
    {
        RepoUsers users = RepoUsers.Instance;
        users.CreateSeller("Marisol");
        
        Assert.Throws<ArgumentException>(()=>users.SearchUser<Seller>(-2));
    }

    [Test]
    public void SearchUser_IfTheIdDoesNotCorrespond()
    {
        RepoUsers users = RepoUsers.Instance;
        users.CreateAdmin("Triana");
        users.CreateSeller("Tadeo");
        users.CreateSeller("Francesco");

        Assert.Throws<InvalidCastException>(() => users.SearchUser<Admin>(1));
    }
    
    /// <summary>
    /// Verifica que se cree un administrador correctamente si este no existe
    /// </summary>

    [Test]
    public void CreateAdmin_NotExistUsername()
    {
        RepoUsers users = RepoUsers.Instance;
        string username1 = "lucas";
        string username2 = "facundo";

        Admin admin1 = users.CreateAdmin(username1);
        Admin admin2 = users.CreateAdmin(username2);

        Assert.That(admin1.UserName, Is.EqualTo(username1));
        Assert.That(admin1.Id, Is.EqualTo(0));
        Assert.That(admin2.UserName, Is.EqualTo(username2));
        Assert.That(admin2.Id, Is.EqualTo(1));
        Assert.That(users.Count, Is.EqualTo(2));
        Assert.That(users.GetAll()[0], Is.EqualTo(admin1));
    }

    /// <summary>
    /// Verifica que no se pueda crear un administrador porque
    /// ya se habia creado uno antes con el mismo nombre
    /// </summary>
    [Test]
    public void CreateAdmin_Existing()
    {
        RepoUsers users = RepoUsers.Instance;
        Admin admin1 = users.CreateAdmin("Luciano");
        
        var admin2 = Assert.Throws<InvalidOperationException>(() => users.CreateAdmin("Luciano"));
        Assert.That(admin2.Message, Does.Contain("Ya existe un user con ese nombre"));
    }
    
    /// <summary>
    /// Verifica que si se crea un administrador sin nombre, devuelva null
    /// </summary>

    [Test]
    public void CreateAdmin_Exception()
    {
        RepoUsers users = RepoUsers.Instance;
        
        
        var errorAdmin = Assert.Throws<InvalidOperationException>(() => users.CreateAdmin(""));
        Assert.That(errorAdmin.Message, Does.Contain("El usuario debe tener un nombre"));
    }

    /// <summary>
    /// Verifica que se cree un vendedor correctamente si este no existe
    /// </summary>

    [Test]
    public void CreateSeller_NotExistUsername()
    {
        RepoUsers users = RepoUsers.Instance;
        string username1 = "rodrigo";
        string username2 = "agustín";

        Seller seller1 = users.CreateSeller(username1);
        Seller seller2 = users.CreateSeller(username2);

        Assert.That(seller1.UserName, Is.EqualTo(username1));
        Assert.That(seller1.Id, Is.EqualTo(0));
        Assert.That(seller2.UserName, Is.EqualTo(username2));
        Assert.That(seller2.Id, Is.EqualTo(1));
        Assert.That(users.Count, Is.EqualTo(2));
        Assert.That(users.GetAll()[0], Is.EqualTo(seller1));
    }

    /// <summary>
    /// Verifica que no se pueda crear un vendedor porque
    /// ya se habia creado uno antes con el mismo nombre
    /// </summary>
    [Test]
    public void CreateSeller_Existing()
    {
        RepoUsers users = RepoUsers.Instance;
        Seller seller1 = users.CreateSeller("Luciano");
        
        var seller2 = Assert.Throws<InvalidOperationException>(() => users.CreateSeller("Luciano"));
        Assert.That(seller2.Message, Does.Contain("Ya existe un user con ese nombre"));
    }

    /// <summary>
    /// Verifica que si se crea un vendedor sin nombre, devuelva null
    /// </summary>

    [Test]
    public void CreateSeller_Exception()
    {
        RepoUsers users = RepoUsers.Instance;
        
        var errorSeller = Assert.Throws<InvalidOperationException>(() => users.CreateSeller(""));
        Assert.That(errorSeller.Message, Does.Contain("El usuario debe tener un nombre"));
    }

    /// <summary>
    /// Verifica que se agrege un usuario a la lista.
    /// </summary>
    [Test]
    public void AddUser()
    {
        RepoUsers repo = RepoUsers.Instance;
        
        repo.CreateAdmin("Emanuel");
        
        Assert.That(repo.Count, Is.EqualTo(1));
    }

    /// <summary>
    /// Verifica que se cree correctamente una lista con todos los usuarios ya creados.
    /// </summary>
    [Test]
    public void GetAllUsers()
    {
        RepoUsers repo = RepoUsers.Instance;
        repo.CreateSeller("Luis");
        repo.CreateAdmin("Alejandro");
        repo.CreateAdmin("Andrés");

        IReadOnlyList<User> users = repo.GetAll();
        
        Assert.That(users.Count, Is.EqualTo(3));
    }

    [Test]
    public void GetByIdFirst()
    {
        RepoUsers repo = RepoUsers.Instance;
        Seller seller= repo.CreateSeller("Mónica");

        User user = repo.GetById(0);
        
        Assert.That(user, Is.EqualTo(seller));
    }

    /// <summary>
    /// Verifica que un usuario sea eliminado
    /// </summary>

    [Test]
    public void DeleteUser_Existing()
    {
        RepoUsers users = RepoUsers.Instance;
        Seller seller = users.CreateSeller("Antonella");

        users.Remove(0);

        Assert.That(users.Count, Is.EqualTo(0));
    }
    
    /// <summary>
    /// Verifica que se lance una excepción si se ingresa un número negativo o un numero incorrecto.
    /// </summary>
    [Test]
    public void DeleteUser_Exceptions()
    {
        RepoUsers users = RepoUsers.Instance;
        Seller seller = users.CreateSeller("Antonella");


        Assert.Throws<ArgumentException>(()=>users.Remove(-1));
        Assert.Throws<KeyNotFoundException>(()=>users.Remove(2));
    }
    
    
    
}