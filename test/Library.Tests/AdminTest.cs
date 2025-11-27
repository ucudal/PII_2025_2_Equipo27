namespace Library.Tests;

public class AdminTest
{
    /// <summary>
    /// Verifica que no se pueda activar un usuario nulo
    /// </summary>
    [Test]
    public void ActiveUser_Exception()
    {
        Admin admin = new Admin("Julieta", 0);

        Assert.Throws<ArgumentNullException>(() => admin.ActiveUser(null));
    }


    /// <summary>
    /// Verifica que se pueda activar un usuario que estaba suspendido
    /// </summary>

    [Test]
    public void ActiveUser()
    {
        RepoUsers repoUsers = RepoUsers.Instance;
        Admin admin = new Admin("Julieta", 0);
        Seller seller = repoUsers.CreateSeller("Juliana");
        seller.Active = false;

        admin.ActiveUser(seller);

        Assert.That(seller.Active, Is.True);
    }
    

    /// <summary>
    /// Verifica que no se pueda suspender un usuario nulo
    /// </summary>
    [Test]
    public void suspendUser_Exception()
    {
        Admin admin = new Admin("Julieta", 0);

        Assert.Throws<ArgumentNullException>(() => admin.SuspendUser(null));
    }

    /// <summary>
    /// Verifica que un usuario sea suspendido que estaba en estado activo
    /// </summary>

    [Test]
    public void SuspendUser()
    {
        RepoUsers repoUsers = RepoUsers.Instance;
        Admin admin = new Admin("Ámbar", 0);
        Seller seller = repoUsers.CreateSeller("Lucía");

        admin.SuspendUser(seller);

        Assert.That(seller.Active, Is.False);


    }

    
}
    
