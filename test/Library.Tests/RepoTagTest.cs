namespace Library.Tests;

public class RepoTagTest
{
    [SetUp]
    public void Setup()
    {
    }
    
    /// <summary>
    /// Verifica que sea creada una nueva etiqueta y sea enviada a una lista de etiquetas
    /// </summary>
    
    [Test]
    public void CreateTag()
    {
        RepoTag repo = new RepoTag();

        Tag tag = repo.CreateTag("VIP");
        
        Assert.That(repo.TagList.Count, Is.EqualTo(1));
        Assert.That(repo.TagList[0].TagName, Is.EqualTo("VIP"));
    }

    /// <summary>
    /// Verifica que una etiqueta sea encontrada en la lista.
    /// </summary>
    
    [Test]
    public void SearchTag_Existing()
    {
        RepoTag repo = new RepoTag();
        Tag tag = repo.CreateTag("VIP");

        List<Tag> search = repo.Search("VIP");


        Assert.That(search[0].TagName, Is.EqualTo("VIP"));
    }
}