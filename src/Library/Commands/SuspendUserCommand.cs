using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class SuspendUserCommand : BotModuleBase
    {
        [Command("suspenduser")]
        [Summary("Permite suspender un usuario siendo administrador")]
        public async Task SuspendUser([Remainder] [Summary("Permite suspender usuarios")] string sellerid)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                Seller seller = admin.SearchUser<Seller>(sellerid);
                admin.SuspendUser(sellerid);
                await ReplyAsync($"El usuario {seller.UserName} fue suspendido");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync($"Error: {e.Message}");
            }
        }
    }
}