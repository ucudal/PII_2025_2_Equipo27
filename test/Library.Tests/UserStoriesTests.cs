using Library.interactions;

namespace Library.Tests;

public class UserStoriesTests
{
    [SetUp]
    public void SetUp()
    {
        SellerFacade.ResetInstance();
        AdminFacade.ResetInstance();
    }
    
    [Test]
    public void UserStory11Test()
    // Como usuario quiero registrar otros datos de los clientes como género y fecha de nacimiento de los clientes,
    // para realizar campañas y saludarlos en sus cumpleaños.
    {
        // Arrange
        Seller seller = new Seller("Kiki");
        SellerFacade.Instance.CreateClient("Antonie", "Griezmann", "Griezmann7@gmail.com", "123456789", Client.GenderType.Male, "21/03/1991", seller); 
        IReadOnlyList<Client> clients = SellerFacade.Instance.GetClients();
        // Act
        string actualClientBirthDate = clients[0].BirthDate;
        Client.GenderType actualClientGender = clients[0].Gender;
        // Assert
        Assert.That(actualClientBirthDate, Is.EqualTo("21/03/1991"));
        Assert.That(actualClientGender, Is.EqualTo(Client.GenderType.Male));
    }
    
    [Test]
    public void UserStory12Test()
    // Como usuario quiero poder definir etiquetas para poder organizar y segmentar a mis clientes.
    {
        Tag tag1 = SellerFacade.Instance.CreateTag("Compra milanesas");
        Tag tag2 = SellerFacade.Instance.CreateTag("Compra merengue");
        Tag tag3 = SellerFacade.Instance.CreateTag("Compra botines");
        
        Assert.That(SellerFacade.Instance.GetTags(), Does.Contain(tag1));
        Assert.That(SellerFacade.Instance.GetTags(), Does.Contain(tag2));
        Assert.That(SellerFacade.Instance.GetTags(), Does.Contain(tag3));
    }
    
    [Test]
    //Como usuario quiero poder agregar una etiqueta a un cliente, para luego organizar y segmentar mi
    //cartera de clientes.
    public void UserStory13Test()
    {
        // Arrange
        Seller seller = new Seller("Kiki");
        SellerFacade.Instance.CreateClient("Luka", "Modrić", "Modrić14@gmail.com", "123456789", Client.GenderType.Male, "09/09/1985", seller); 
        SellerFacade.Instance.CreateClient("Federico", "Valverde", "Fede8@gmail.com", "214365879", Client.GenderType.Male, "22/07/1998", seller);
        Tag tag1 = SellerFacade.Instance.CreateTag("Compra milanesas");
        Tag tag2 = SellerFacade.Instance.CreateTag("Compra merengue");
        Tag tag3 = SellerFacade.Instance.CreateTag("Compra botines");
        Client client1 = SellerFacade.Instance.SearchClientById(0);
        Client client2 = SellerFacade.Instance.SearchClientById(1);
        // Act
        SellerFacade.Instance.AddTag(client1, tag2);
        SellerFacade.Instance.AddTag(client1, tag3);
        SellerFacade.Instance.AddTag(client2, tag1);
        SellerFacade.Instance.AddTag(client2, tag2);
        // Assert
        Assert.That(client1.Tags, Does.Contain(tag2));
        Assert.That(client1.Tags, Does.Contain(tag3));
        Assert.That(client2.Tags, Does.Contain(tag1));
        Assert.That(client2.Tags, Does.Contain(tag2));
    }
    
    [Test]
    //Como usuario quiero poder registrar una venta a un cliente, incluyendo qué le vendí, cuándo se lo
    //vendí y cuánto le cobré, para saber lo que compran los clientes.
    public void UserStory14Test()
    {
        // Arrange
        Seller seller = new Seller("Kiki");
        Client elEdi = SellerFacade.Instance.CreateClient("Edinson", "Cavani", "Edi21@gmail.com", "099123456", Client.GenderType.Male, "14/02/1987", seller);
        // Act
        Opportunity opportunity = SellerFacade.Instance.CreateOpportunity("Mate", 450, Opportunity.States.Close, elEdi);
        // Assert
        Assert.That(elEdi.Opportunities, Does.Contain(opportunity));
    }
    
    [Test]
    // Como usuario quiero poder registrar que le envié una cotización a un cliente, cuándo se la 
    // mandé y por qué importe es la cotización, para hacer seguimiento de oportunidades de venta.
    public void UserStory15Test()
    {
        // Arrange
        Seller seller = new Seller("Kiki");
        Client virgil = SellerFacade.Instance.CreateClient("Virgil", "van Dijk", "Virg5@gmail.com", "099123556", Client.GenderType.Male, "08/07/1991", seller);
        // Act
        Opportunity opportunity = SellerFacade.Instance.CreateOpportunity("Pelota", 200, Opportunity.States.Open, virgil);
        // Assert
        Assert.That(virgil.Opportunities, Does.Contain(opportunity));
        Assert.That(opportunity.State,Is.EqualTo(Opportunity.States.Open));
    }
    
    [Test]
    // Como usuario quiero ver todas las interacciones de un cliente, con o sin filtro por
    // tipo de interacción y por fecha, para entender el historial de la relación comercial.
    public void UserStory16Test()
    {
        // Arrange
        Seller seller = new Seller("Kiki");
        Client harry = SellerFacade.Instance.CreateClient("Harry", "Kane", "Kane9@gmail.com", "099999999", Client.GenderType.Male, "28/07/1993", seller);
        SellerFacade.Instance.RegisterCall("Compra de botines", "Quiere comprar 3 pares", harry, DateTime.Today);
        SellerFacade.Instance.RegisterEmail("Organizando una llamada para hacer una compra", InteractionOrigin.Origin.Received, "Ninguna nota", harry, DateTime.Today);
        SellerFacade.Instance.RegisterMeeting("-", "Proximamente", "Munich", Meeting.MeetingState.Programmed, harry, DateTime.Today);
        SellerFacade.Instance.RegisterMessage("Saludo confirmando la reunion", "Ninguna", InteractionOrigin.Origin.Sent, "Discord", harry, DateTime.Now);
        // Act
        IReadOnlyList<Interaction> interactions = harry.Interactions;
        // Assert
        Assert.That(interactions.Count, Is.EqualTo(4));
    }
    
    [Test]
    public void UserStory17Test()
    //Como usuario quiero saber los clientes que hace cierto tiempo que no tengo ninguna interacción con ellos, para no peder contacto con ellos.
    {
        Seller user = new Seller("Carlos");
        Client client = new Client(0, "pedro", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", user);
        client.Inactive = true;
        
    }
}