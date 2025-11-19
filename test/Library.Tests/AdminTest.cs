namespace Library.Tests;

public class AdminTest
{
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
        RepoSeller repoSeller = new RepoSeller();
        Admin admin = new Admin("Julieta");
        Seller seller = repoSeller.CreateSeller("Juliana");
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
        RepoSeller repoSeller = new RepoSeller();
        Admin admin = new Admin("Ámbar");
        Seller seller = repoSeller.CreateSeller("Lucía");

        admin.SuspendSeller(seller);

        Assert.That(seller.Active, Is.False);


    }

    
}
    
