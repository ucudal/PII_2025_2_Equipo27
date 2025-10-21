using System;

namespace Library
{
    public class AdminFacade : MainFacade
    {
        
        private Admin admin = new Admin("Famapez");

        public void CreateSeller(string username)
        {
            admin.CreateSeller(username);
        }
        
        public string SuspendSeller(string username)
        {
            Seller seller = admin.ScreachSeller(username);
            if (seller != null)
            {
                return admin.SuspendSeller(seller);
            }
            else
            {
                return "El nombre de usuario ingresado no existe";
            }

        }

        public string DeleteSeller(string username)
        {
            Seller seller = admin.ScreachSeller(username);
            if (seller != null)
            {
                return admin.DeleteSeller(seller);
            }
            else
            {
                return "El nombre de usuario ingresado no existe";
            }
        }
   
    }
}