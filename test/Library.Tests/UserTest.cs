
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
        string testUserName = "manuel";

        Seller seller = new Seller("Juan", 0);
        seller.UserName = "Manuel";
        Assert.That(testUserName, Is.EqualTo(seller.UserName));
    }

    /// <summary>
    /// Verifica que se lance una excepción si no se ingresa un nombre de usuario
    /// </summary>
    
    [Test]
    public void SetUserName_Exception()
    {
        Assert.Throws<InvalidOperationException>(() => Is.EqualTo(new Seller("", 0)));
    }
    
    
    /// <summary>
    /// Verifica que se cierre una oportunidad y que sea añadida a la lista de oportunidades cerradas
    /// </summary>
    [Test]
    public void CloseOpportunityClosesAnOpportunityAndAddsToTheList()
    {
        Seller seller = new Seller("Juanito",0);
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com",

            "04/11/1999", seller);
        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.States.Open,client,DateTime.Now);
        seller.CloseOpportunity(opportunity);
        Assert.That(opportunity.State,Is.EqualTo(Opportunity.States.Close));

        Assert.That(seller.ClosedOpportunities.Count,Is.EqualTo(1));
    }
}