using Library.interactions;

namespace Library.Tests;

public class UserStoriesTests
{
    [Test]
    public void UserStory1Test()
    {
        // Crear un nuevo cliente con su información básica (nombre, apellido, teléfono y correo electrónico) para poder contactarme con ellos.
        Seller seller = new Seller("Carlos");
        Client client = new Client(0, "pedro", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", seller);
        
        
        Assert.That(client, Is.Not.Null);
        Assert.That(client.Name, Is.EqualTo("pedro"));
        Assert.That(client.LastName, Is.EqualTo("Sanchez"));
        Assert.That(client.Email, Is.EqualTo("pedro@gmail.com"));
        Assert.That(client.Phone, Is.EqualTo("099000111"));
        Assert.That(client.Gender, Is.EqualTo(Client.GenderType.Male));
        Assert.That(client.BirthDate, Is.EqualTo("10/05/1999"));
        Assert.That(client.AsignedSeller, Is.EqualTo(seller));
    }[Test]
    public void UserStory2Test()
    {
        SellerFacade facade = SellerFacade.Instance;

        // Modificar la información de un cliente existente para mantenerla actualizada.
        Seller seller = new Seller("Carlos");
        Client client = new Client(0, "Pedra", "Sanchez", "pedra@gmail.com", "099000111", Client.GenderType.Female,
            "10/05/1999", seller);

        facade.ModifyClient(client, Client.TypeOfData.Name, "Guillermo");
        facade.ModifyClient(client, Client.TypeOfData.LastName, "Diaz");
        facade.ModifyClient(client, Client.TypeOfData.Email, "willy@gmail.com");
        facade.ModifyClient(client, Client.TypeOfData.Phone, "097888999");
        
        
        Assert.That(client, Is.Not.Null);
        Assert.That(client.Name, Is.EqualTo("Guillermo"));
        Assert.That(client.LastName, Is.EqualTo("Diaz"));
        Assert.That(client.Email, Is.EqualTo("willy@gmail.com"));
        Assert.That(client.Phone, Is.EqualTo("097888999"));
    }
    
    [Test]
    public void UserStory3Test()
    //Eliminar un cliente para mantener limpia la base de datos.
    {
        SellerFacade facade = SellerFacade.Instance;
        Seller user = new Seller("Carlos");
        facade.CreateClient("Omar", "Gonzalez", "omar@gmail.com", "097654645", Client.GenderType.Male,
            "01/12/1969", user);
        facade.CreateClient("pedro", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", user);

        facade.DeleteClient(facade.GetClients()[0].Id);

        Assert.That(facade.GetClients().Count, Is.EqualTo(1));
        Assert.That(facade.GetClients()[0].Name, Is.EqualTo("pedro"));
    }
    
    
    [Test]
    public void UserStory4Test()
    //Buscar clientes por nombre, apellido, teléfono o correo para identificarlos rápidamente.
    {
        SellerFacade facade = SellerFacade.Instance;
        Seller user = new Seller("Carlos");
        facade.CreateClient("Omar", "Gonzalez", "omar@gmail.com", "097654645", Client.GenderType.Male,
            "01/12/1969", user);
        facade.CreateClient("pedro", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", user);
        facade.CreateClient("Sandra", "Lopez", "sandra@gmail.com", "095456321", Client.GenderType.Female,
            "19/03/2004", user);

        List<Client> busqueda1 =  facade.SearchClient(RepoClients.TypeOfData.Name,"pedro");
        List<Client> busqueda2 =  facade.SearchClient(RepoClients.TypeOfData.LastName,"Sanchez");
        List<Client> busqueda3 =  facade.SearchClient(RepoClients.TypeOfData.Email,"pedro@gmail.com");
        List<Client> busqueda4 =  facade.SearchClient(RepoClients.TypeOfData.Phone,"099000111");

        List<Client> expected = new List<Client>();
        
        expected.Add(facade.GetClients()[1]);
        
        Assert.That( busqueda1, Is.EqualTo(expected));
        Assert.That( busqueda2, Is.EqualTo(expected));
        Assert.That( busqueda3, Is.EqualTo(expected));
        Assert.That( busqueda4, Is.EqualTo(expected));
    }
    
    [Test]
    public void UserStory5Test()
    // Ver una lista de todos mis clientes para tener una vista general de mi cartera.
    {
        SellerFacade facade = SellerFacade.Instance;
        Seller user = new Seller("Carlos");
        facade.CreateClient("Omar", "Gonzalez", "omar@gmail.com", "097654645", Client.GenderType.Male,
            "01/12/1969", user);
        facade.CreateClient("pedro", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", user);
        facade.CreateClient("Sandra", "Lopez", "sandra@gmail.com", "095456321", Client.GenderType.Female,
            "19/03/2004", user);
        
        
        Assert.That(facade.GetClients().Count, Is.EqualTo(3));
        Assert.That(facade.GetClients()[1].Name, Is.EqualTo("pedro"));
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