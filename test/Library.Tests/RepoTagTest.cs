namespace Library.Tests;

public class RepoTagTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]

    public void Screach()
    {
        Admin admin = new Admin("Ezequiel");
        RepoTag repo = new RepoTag();
        Tag tag = admin.CreateTag("VIP");

        List<Tag> screach = repo.Screach("VIP");

        Assert.That(screach[0].TagName, Is.EqualTo("VIP"));
    }
}