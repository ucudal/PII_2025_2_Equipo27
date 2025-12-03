using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class ActiveUserCommand : BotModuleBase
    {
        [Command("activeuser")]
        [Summary("Permite activar un usuario suspendido siendo administrador")]
        public async Task ActiveUser([Remainder] [Summary("Permite activar usuarios")] string sellerid)
        {
            try
            {
                Seller seller = admin.SearchUser<Seller>(sellerid);
                admin.ActiveUser(sellerid);
                await ReplyAsync($"El usuario {seller.UserName} fue activado");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync($"Error: {e.Message}");
            }
        }

    }
}
