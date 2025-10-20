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
    
}