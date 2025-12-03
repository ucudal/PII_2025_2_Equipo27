using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class AssignTagCommand : BotModuleBase
    {
        [Command("assigntag")]
        [Summary("Comando para agregar un tag a un cliente")]

        public async Task AssignTag(
            [Remainder] 
            [Summary("Agrega tag a un cliente indicado")]
            string input)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                string[] parameters = input.Split(",");
                string clientId; string tagName;
                if (parameters.Length != 2)
                {
                    await ReplyAsync("Debe ingresar exactamene dos parámetros.\nEjemplo: !assigntag 0, Compra monitores");
                    return;
                }

                clientId = parameters[0];
                tagName = parameters[1];
                
                facade.AddTag(clientId, tagName);

                await ReplyAsync("Tag agregado correctamente.");
            }
            catch (Exception e)
            {
                await ReplyAsync("Hubo un error al agregar el tag: " + e.Message);
            }
        }


    }
}