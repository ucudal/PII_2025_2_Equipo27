using Library.interactions;

namespace Library.Tests;

public class UserStoriesTests
{
    [Test]
    public void UserStory17Test()
    //Como usuario quiero saber los clientes que hace cierto tiempo que no tengo ninguna interacción con ellos, para no peder contacto con ellos.
    {
        Seller user = new Seller("Carlos");
        Client client = new Client(0, "pedro", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", user);
        client.Inactive = true;
        
    }

    [Test]
    public void UserStory6Test()
    //Como usuario quiero registrar llamadas enviadas o recibidas de clientes, incluyendo cuándo fueron y de qué tema trataron, para saber mis interacciones
    {
        MainFacade main = new MainFacade();
        
        Client client = new Client(0, "Elías", "Núñez", "elias@gmail.com", "555555555", Client.GenderType.Male,
            "13/02/02", null);
        
        main.RegisterCall("Tema","nota",client,new DateTime(2025,11,05));
        main.RegisterCall("Llamada","nota",client, new DateTime(2025,11,10));
        
        Assert.That(client.Interactions.Count, Is.EqualTo(2));
        Assert.That(client.Interactions[0].Content, Is.EqualTo("Tema"));
        Assert.That(client.Interactions[1].Notes, Is.EqualTo("nota"));
        
    }

    [Test]
    public void UserStory7Test()
        //Como usuario quiero registrar reuniones con los clientes, incluyendo cuándo y dónde fueron, y de qué tema trataron, para poder saber mis interacciones.
    {
        MainFacade main = new MainFacade();

        Client client = new Client(0, "Elías", "Núñez", "elias@gmail.com", "555555555", Client.GenderType.Male,
            "13/02/02", null);

        main.RegisterMeeting("Contenido", "nota", "Uruguay", Meeting.MeetingState.Done, client,
            new DateTime(2025, 11, 07));

        Assert.That(client.Interactions.Count, Is.EqualTo(1));
        Assert.That(client.Interactions[0].Content, Is.EqualTo("Contenido"));
        Assert.That(client.Interactions[0].Notes, Is.EqualTo("nota"));
        
    }

    [Test]
    public void UserStory8Test()
    //Como usuario quiero registrar mensajes enviados a o recibidos de los clientes, incluyendo cuándo y dónde fueron, y de qué tema trataron, para saber mis interacciones.
    {
        MainFacade main = new MainFacade();

        Client client = new Client(0, "Elías", "Núñez", "elias@gmail.com", "555555555", Client.GenderType.Male,
            "13/02/02", null);
        
        main.RegisterMessage("Mensaje","nota", InteractionOrigin.Origin.Received, "Whatsapp", client, new DateTime(2025,11,09));
        main.RegisterMessage("Mensaje","nota", InteractionOrigin.Origin.Sent, "Whatsapp", client, new DateTime(2025,11,09));
        
        Assert.That(client.Interactions.Count, Is.EqualTo(2));
        Assert.That(client.Interactions[0].Content, Is.EqualTo("Mensaje"));
        Assert.That(client.Interactions[1].Notes, Is.EqualTo("nota"));
        
    }
    
    [Test]
    public void UserStory9Test()
    //Como usuario quiero registrar correos electrónicos enviados a o recibidos, incluyendo cuándo y dónde fueron, y de qué tema trataron, para saber mis interacciones.
    {
        MainFacade main = new MainFacade();

        Client client = new Client(0, "Elías", "Núñez", "elias@gmail.com", "555555555", Client.GenderType.Male,
            "13/02/02", null);
        
        main.RegisterEmail("Correo electrónico", InteractionOrigin.Origin.Received, "notas", client, new DateTime(2025,10,31));
        main.RegisterEmail("Correo electrónico", InteractionOrigin.Origin.Sent, "notas", client, new DateTime(2025,11,01));
        
        Assert.That(client.Interactions.Count, Is.EqualTo(2));
        Assert.That(client.Interactions[0].Content, Is.EqualTo("Correo electrónico"));
        Assert.That(client.Interactions[1].Notes, Is.EqualTo("notas"));
    }
    
    [Test]
    public void UserStory10Test()
    //Como usuario quiero agregar notas o comentarios a las llamadas, reuniones, mensajes y correos enviados o recibidos de los clientes, para tener información adicional de mis interacciones con los clientes.
    {
        MainFacade main = new MainFacade();

        Client client = new Client(0, "Elías", "Núñez", "elias@gmail.com", "555555555", Client.GenderType.Male,
            "13/02/02", null);

        main.RegisterEmail("Correo electrónico", InteractionOrigin.Origin.Received, "", client,
            new DateTime(2025, 10, 25));
        
        main.AddNotes(client.Interactions[0], "Nueva nota");

        Assert.That(client.Interactions[0].Notes, Is.EqualTo("Nueva nota"));
    }
}