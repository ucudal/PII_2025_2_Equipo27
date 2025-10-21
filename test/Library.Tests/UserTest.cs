
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
        Client client1 = new Client("1", "Ezequiel", "Pastorino", "eze@example.com", "099999999", Client.gender.male, "12/12/12", null);
        Client client2 = new Client("2", "Lucía", "García", "lucia@example.com", "098888888", Client.gender.Female, "1995-05-05", null);
        client1.Interactions.Add(new Call("Llamada 1", "Notas 1", DateTime.Now.AddDays(-3)));
        client1.Interactions.Add(new Meeting("Reunión 1", "Notas 2", "Sala A", Meeting.MeetingState.Programmed, DateTime.Now.AddDays(2))); 
        client2.Interactions.Add(new Email("Email 1", Email.MailType.Sent, "Notas", DateTime.Now.AddDays(-1)));
        
        repo.AddClient(client1);
        repo.AddClient(client2);

        Admin admin = new Admin("Ricardo");
        
        string panel = admin.GetPanel(repo);
        
        string expected = 
            $"Clientes totales: 2\n" +
            $"Interacciones en este último mes: 1\n" +
            $"Reuniones próximas 1";
        
        Assert.That(expected, Is.EqualTo(panel));

    }
    
}