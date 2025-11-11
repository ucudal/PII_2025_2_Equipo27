
using Library.interactions;

namespace Library.Tests;


public class UserTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SetUserName_Valid()
    {
        Seller seller = new Seller("Juan");
        seller.UserName = "Manuel";
        Assert.That("Manuel", Is.EqualTo(seller.UserName));
    }

    /// <summary>
    /// Verifica que se lance una excepción si no se ingresa un nombre de usuario
    /// </summary>
    
    [Test]
    public void SetUserName_Exception()
    {
        Assert.Throws<ArgumentException>(() => Is.EqualTo(new Seller("")));
    }
    
    
    /// <summary>
    /// Verifica que se cierre una oportunidad y que sea añadida a la lista de oportunidades cerradas
    /// </summary>
    [Test]
    public void CloseOpportunityClosesAnOpportunityAndAddsToTheList()
    {
        Seller seller = new Seller("Juanito");
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321", Client.GenderType.Male,
            "04/11/1999", seller);
        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.States.Open,client,DateTime.Now);
        seller.CloseOpportunity(opportunity);
        Assert.That(opportunity.State,Is.EqualTo(Opportunity.States.Close));

        Assert.That(seller.ClosedOpportunities.Count,Is.EqualTo(1));
    }
}