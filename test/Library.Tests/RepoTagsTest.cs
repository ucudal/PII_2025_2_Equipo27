namespace Library.Tests;

public class RepoTagsTest
{
    [SetUp]
    public void Setup()
    {
        // Antes de empezar cualquier test, aseguramos que el repo esté vacío
        RepoTags.ResetInstance();
    }
    
    /// <summary>
    /// Verifica que sea creada una nueva etiqueta y sea enviada a una lista de etiquetas
    /// </summary>
    [Test]
    public void CreateTag()
    {
        string testTagName = "vip";
        RepoTags repo = RepoTags.Instance;

        Tag tag = repo.CreateTag(testTagName);
        
        Assert.That(repo.GetAll().Count, Is.EqualTo(1));
        Assert.That(repo.GetAll()[0].TagName, Is.EqualTo(testTagName));
    }
    
    /// <summary>
    /// verifica que se normaliza el nombre del tag y se guarda en minuscula y sin espacios a los costados
    /// </summary>
    [Test]
    public void CreateTag_ShouldNormalizeName()
    {

        string dirtyName = "  ViP  ";
        RepoTags repo = RepoTags.Instance;
        
        repo.CreateTag(dirtyName);
        Assert.That(repo.GetAll()[0].TagName, Is.EqualTo("vip"));
    }
    
    /// <summary>
    /// Verifica que no sea creada una nueva etiqueta con el mismo nombre que otra etiqueta
    /// </summary>
    [Test]
    public void CreateDuplicatedTag()
    {
        string testTagName = "vip";
        RepoTags repo = RepoTags.Instance;

        repo.CreateTag(testTagName);
        
        var tag2 = Assert.Throws<InvalidOperationException>(() => repo.CreateTag(testTagName));
        Assert.That(tag2.Message, Does.Contain("Ya existe un tag con ese nombre"));
    }

    /// <summary>
    /// Verifica que una etiqueta sea encontrada en la lista.
    /// </summary>
    
    [Test]
    public void SearchTag_Existing()
    {
        string testTagName = "vip";

        RepoTags repo = RepoTags.Instance;
        repo.CreateTag(testTagName);
        Tag search = repo.Search(testTagName);

        Assert.That(search.TagName, Is.EqualTo(testTagName));
    }
    
    /// <summary>
    /// verifica que se le da igual minusculas y mayusculas
    /// </summary>
    [Test]
    public void SearchTag_ShouldIgnoreCapitalization()
    {

        RepoTags repo = RepoTags.Instance;
        repo.CreateTag("vip"); 
        
        Tag foundTag = repo.Search("VIP");

        Assert.That(foundTag, Is.Not.Null);
        Assert.That(foundTag.TagName, Is.EqualTo("vip"));
    }

    /// <summary>
    /// Verifica que una etiqueta no existente no sea encontrada en la lista.
    /// </summary>
    [Test]
    public void SearchTag_NotExisting()
    {
        string testTagName = "vip";

        RepoTags repo = RepoTags.Instance;
    

        var search = Assert.Throws<ArgumentException>(() => repo.Search("hyper"));
        Assert.That(search.Message, Does.Contain("No se encontró ninguna tag con ese nombre"));
    }
    
    
    /// <summary>
    /// Verifica que cuando elimino un tag se reduce la cantidad de tags
    /// </summary>
    [Test]
    public void RemoveTag_ShouldDecreaseCount()
    {
        RepoTags repo = RepoTags.Instance;
        Tag tag = repo.CreateTag("vip");
        int initialCount = repo.Count;
        
        repo.Remove(tag.Id);

        Assert.That(repo.Count, Is.EqualTo(initialCount - 1));
        Assert.Throws<ArgumentException>(() => repo.Search("vip"));
    }
    
    /// <summary>
    /// Verifica busqueda por id
    /// </summary>
    [Test]
    public void GetById_ShouldReturnCorrectTag()
    {
        RepoTags repo = RepoTags.Instance;
        Tag createdTag = repo.CreateTag("vip"); 
        
        Tag retrievedTag = repo.GetById(createdTag.Id);

        Assert.That(retrievedTag, Is.Not.Null);
        Assert.That(retrievedTag.TagName, Is.EqualTo("vip"));
    }
    
    /// <summary>
    /// Verifica que no se puede pasar un valor null para crear un nuevo tag
    /// </summary>
    [Test]
    public void Create_NullEntity_ShouldThrow()
    {
        RepoTags repo = RepoTags.Instance;

        var ex = Assert.Throws<ArgumentNullException>(() => repo.Create(null));
    
        Assert.That(ex.Message, Does.Contain("No se puede agregar un tag nulo."));
    }
}