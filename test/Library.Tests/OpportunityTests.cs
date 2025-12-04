namespace Library.Tests;

public class OpportunityTests
{
    [Test]
    public void OpportunityCreatesCorrectly()
    {
        Seller seller = new Seller("Juanito",0);
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321",  seller);

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
        Seller seller = new Seller("Juanito",0);
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321",  seller);

        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.States.Open,client,DateTime.Today);
        opportunity.Sell();
        Assert.That(opportunity.State,Is.EqualTo(Opportunity.States.Close));

    }


    [Test]
    public void SellThrowsIfAlreadyClosed()
    {
        Seller seller = new Seller("Juanito",0);
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321",  seller);

        Opportunity opportunity = new Opportunity("PS5", 500, Opportunity.States.Close, client, DateTime.Today);

        Assert.Throws<InvalidOperationException>(() => opportunity.Sell());
    }

    [Test]
    public void IsClosed_ReturnsTrueIfOpportunityIsClosed()
    {
        //Arrange
        Seller seller = new Seller("Pepe",0);
        Client client = new Client(0,"Juan", "Perez", "juan@gmail.com", "099999099", seller);
        Opportunity opportunity = new Opportunity("product", 4, Opportunity.States.Close,client);
        //Act
        bool actual = opportunity.IsClosed();
        bool expected = true;
        //Assert
        Assert.That(actual,Is.EqualTo(expected));
    }

    [Test]
    public void IsTheProduct_ReturnsTrueIfTheProductIsCorrect()
    {
        //Arrange
        Seller seller = new Seller("Pepe",0);
        Client client = new Client(0,"Juan", "Perez", "juan@gmail.com", "099999099", seller);
        Opportunity opportunity = new Opportunity("product", 4, Opportunity.States.Close,client);
        //Act
        bool actual = opportunity.IsTheProduct("product");
        bool expected = true;
        //Assert
        Assert.That(actual,Is.EqualTo(expected));
    }

}