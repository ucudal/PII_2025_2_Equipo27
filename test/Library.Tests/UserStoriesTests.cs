using Library.interactions;

namespace Library.Tests;

public class UserStoriesTests
{
    [SetUp]
    public void SetUp()
    {
        SellerFacade.ResetInstance();
        AdminFacade.ResetInstance();
        RepoClients.ResetInstance();
        RepoUsers.ResetInstance();
        RepoTags.ResetInstance();
    }
    
    [Test]
    public void UserStory1Test()
    {
        // Crear un nuevo cliente con su información básica (nombre, apellido, teléfono y correo electrónico) para poder contactarme con ellos.
        RepoUsers users = RepoUsers.Instance;
        Seller seller = users.CreateSeller("carlos");
        Client client = new Client(0, "pedro", "Sanchez", "pedro@gmail.com", 
            "099000111", seller);

        Assert.That(client, Is.Not.Null);
        Assert.That(client.Name, Is.EqualTo("pedro"));
        Assert.That(client.LastName, Is.EqualTo("Sanchez"));
        Assert.That(client.Email, Is.EqualTo("pedro@gmail.com"));
        Assert.That(client.Phone, Is.EqualTo("099000111"));
        Assert.That(client.AsignedSeller, Is.EqualTo(seller));
    }
    [Test]
    public void UserStory2Test()
    {
        SellerFacade facade = SellerFacade.Instance;

        // Modificar la información de un cliente existente para mantenerla actualizada.
        Seller seller = AdminFacade.Instance.CreateSeller("Carlos");
        Client client = facade.CreateClient("Pedra", "Sanchez", "pedra@gmail.com", "099000111", "0");
        
        
        facade.ModifyClient("0", "Name", "Guillermo");
        facade.ModifyClient("0", "LastName", "Diaz");
        facade.ModifyClient("0", "Email", "willy@gmail.com");
        facade.ModifyClient("0", "Phone", "097888999");
        
        
        Assert.That(client, Is.Not.Null);
        Assert.That(client.Name, Is.EqualTo("guillermo"));
        Assert.That(client.LastName, Is.EqualTo("diaz"));
        Assert.That(client.Email, Is.EqualTo("willy@gmail.com"));
        Assert.That(client.Phone, Is.EqualTo("097888999"));
    }
    
    
    [Test]
    public void UserStory3Test()
    //Eliminar un cliente para mantener limpia la base de datos.
    {
        SellerFacade facade = SellerFacade.Instance;
        Seller user = AdminFacade.Instance.CreateSeller("Carlos");
        facade.CreateClient("Omar", "Gonzalez", "omar@gmail.com", "097654645",  "0");
        facade.CreateClient("pedro", "Sanchez", "pedro@gmail.com", "099000111",  "0");
        
        facade.DeleteClient(facade.GetClients()[0].Id.ToString());
        
        Assert.That(facade.GetClients().Count, Is.EqualTo(1));
        Assert.That(facade.GetClients()[0].Name, Is.EqualTo("pedro"));
    }
    
    
    [Test]
    public void UserStory4Test()
    //Buscar clientes por nombre, apellido, teléfono o correo para identificarlos rápidamente.
    {
        SellerFacade facade = SellerFacade.Instance;
        Seller user = AdminFacade.Instance.CreateSeller("Carlos");
        facade.CreateClient("Omar", "Gonzalez", "omar@gmail.com", "097654645",  "0");
        facade.CreateClient("pedro", "Sanchez", "pedro@gmail.com", "099000111",  "0");
        facade.CreateClient("Sandra", "Lopez", "sandra@gmail.com", "095456321",  "0");



        List<Client> busqueda1 =  facade.SearchClient("Name","pedro");
        List<Client> busqueda2 =  facade.SearchClient("LastName","Sanchez");
        List<Client> busqueda3 =  facade.SearchClient("Email","pedro@gmail.com");
        List<Client> busqueda4 =  facade.SearchClient("Phone","099000111");

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
        Seller user = AdminFacade.Instance.CreateSeller("Carlos");
        facade.CreateClient("Omar", "Gonzalez", "omar@gmail.com", "097654645",  "0");
        facade.CreateClient("pedro", "Sanchez", "pedro@gmail.com", "099000111",  "0");
        facade.CreateClient("Sandra", "Lopez", "sandra@gmail.com", "095456321",  "0");

        
        
        Assert.That(facade.GetClients().Count, Is.EqualTo(3));
        Assert.That(facade.GetClients()[1].Name, Is.EqualTo("pedro"));
    }
    
[Test]
    public void UserStory6Test()
    //Como usuario quiero registrar llamadas enviadas o recibidas de clientes, incluyendo cuándo fueron y de qué tema trataron, para saber mis interacciones
    {
        Seller user = AdminFacade.Instance.CreateSeller("Carlos");

        Client client = AdminFacade.Instance.CreateClient( "Elías", "Núñez", "elias@gmail.com", "555555555",  "0");
        
        AdminFacade.Instance.RegisterCall("Tema","Sent", "nota",client.Id.ToString());
        AdminFacade.Instance.RegisterCall("Llamada","Sent", "nota",client.Id.ToString());
        
        Assert.That(client.Interactions.Count, Is.EqualTo(2));
        Assert.That(client.Interactions[0].Content, Is.EqualTo("Tema"));
        Assert.That(client.Interactions[1].Notes, Is.EqualTo("nota"));
        
    }

    [Test]
    public void UserStory7Test()
        //Como usuario quiero registrar reuniones con los clientes, incluyendo cuándo y dónde fueron, y de qué tema trataron, para poder saber mis interacciones.
    {
        Seller user = AdminFacade.Instance.CreateSeller("Carlos");

        Client client = AdminFacade.Instance.CreateClient( "Elías", "Núñez", "elias@gmail.com", "555555555",  "0");

        AdminFacade.Instance.RegisterMeeting("Contenido", "nota", "Uruguay", "Done", client.Id.ToString(),
            "07/11/2025");

        Assert.That(client.Interactions.Count, Is.EqualTo(1));
        Assert.That(client.Interactions[0].Content, Is.EqualTo("Contenido"));
        Assert.That(client.Interactions[0].Notes, Is.EqualTo("nota"));
        
    }

    [Test]
    public void UserStory8Test()
    //Como usuario quiero registrar mensajes enviados a o recibidos de los clientes, incluyendo cuándo y dónde fueron, y de qué tema trataron, para saber mis interacciones.
    {
        Seller user = AdminFacade.Instance.CreateSeller("Carlos");

        Client client = AdminFacade.Instance.CreateClient( "Elías", "Núñez", "elias@gmail.com", "555555555",  "0");

        AdminFacade.Instance.RegisterMessage("Mensaje","nota1", "Received", "Whatsapp", client.Id.ToString());
        AdminFacade.Instance.RegisterMessage("Mensaje","nota2", "Sent", "Whatsapp", client.Id.ToString());
        
        Assert.That(client.Interactions.Count, Is.EqualTo(2));
        Assert.That(client.Interactions[0].Content, Is.EqualTo("Mensaje"));
        Assert.That(client.Interactions[1].Notes, Is.EqualTo("nota2"));
        
    }
    
    [Test]
    public void UserStory9Test()
    //Como usuario quiero registrar correos electrónicos enviados a o recibidos, incluyendo cuándo y dónde fueron, y de qué tema trataron, para saber mis interacciones.
    {
        Seller user = AdminFacade.Instance.CreateSeller("Carlos");

        Client client = AdminFacade.Instance.CreateClient( "Elías", "Núñez", "elias@gmail.com", "555555555",  "0");

        AdminFacade.Instance.RegisterEmail("Correo electrónico", "Received", "notas1", client.Id.ToString());
        AdminFacade.Instance.RegisterEmail("Correo electrónico", "Sent", "notas2", client.Id.ToString());
        
        Assert.That(client.Interactions.Count, Is.EqualTo(2));
        Assert.That(client.Interactions[0].Content, Is.EqualTo("Correo electrónico"));
        Assert.That(client.Interactions[1].Notes, Is.EqualTo("notas2"));
    }
    
    [Test]
    public void UserStory10Test()
    //Como usuario quiero agregar notas o comentarios a las llamadas, reuniones, mensajes y correos enviados o recibidos de los clientes, para tener información adicional de mis interacciones con los clientes.
    {
        Seller seller = AdminFacade.Instance.CreateSeller("pepe");
        Client client = AdminFacade.Instance.CreateClient( "Elías", "Núñez", "elias@gmail.com", "555555555", "0");

        AdminFacade.Instance.RegisterEmail("Correo electrónico", "Received", "", client.Id.ToString());
        
        AdminFacade.Instance.AddNotes(client.Interactions[0].Id.ToString(), "Nueva nota",client.Id.ToString());

        Assert.That(client.Interactions[0].Notes, Is.EqualTo("Nueva nota"));
    }
    
    [Test]
    public void UserStory11Test()
    // Como usuario quiero registrar otros datos de los clientes como género y fecha de nacimiento de los clientes,
    // para realizar campañas y saludarlos en sus cumpleaños.
    {
        // Arrange
        Seller seller = AdminFacade.Instance.CreateSeller("Kiki");
        SellerFacade.Instance.CreateClient("Antonie", "Griezmann", "Griezmann7@gmail.com", "123456789",  "0"); 
        IReadOnlyList<Client> clients = SellerFacade.Instance.GetClients();
        // Act
        SellerFacade.Instance.AddData("0", "Gender", "Male");
        SellerFacade.Instance.AddData("0", "BirthDate", "21/03/1991");
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
        Seller seller = AdminFacade.Instance.CreateSeller("Kiki");
        string tagName1 = "Compra milanesas";
        string tagName2 = "Compra merengue";
        string tagName3 = "Compra botines";
        SellerFacade.Instance.CreateClient("Luka", "Modrić", "Modrić14@gmail.com", "123456789",  "0"); 
        SellerFacade.Instance.CreateClient("Federico", "Valverde", "Fede8@gmail.com", "214365879",  "0");
        Tag tag1 = SellerFacade.Instance.CreateTag(tagName1);
        Tag tag2 = SellerFacade.Instance.CreateTag(tagName2);
        Tag tag3 = SellerFacade.Instance.CreateTag(tagName3);
        Client client1 = SellerFacade.Instance.SearchClientById("0");
        Client client2 = SellerFacade.Instance.SearchClientById("1");
        // Act
        SellerFacade.Instance.AddTag(client1.Id.ToString(), tagName2);
        SellerFacade.Instance.AddTag(client1.Id.ToString(), tagName3);
        SellerFacade.Instance.AddTag(client2.Id.ToString(), tagName1);
        SellerFacade.Instance.AddTag(client2.Id.ToString(), tagName2);
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
        Seller seller = AdminFacade.Instance.CreateSeller("Kiki");
        Client elEdi = SellerFacade.Instance.CreateClient("Edinson", "Cavani", "Edi21@gmail.com", "099123456",  "0");
        // Act
        Opportunity opportunity = SellerFacade.Instance.CreateOpportunity("Mate", "450", "Close", elEdi.Id.ToString());
        // Assert
        Assert.That(elEdi.Opportunities, Does.Contain(opportunity));
    }
    
    [Test]
    // Como usuario quiero poder registrar que le envié una cotización a un cliente, cuándo se la 
    // mandé y por qué importe es la cotización, para hacer seguimiento de oportunidades de venta.
    public void UserStory15Test()
    {
        // Arrange
        Seller seller = AdminFacade.Instance.CreateSeller("Kiki");
        Client virgil = SellerFacade.Instance.CreateClient("Virgil", "van Dijk", "Virg5@gmail.com", "099123556",  "0");
        // Act
        Opportunity opportunity = SellerFacade.Instance.CreateOpportunity("Pelota", "200", "Open", virgil.Id.ToString());
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
        Seller seller = AdminFacade.Instance.CreateSeller("Kiki");
        Client harry = SellerFacade.Instance.CreateClient("Harry", "Kane", "Kane9@gmail.com", "099999999",  "0");


        SellerFacade.Instance.RegisterCall("Compra de botines", "Sent","Quiere comprar 3 pares", harry.Id.ToString());
        SellerFacade.Instance.RegisterEmail("Organizando una llamada para hacer una compra", "Received", "Ninguna nota", harry.Id.ToString());
        SellerFacade.Instance.RegisterMeeting("-", "Proximamente", "Munich", "Programmed", harry.Id.ToString(), DateTime.Today.ToString());
        SellerFacade.Instance.RegisterMessage("Saludo confirmando la reunion", "Ninguna", "Sent", "Discord", harry.Id.ToString());
        // Act
        IReadOnlyList<Interaction> interactions = harry.Interactions;
        // Assert
        Assert.That(interactions.Count, Is.EqualTo(4));
    }
    
    [Test]
    public void UserStory17Test()
    //Como usuario quiero saber los clientes que hace cierto tiempo que no tengo ninguna interacción con ellos, para no peder contacto con ellos.
    {
        Seller user = AdminFacade.Instance.CreateSeller("Carlos");
        SellerFacade facade = SellerFacade.Instance;
        facade.CreateClient("pedro", "Sanchez", "pedro@gmail.com", "099000111",  "0");
        
        facade.SwitchClientActivity("0");
        int actual = facade.InactiveClients().Count;
        Assert.That(actual,Is.EqualTo(1));
    }

    [Test]
    public void UserStory18Test()
    //Como usuario quiero saber los clientes que se pusieron en contacto conmigo y no les contesté hace cierto tiempo, para no dejar de responder mensajes o llamadas.
    {
        Seller user = AdminFacade.Instance.CreateSeller("Carlos");
        SellerFacade facade = SellerFacade.Instance;
        facade.CreateClient("pedro", "Sanchez", "pedro@gmail.com", "099000111",  "0");

        facade.RegisterCall("hola","Sent","llamada","0");
        int actual = facade.WaitingClients().Count;
        Assert.That(actual,Is.EqualTo(1));
    }

    [Test]
    public void UserStory19Test()
    //Como administrador quiero crear, suspender o eliminar usuarios, para mantener control sobre los accesos.
    {
        AdminFacade facade = AdminFacade.Instance;
        facade.CreateSeller("Carlos");
        IReadOnlyList<User> sellers = facade.GetUsers();
        int actual1 = sellers.Count;
        facade.SuspendUser("0");
        IReadOnlyList<User> suspendedUsers = facade.GetSuspendedUsers();
        int actual2 = suspendedUsers.Count;
        facade.DeleteUser("0");
        int actual3 = sellers.Count;
        Assert.That(actual1,Is.EqualTo(1));
        Assert.That(actual2,Is.EqualTo(1));
        Assert.That(actual3,Is.EqualTo(0));
    }

    [Test]
    public void UserStory20Test()
    //Como vendedor, quiero poder asignar un cliente a otro vendedor para distribuir el trabajo en el equipo.
    {
        AdminFacade adminFacade = AdminFacade.Instance;
        adminFacade.CreateSeller("Pedro");
        adminFacade.CreateSeller("Juan");
        
        adminFacade.CreateClient("Jose", "Sanchez", "pedro@gmail.com", "099000111",  "0");
       
        SellerFacade.Instance.AssignClient("0", "1", "0");
        Assert.That(adminFacade.SearchClient("Name","jose")[0].AsignedSeller,Is.EqualTo(AdminFacade.Instance.SearchUser<Seller>("1")));
    }

    [Test]
    public void UserStory21Test()
    //Como usuario quiero saber el total de ventas de un periodo dado, para analizar en rendimiento de mi negocio.
    {
        AdminFacade facade = AdminFacade.Instance;
        facade.CreateSeller("Juan");
        facade.CreateClient("Jose", "Sanchez", "pedro@gmail.com", "099000111", "0");
        facade.CreateOpportunity("Harina","50","Open","0");
        facade.Admin.CloseOpportunity(facade.SearchClient("Name","Jose")[0].Opportunities[0]);
        int actual = facade.Admin.ClosedOpportunities.Count;

        Assert.That(actual,Is.EqualTo(1));
    }

    [Test]
    public void UserStory22Test()
    //Como usuario quiero ver un panel con clientes totales, interacciones recientes y reuniones próximas, para tener un resumen rápido.
    {
        AdminFacade facade = AdminFacade.Instance;
        facade.CreateSeller("mario");
        facade.CreateClient("Ezequiel", "Pastorino", "eze@example.com", "099999999",  "0");
        facade.CreateClient("Lucía", "García", "lucia@example.com", "098888888",  "0");
        facade.RegisterCall("Llamada 1", "Sent","Notas 1", "0");
        facade.RegisterMeeting("Reunión 1", "Notas 2", "Sala A","Programmed" ,"0" ,DateTime.Now.AddDays(1).ToString());
        facade.RegisterEmail("Email 1", "Sent", "Notas","0");

        string expected = 
            $"Clientes totales: 2\n" +
            $"Interacciones en este último mes: 2\n" +
            $"Reuniones próximas 1";
        string actual = facade.GetPanel();
        Assert.That(actual,Is.EqualTo(expected));
    }
}