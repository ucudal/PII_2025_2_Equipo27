using Discord.Commands;
using Library;
using System.Linq;

namespace Program.Commands
{
    public abstract class BotModuleBase : ModuleBase<SocketCommandContext>
    {
        protected readonly AdminFacade admin = AdminFacade.Instance;
        protected readonly SellerFacade seller = SellerFacade.Instance;

        protected string GetMyId()
        {
            var user = admin.GetUsers()
                .FirstOrDefault(u => u.UserName == Context.User.Username.ToLower());
            
            return user?.Id.ToString(); 
        }
    }
}