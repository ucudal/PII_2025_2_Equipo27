namespace Library.Tests;

public class UserTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]

    public void AddTag()
    {
        Admin admin = new Admin("Ezequiel");
        User user = admin.CreateUser("Lucas");
        Client client = new Client("1","Lucía","Pérez","luciaperez2025@gmail.com","012345678","Femenino","10/09/03");
        
        user.AddTag(client, User.Tags.Vip);
        
        Assert.That(client.Tag, Is.EqualTo(User.Tags.Vip));
    }
}