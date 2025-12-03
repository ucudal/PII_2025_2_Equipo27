using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewTagCommand : BotModuleBase
    {
        [Command("newtag")]
        [Summary(("Crea un nuevo tag"))]

        public async Task CreateNewTag(
            [Remainder]
            [Summary("Crea un tag con el nombre ingresado si no exsiste uno con el mismo nombre")]
            string input)
        {
            if (Auth("All") == false)
            {
                return;
            }
            string[] parameters = input.Split(",");
            string tagName;
            if (parameters.Length != 1)
            {
                await ReplyAsync("Debe ingresar exactamente 1 parámetro.\nEjemplo: !newtag nombreDelTag");
                return;
            }

            tagName = parameters[0];
            
            try
            {
                SellerFacade.Instance.CreateTag(tagName);
                await ReplyAsync("Tag creado correctamente.");
            }
            catch (InvalidOperationException e)
            {
                await ReplyAsync($"Error: {e.Message}");
            }
        }
    }
}