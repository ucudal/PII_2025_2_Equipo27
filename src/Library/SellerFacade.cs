namespace Library
{
    public class SellerFacade
    {
        private Admin admin = new Admin("Luciano");
        private RepoClients repo = new RepoClients();
        public void AssignClient(string sellernameMy, string sellernameOther, string clientname)
        {
            Seller seller1  = admin.ScreachSeller(sellernameMy);
            Seller seller2 = admin.ScreachSeller(sellernameOther);
            Client client = repo.SearchClientByName(clientname);
            
            seller1.AsignClient(seller2,client);
            
        }
    }
}