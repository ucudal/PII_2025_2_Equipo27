
using Library.interactions;

namespace Library.Tests;


public class UserTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]

    public void CreateTag()
    {
        Admin admin = new Admin("Ezequiel");
        RepoTag repo = new RepoTag();
        
        Tag tag = admin.CreateTag("VIP",repo);
        
        Assert.That(repo.tagList.Count, Is.EqualTo(1));
        Assert.That(repo.tagList[0].TagName, Is.EqualTo("VIP"));
    }

    [Test]
    public void GetPanel()
    {
        RepoClients repo = new RepoClients();
        Client client1 = new Client("1", "Ezequiel", "Pastorino", "eze@example.com", "099999999", Client.GenderType.male, "12/12/12", null);
        Client client2 = new Client("2", "Lucía", "García", "lucia@example.com", "098888888", Client.GenderType.Female, "1995-05-05", null);
        client1.Interactions.Add(new Call("Llamada 1", "Notas 1", DateTime.Now.AddDays(-3)));
        client1.Interactions.Add(new Meeting("Reunión 1", "Notas 2", "Sala A", Meeting.MeetingState.Programmed, DateTime.Now.AddDays(2))); 
        client2.Interactions.Add(new Email("Email 1", InteractionOrigin.Origin.Sent, "Notas", DateTime.Now.AddDays(-1)));
        
        repo.AddClient(client1);
        repo.AddClient(client2);

        Admin admin = new Admin("Ricardo");
        string expected = 
            $"Clientes totales: 2\n" +
            $"Interacciones en este último mes: 2\n" +
            $"Reuniones próximas 1";
        
        string panel = admin.GetPanel(repo);
        
        
        
        Assert.That(panel, Is.EqualTo(expected) );
    }

    [Test]
    public void GetTotalSales()
    {
        RepoClients repo = new RepoClients();
        Client client = new Client("1", "Ezequiel", "Pastorino", "eze@example.com", "099999999", Client.GenderType.male, "12/12/12", null);
        
        client.Oportunities.Add(new Opportunity("Azúcar",60,Opportunity.State.Open,client,new DateTime(2025,10,20)));
        client.Oportunities.Add(new Opportunity("Arroz",60,Opportunity.State.Open,client, new DateTime(2025,10,20)));
        repo.AddClient(client);
        Admin admin = new Admin("Gabriel");
        DateTime startdate = new DateTime(2025, 10, 18);
        DateTime finishdate = new DateTime(2026, 10, 22);

        string exepted = "Cantidad de ventas dentro del período: 2";

        string panel = admin.GetTotalSales(repo, startdate, finishdate);
        
        Assert.That(panel, Is.EqualTo(exepted));
        
        

    }
    
}