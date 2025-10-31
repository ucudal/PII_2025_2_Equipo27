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
        Tag tag = repo.CreateTag("VIP",repo);

        List<Tag> search = repo.Search("VIP");

        Assert.That(search[0].TagName, Is.EqualTo("VIP"));
    }
}