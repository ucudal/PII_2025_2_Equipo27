using System;
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

            try
            {
                var newSeller = admin.CreateSeller(name);
                ReplyAsync("Nuevo seller creado: " + newSeller.UserName + ", con el id: " + newSeller.Id);
            }
            catch (InvalidOperationException e)
            {
                await ReplyAsync(e.Message);
            }
        }
    }
}