
using Library.interactions;

namespace Library.Tests;


public class UserTest
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void CloseOpportunityClosesAnOpportunityAndAddsToTheList()
    {
        Seller seller = new Seller("Juanito");
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321", Client.GenderType.male,
            "04/11/1999", seller);
        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.States.Open,client,DateTime.Now);
        seller.CloseOpportunity(opportunity);
        Assert.That(opportunity.State,Is.EqualTo(Opportunity.States.Close));
        Assert.That(seller.ClosedOpportunities.Count,Is.EqualTo(1));
    }
}