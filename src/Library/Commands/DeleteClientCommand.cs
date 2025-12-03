using System;
using System.Threading.Tasks;
using Discord.Commands;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class DeleteClientCommand : BotModuleBase
    {
        [Command("deleteclient")]
        [Summary("Permite eliminar un usuario.")]
        public async Task DeleteClient(string id)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                facade.DeleteClient(id);
                await ReplyAsync("Cliente eliminado correctamente.");

            }
            catch (Exception e)
            {
                await ReplyAsync("hubo un error al eliminar el client: " + e.Message);
            }
        }
    }
}
