namespace Library.Tests;

public class TagTest
{
    /// <summary>
    /// Verifica que el nombre de la etiqueta sea ingresado correctamente
    /// </summary>
    [Test]
    public void SetTagName_Valid()
    {
        Tag tag = new Tag("VIP");
        Assert.That("VIP", Is.EqualTo(tag.TagName));
    }

    /// <summary>
    /// Verifica que no se lance una excepción si se crea una etiqueta sin nombre
    /// </summary>
    [Test]
    public void SetTagName_Exception()
    {
        Assert.Throws<ArgumentException>(() => Is.EqualTo(new Tag("")));
    }
}