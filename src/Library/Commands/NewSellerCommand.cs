using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
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
                if (Auth("Admin") == false)
                {
                    return;
                }
                var newSeller = admin.CreateSeller(name);
                await ReplyAsync("Nuevo seller creado: " + newSeller.UserName + ", con el id: " + newSeller.Id);
            }
            catch (Exception e)
            {
                await ReplyAsync("Hubo un error al crear el nuevo vendedor: " + e.Message);
            }
        }
    }
}