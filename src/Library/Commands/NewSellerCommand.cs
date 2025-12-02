using System.Threading.Tasks;
using Discord.Commands;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewSellerCommand : BotModuleBase
    {


        [Command("newseller")]
        [Summary("Permite al admin crear un nuevo seller.")]
        public async Task CreateNewSeller(string name)
        {
            var newSeller = admin.CreateSeller(name);
            await ReplyAsync("Nuevo seller creado: " + newSeller.UserName + ", con el id: " + newSeller.Id);
        }
    }
}