namespace Library.Tests;

public class SellerFacadeTest
{
    [SetUp]
    public void SetUp()
    {
        SellerFacade.ResetInstance();
        AdminFacade.ResetInstance();
        RepoUser.ResetInstance();
        RepoClients.ResetInstance();
    }

    [Test]
    public void AsignClient_IfFind()
    {
        
     
        Seller seller1 = AdminFacade.Instance.CreateSeller("Peter");
        Seller seller2 = AdminFacade.Instance.CreateSeller("Ezequiel");
        Client client = AdminFacade.Instance.CreateClient("Facundo", "Pastoruti", "facundopastoruti", "55555555",
             seller1);
   
        SellerFacade.Instance.AssignClient(seller1.UserName, seller2.UserName, "0");

        Assert.That(client.AsignedSeller.UserName, Is.EqualTo(seller2.UserName));
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