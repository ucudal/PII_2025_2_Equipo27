using System;
using System.Threading.Tasks;
using Discord.Commands;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class EditClientCommand: BotModuleBase
    {
        [Command("editclient")]
        [Summary("Permite al user editar un usuario.")]
        public async Task EditClient(string id,string modified,string modification)
        {
            try
            {
                facade.ModifyClient(id,modified,modification);
                await ReplyAsync("Cliente modificado correctamente: nuevo " + modified + ": " + modification);

            }
            catch (Exception e)
            {
               await ReplyAsync("hubo un error al modificar el client: " + e.Message);
            }
        }
    }
}