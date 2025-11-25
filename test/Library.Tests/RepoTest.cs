namespace Library.Tests;

public class RepoTagsTest
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
        string testTagName = "vip";
        RepoTags repo = new RepoTags();

        Tag tag = repo.CreateTag(testTagName);
        
        Assert.That(repo.GetAll().Count, Is.EqualTo(1));
        Assert.That(repo.GetAll()[0].TagName, Is.EqualTo(testTagName));
    }
    
    /// <summary>
    /// Verifica que no sea creada una nueva etiqueta con el mismo nombre que otra etiqueta
    /// </summary>
    
    [Test]
    public void CreateDuplicatedTag()
    {
        string testTagName = "vip";
        RepoTags repo = new RepoTags();

        repo.CreateTag(testTagName);
        
        var tag2 = Assert.Throws<Exception>(() => repo.CreateTag(testTagName));
        Assert.That(tag2.Message, Does.Contain("Ya existe un tag con ese nombre"));
    }

    /// <summary>
    /// Verifica que una etiqueta sea encontrada en la lista.
    /// </summary>
    
    [Test]
    public void SearchTag_Existing()
    {
        string testTagName = "vip";

        RepoTags repo = new RepoTags();
        Tag tag = repo.CreateTag(testTagName);

        Tag search = repo.Search(testTagName);


        Assert.That(search.TagName, Is.EqualTo(testTagName));
    }

    /// <summary>
    /// Verifica que una etiqueta no existente no sea encontrada en la lista.
    /// </summary>
    
    [Test]
    public void SearchTag_NotExisting()
    {
        string testTagName = "vip";

        RepoTags repo = new RepoTags();
        Tag tag = repo.CreateTag(testTagName);
    

        var search = Assert.Throws<Exception>(() => repo.Search("hyper"));
        Assert.That(search.Message, Does.Contain("Error al encontrar tag: "));
    }
}