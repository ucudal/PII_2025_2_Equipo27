namespace Library.Tests;

public class OpportunityTests
{
    [Test]
    public void OpportunityCreatesCorrectly()
    {
        Seller seller = new Seller("Juanito");
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321", Client.GenderType.male,
            "04/11/1999", seller);
        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.State.Open,client,DateTime.Today);
        Assert.That(opportunity.OportunityState,Is.EqualTo(Opportunity.State.Open));
        Assert.That(opportunity.Product,Is.EqualTo("PS5"));
        Assert.That(opportunity.Price,Is.EqualTo(500));
        Assert.That(opportunity.Client,Is.EqualTo(client));
        Assert.That(opportunity.Date,Is.EqualTo(DateTime.Today));
    }

    [Test]
    public void SellWorksCorrectly()
    {
        Seller seller = new Seller("Juanito");
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321", Client.GenderType.male,
            "04/11/1999", seller);
        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.State.Open,client,DateTime.Today);
        opportunity.Sell();
        Assert.That(opportunity.OportunityState,Is.EqualTo(Opportunity.State.Close));
    }


    [Test]
    public void SellThrowsIfAlreadyClosed()
    {
        Seller seller = new Seller("Juanito");
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321", Client.GenderType.male,
            "04/11/1999", seller);
        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.State.Close, client, DateTime.Today);

        Assert.Throws<InvalidOperationException>(() => opportunity.Sell());
    }

}