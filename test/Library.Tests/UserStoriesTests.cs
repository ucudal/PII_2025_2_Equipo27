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
    public void UserStory17Test()
    //Como usuario quiero saber los clientes que hace cierto tiempo que no tengo ninguna interacción con ellos, para no peder contacto con ellos.
    {
        Seller user = new Seller("Carlos");
        SellerFacade facade = SellerFacade.Instance;
        facade.CreateClient("pedro", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", user);
        facade.SwitchClientActivity(0);
        int actual = facade.InactiveClients().Count;
        Assert.That(actual,Is.EqualTo(1));
    }

    [Test]
    public void UserStory18Test()
    //Como usuario quiero saber los clientes que se pusieron en contacto conmigo y no les contesté hace cierto tiempo, para no dejar de responder mensajes o llamadas.
    {
        Seller user = new Seller("Carlos");
        SellerFacade facade = SellerFacade.Instance;
        facade.CreateClient("pedro", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", user);
        facade.SwitchClientWaiting(0);
        int actual = facade.WaitingClients().Count;
        Assert.That(actual,Is.EqualTo(1));
    }

    [Test]
    public void UserStory19Test()
    //Como administrador quiero crear, suspender o eliminar usuarios, para mantener control sobre los accesos.
    {
        Seller user = new Seller("Carlos");
        AdminFacade facade = AdminFacade.Instance;
        facade.CreateSeller("Carlos");
        int actual1 = facade.admin.sellers.Count;
        facade.SuspendSeller("Carlos");
        int actual2 = facade.admin.SuspendedSellers.Count;
        facade.DeleteSeller("Carlos");
        int actual3 = facade.admin.sellers.Count;
        Assert.That(actual1,Is.EqualTo(1));
        Assert.That(actual2,Is.EqualTo(1));
        Assert.That(actual3,Is.EqualTo(0));
    }

    [Test]
    public void UserStory20Test()
    //Como vendedor, quiero poder asignar un cliente a otro vendedor para distribuir el trabajo en el equipo.
    {
        SellerFacade facade = SellerFacade.Instance;
        facade.admin.CreateSeller("Pedro");
        facade.admin.CreateSeller("Juan");
        facade.CreateClient("Jose", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", facade.admin.SearchSeller("Pedro"));
        facade.AssignClient("Pedro", "Juan", facade.SearchClient(RepoClients.TypeOfData.Name,"Jose")[0]);
        Assert.That(facade.SearchClient(RepoClients.TypeOfData.Name,"Jose")[0].AsignedSeller,Is.EqualTo(facade.admin.SearchSeller("Juan")));
    }

    [Test]
    public void UserStory21Test()
    //Como usuario quiero saber el total de ventas de un periodo dado, para analizar en rendimiento de mi negocio.
    {
        AdminFacade facade = AdminFacade.Instance;
        facade.admin.CreateSeller("Juan");
        facade.CreateClient("Jose", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", facade.admin.SearchSeller("Juan"));
        facade.CreateOportunity("Harina",50,Opportunity.States.Open,facade.SearchClient(RepoClients.TypeOfData.Name,"Jose")[0]);
        facade.admin.CloseOpportunity(facade.SearchClient(RepoClients.TypeOfData.Name,"Jose")[0].Opportunities[0]);
        int actual = facade.admin.ClosedOpportunities.Count;
        Assert.That(actual,Is.EqualTo(1));
    }

    [Test]
    public void UserStory22Test()
    //Como usuario quiero ver un panel con clientes totales, interacciones recientes y reuniones próximas, para tener un resumen rápido.
    {
        AdminFacade facade = AdminFacade.Instance;
        facade.CreateClient("Ezequiel", "Pastorino", "eze@example.com", "099999999", Client.GenderType.Male, "12/12/12", null);
        facade.CreateClient("Lucía", "García", "lucia@example.com", "098888888", Client.GenderType.Female, "1995-05-05", null);
        facade.RegisterCall("Llamada 1", "Notas 1", facade.SearchClient(RepoClients.TypeOfData.Name,"Ezequiel")[0],DateTime.Now.AddDays(-1));
        facade.RegisterMeeting("Reunión 1", "Notas 2", "Sala A",Meeting.MeetingState.Programmed ,facade.SearchClient(RepoClients.TypeOfData.Name,"Ezequiel")[0] ,DateTime.Now.AddDays(1));
        facade.RegisterEmail("Email 1", InteractionOrigin.Origin.Sent, "Notas",facade.SearchClient(RepoClients.TypeOfData.Name,"Lucía")[0] ,DateTime.Now.AddDays(-1));
        string expected = 
            $"Clientes totales: 2\n" +
            $"Interacciones en este último mes: 2\n" +
            $"Reuniones próximas 1";
        string actual = facade.GetPanel();
        Assert.That(actual,Is.EqualTo(expected));
    }
}