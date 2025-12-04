using System.Runtime.InteropServices.JavaScript;

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

    // Tests Desfensa Historia 1
    
    [Test]
    public void HigherThanSell_ReturnsTrue()
    {
        // Arrange
        Seller seller = new Seller("Juanito",0);
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321",  seller);
        Opportunity opportunity = new Opportunity("Mate", 25, Opportunity.States.Close, client, DateTime.Now);
        bool expected = true;
        // Act
        bool actual = opportunity.HigherThanSell(10);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void HigherThanSell_ReturnsFalse_WhenAmountIsHigher()
    {
        // Arrange
        Seller seller = new Seller("Juanito",0);
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321",  seller);
        Opportunity opportunity = new Opportunity("Moto", 750, Opportunity.States.Open, client, DateTime.Now);
        bool expected = false;
        // Act
        bool actual = opportunity.HigherThanSell(1000);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void HigherThanSell_ReturnsTrue_WhenStateIsOpen()
    {
        // Arrange
        Seller seller = new Seller("Juanito",0);
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321",  seller);
        Opportunity opportunity = new Opportunity("Mate", 25, Opportunity.States.Open, client, DateTime.Now);
        bool expected = false;
        // Act
        bool actual = opportunity.HigherThanSell(10);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void HigherThanSell_ReturnsFalse_WhenStateIsCanceled()
    {
        // Arrange
        Seller seller = new Seller("Juanito",0);
        Client client = new Client(0, "Pedro", "Sanchez", "pedrosanchez@gmail.com", "099999321",  seller);
        Opportunity opportunity = new Opportunity("Moto", 750, Opportunity.States.Canceled, client, DateTime.Now);
        bool expected = false;
        // Act
        bool actual = opportunity.HigherThanSell(500);
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}