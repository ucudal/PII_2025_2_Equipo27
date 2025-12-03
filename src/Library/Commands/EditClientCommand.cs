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
        public async Task EditClient(
            [Remainder] 
            [Summary("Permite al user editar un usuario.")]
            string input)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                string[] parameters = input.Split(",");
                string id; string modified; string modification;
                if (parameters.Length != 2)
                {
                    await ReplyAsync("Debe ingresar exactamene tres parámetros.\nEjemplo: !editclient clientId, tagName");
                    return;
                }

                id = parameters[0];
                modified = parameters[1];
                modification = parameters[2];
                
                facade.ModifyClient(id,modified,modification);
                await ReplyAsync("Cliente modificado correctamente: nuevo " + modified + ": " + modification);
            }
            catch (Exception e)
            {
               await ReplyAsync("Hubo un error al modificar el client: " + e.Message);
            }
        }
    }
}