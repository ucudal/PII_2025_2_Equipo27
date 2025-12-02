using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class AddTagCommand : ModuleBase<SocketCommandContext>
    {
        [Command("addtag")]
        [Summary("Comando para agregar un tag a un cliente")]

        public async Task AddNewData(
            [Remainder] 
            [Summary("Agrega tag a un cliente indicado")]
            string input)
        {
            string[] parameters = input.Split(",");
            string clientId; string tagName;
            if (parameters.Length != 2)
            {
                await ReplyAsync("Debe ingresar exactamene dos parámetros.\nEjemplo: !addtag clientId, tagName");
                return;
            }

            clientId = parameters[0];
            tagName = parameters[1];
            
            SellerFacade.Instance.AddTag(clientId, tagName);

            await ReplyAsync("Tag agregado correctamente.");
        }


    }
}