namespace Library.Tests;

public class RepoTagTest
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

        Tag tag = repo.CreateTag("VIP",repo);

        List<Tag> search = repo.Search("VIP");

  
        
        Assert.That(repo.tagList.Count, Is.EqualTo(1));
        Assert.That(repo.tagList[0].TagName, Is.EqualTo("VIP"));
    }

    [Test]

    public void Search()
    {
        Admin admin = new Admin("Ezequiel");
        RepoTag repo = new RepoTag();
        Tag tag = repo.CreateTag("VIP",repo);

        List<Tag> screach = repo.Search("VIP");


        Assert.That(search[0].TagName, Is.EqualTo("VIP"));
    }
}