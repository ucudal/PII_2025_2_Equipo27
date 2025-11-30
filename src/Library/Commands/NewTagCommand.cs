using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewTagCommand : ModuleBase<SocketCommandContext>
    {
        [Command("newtag")]
        [Summary(("Crea un nuevo tag"))]

        public async Task CreateNewTag(string input)
        {
            string[] parameters = input.Split(",");
            string tagName;
            if (parameters.Length != 1)
            {
                await ReplyAsync("Debe ingresar exactamente 1 parámetro.\nEjemplo: !newtag Nombre del Tag");
                return;
            }

            tagName = parameters[0];
            
            try
            {
                SellerFacade.Instance.CreateTag(tagName);
                await ReplyAsync("Tag creado correctamente.");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync($"Error: {e.Message}");
            }
        }
    }
}