namespace Library.Tests;

public class SellerFacadeTest
{
    [SetUp]
    public void SetUp()
    {
        SellerFacade.ResetInstance();
    }

    [Test]
    public void AsignClient_IfFind()
    {
        SellerFacade facade = SellerFacade.Instance;
        Seller seller1 = facade.admin.CreateSeller("Peter");
        Seller seller2 = facade.admin.CreateSeller("Ezequiel");
        Client client = new Client(1, "Facundo", "Pastoruti", "facundopastoruti", "55555555", Client.GenderType.Male,
            "21/10/2020", null);

        facade.AssignClient("Peter", "Ezequiel", client);

        Assert.That(client.AsignedSeller, Is.EqualTo(seller2));
    }
}

//     [Test]
//     public void AsignClien_IfNotFind()
//     {
//         SellerFacade facade = SellerFacade.Instance;
//         Seller seller1 = facade.admin.CreateSeller("Peter");
//         Client client = new Client(1, "Facundo", "Pastoruti", "facundopastoruti", "55555555", Client.GenderType.Male,
//             "21/10/2020", null);
//         
//         string example = facade.AssignClient("Peter","Ezequiel",client);
//         
//         Assert.That(example, Is.EqualTo("Hay al menos un usuario no encontrado"));
//     }
// }