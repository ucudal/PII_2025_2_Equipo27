namespace Library.Tests;

public class UserStoriesTests
{
    [Test]
    public void UserStory17Test()
    //Como usuario quiero saber los clientes que hace cierto tiempo que no tengo ninguna interacción con ellos, para no peder contacto con ellos.
    {
        Seller user = new Seller("Carlos");
        Client client = new Client(0, "pedro", "Sanchez", "pedro@gmail.com", "099000111", Client.GenderType.Male,
            "10/05/1999", user);
        client.Inactive = true;
        
    }
}