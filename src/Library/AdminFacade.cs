using System;

namespace Library
{
    public class AdminFacade
    {
        private Admin admin = new Admin("Famapez");

        public void CreateSeller(string username)
        {
            admin.CreateSeller(username);
        }

        public void SuspendSeller(string username)
        {
            Seller seller = admin.ScreachSeller(username);
            admin.SuspendSeller(seller);

        }

        public void DeleteSeller(string username)
        {
            Seller seller = admin.ScreachSeller(username);
            admin.DeleteSeller(seller);
        }
   
    }
}