namespace Library.Tests;

public class TagTest
{
    /// <summary>
    /// Verifica que el nombre de la etiqueta sea ingresado correctamente
    /// </summary>
    [Test]
    public void SetTagName_Valid()
    {
        Tag tag = new Tag(0,"ViP");
        string testTagName = "vip";

        Assert.That(testTagName, Is.EqualTo(tag.TagName));
    }
    
}