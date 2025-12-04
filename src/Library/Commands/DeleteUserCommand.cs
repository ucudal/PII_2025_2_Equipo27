using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class DeleteUserCommand : BotModuleBase
    {
        [Command("deleteuser")]
        [Summary("Permite eliminar un usuario siendo administrador")]
        public async Task DeleteUser([Remainder] [Summary("Permite eliminar usuarios")] string sellerid)
        {
            if (Auth("Admin") == false)
            {
                return;
            }
            try
            {
                    
                    Seller seller = admin.SearchUser<Seller>(sellerid);
                    admin.DeleteUser(sellerid);
                    await ReplyAsync($"El usuario {seller.UserName} fue eliminado");
            }
            catch (ArgumentException e) 
            {
                    await ReplyAsync($"Error: {e.Message}");
            }
        }
    }
}