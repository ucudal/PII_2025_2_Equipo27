namespace Library.Tests;

public class UserStorieDefensaTest
{
    [SetUp]
    public void SetUp()
    {
        SellerFacade.ResetInstance();
        AdminFacade.ResetInstance();
        RepoClients.ResetInstance();
        RepoUsers.ResetInstance();
    }
    
    [Test]
    public void UserStoryTestAssert()
    {
        // como usuario quiero ver los clientes con ventas dentro de un cierto rango de montos
        
        // Arrange
        Seller seller = AdminFacade.Instance.CreateSeller("Kiki");
        
        // !newclient nombre, apellido, mail@mail.com, telefono, ideSeller ==> ClientId: n
        Client virgil = SellerFacade.Instance.CreateClient("Virgil", "van Dijk", "Virg5@gmail.com", "099123556",  seller.Id.ToString());
        Client argen = SellerFacade.Instance.CreateClient("argen", "roben", "aroben@gmail.com", "099655452",  seller.Id.ToString());
        Client iker = SellerFacade.Instance.CreateClient("iker", "casillas", "iker@gmail.com", "096455445",  seller.Id.ToString());
        
        // Act 
        // !newopportunity producto, precio, estado, id del cliente
        SellerFacade.Instance.CreateOpportunity("Pelota", "200", "Open", virgil.Id.ToString());
        SellerFacade.Instance.CreateOpportunity("guantes", "600", "Close", virgil.Id.ToString());
        
        SellerFacade.Instance.CreateOpportunity("canilleras", "300", "Close", argen.Id.ToString());
        SellerFacade.Instance.CreateOpportunity("gorro", "150", "Close", argen.Id.ToString());
        
        SellerFacade.Instance.CreateOpportunity("lentes", "350", "Close", iker.Id.ToString());
        SellerFacade.Instance.CreateOpportunity("guantes de arquero", "500", "Open", iker.Id.ToString());

        List<Client> assertResponse =  new List<Client>();
        assertResponse.Add(argen);
        assertResponse.Add(iker);
        
        IReadOnlyList<Client> response = SellerFacade.Instance.SearchClientsWithSalesBetweenParameters("300", "500");
        
        
        // Assert
        Assert.That(response[0].Name, Is.EqualTo(assertResponse[0].Name));
        Assert.That(response[1].Name, Is.EqualTo(assertResponse[1].Name));
        Assert.That(response.Count, Is.EqualTo(assertResponse.Count));
    }
    
    [Test]
    public void UserStoryTestEmpty()
    {
        // si ningun cliente tiene ventas dentro del monto me retorna el error correspondiente
        
        // Arrange
        Seller seller = AdminFacade.Instance.CreateSeller("Kiki");
        
        // !newclient nombre, apellido, mail@mail.com, telefono, ideSeller ==> ClientId: n
        Client virgil = SellerFacade.Instance.CreateClient("Virgil", "van Dijk", "Virg5@gmail.com", "099123556",  seller.Id.ToString());
        Client argen = SellerFacade.Instance.CreateClient("argen", "roben", "aroben@gmail.com", "099655452",  seller.Id.ToString());
        Client iker = SellerFacade.Instance.CreateClient("iker", "casillas", "iker@gmail.com", "096455445",  seller.Id.ToString());
        
        // Act 
        // !newopportunity producto, precio, estado, id del cliente
        SellerFacade.Instance.CreateOpportunity("Pelota", "200", "Open", virgil.Id.ToString());
        SellerFacade.Instance.CreateOpportunity("guantes", "600", "Close", virgil.Id.ToString());
        
        SellerFacade.Instance.CreateOpportunity("canilleras", "300", "Close", argen.Id.ToString());
        SellerFacade.Instance.CreateOpportunity("gorro", "150", "Open", argen.Id.ToString());
        
        SellerFacade.Instance.CreateOpportunity("lentes", "350", "Close", iker.Id.ToString());
        SellerFacade.Instance.CreateOpportunity("guantes de arquero", "500", "Open", iker.Id.ToString());

        string errorMessage = "No existe hay clientes en ese rango";
        // Assert 
        var response =
            Assert.Throws<ArgumentException>(() =>
                SellerFacade.Instance.SearchClientsWithSalesBetweenParameters("400", "500"));
        Assert.That(response.Message, Does.Contain(errorMessage));
        
    }
    
    [Test]
    public void UserStoryTestMinMoreThanMax()
    {
        // si ingreso un parametro minimo mayor al maximo me retorna el error correspondiente
        
        string errorMessage = "El valor minimo no puede ser superior al valor maximo.";

        // Assert 
        var response =
            Assert.Throws<ArgumentException>(() =>
                SellerFacade.Instance.SearchClientsWithSalesBetweenParameters("500", "400"));
        Assert.That(response.Message, Does.Contain(errorMessage));
        
    }
}