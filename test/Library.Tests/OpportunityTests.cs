namespace Library.Tests;

public class OpportunityTests
{
    [Test]
    public void OpportunityCreatesCorrectly()
    {
        Seller seller = new Seller("Juanito");
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321", Client.GenderType.Male,
            "04/11/1999", seller);
        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.States.Open,client,DateTime.Today);
        Assert.That(opportunity.State,Is.EqualTo(Opportunity.States.Open));

        Assert.That(opportunity.Product,Is.EqualTo("PS5"));
        Assert.That(opportunity.Price,Is.EqualTo(500));
        Assert.That(opportunity.Client,Is.EqualTo(client));
        Assert.That(opportunity.Date,Is.EqualTo(DateTime.Today));
    }

    [Test]
    public void SellWorksCorrectly()
    {
        Seller seller = new Seller("Juanito");
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321", Client.GenderType.Male,
            "04/11/1999", seller);
        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.States.Open,client,DateTime.Today);
        opportunity.Sell();
        Assert.That(opportunity.State,Is.EqualTo(Opportunity.States.Close));

    }


    [Test]
    public void SellThrowsIfAlreadyClosed()
    {
        Seller seller = new Seller("Juanito");
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321", Client.GenderType.Male,
            "04/11/1999", seller);
        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.States.Close, client, DateTime.Today);

        Assert.Throws<InvalidOperationException>(() => opportunity.Sell());
    }

}