using Library.interactions;
namespace Library.Tests;

public class MainFacadeTests
{
    [Test]
    public void ModifyOportunityWorksCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.ModifyClient(client, Client.TypeOfData.LastName, "Gutierrez");
        Assert.That(client.LastName,Is.EqualTo("Gutierrez"));
    }
    [Test]
    public void CreateOportunityWorksCorrectly()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        MainFacade mainFacade = new MainFacade();
        mainFacade.ModifyClient(client, Client.TypeOfData.LastName, "Gutierrez");
        mainFacade.CreateOportunity("Product", 100 , Opportunity.State.Open, client);
        Assert.That(client.Oportunities.Count,Is.EqualTo(1));
    }
    [Test]
    public void AddTagAddsATag()
    {
        Seller seller = new Seller("Seller");
        Client client = new Client("Juan24", "Juan", "Perez", "juanperez@gmail.com", "099888222", Client.GenderType.male,"09/10/08", seller);
        Tag tag = new Tag("Electrodomesticos");
        MainFacade mainFacade = new MainFacade();
        mainFacade.ModifyClient(client, Client.TypeOfData.LastName, "Gutierrez");
        mainFacade.AddTag(client,tag);
        Assert.That(client.Tags.Count,Is.EqualTo(1));
        Assert.That(client.Tags[0], Is.EqualTo(tag));
    }
}
