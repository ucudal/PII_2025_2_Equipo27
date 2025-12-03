using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class InitSellerCommand: BotModuleBase
    {
        
        [Command("initseller")]
        [Summary("Inicia el crm creando el primer user seller a nombre del usuario.")]
        public async Task CreateFirstSeller()
        {
            try
            {   
                string miNombreDiscord = Context.User.Username;
                admin.CreateSeller(miNombreDiscord);
                await ReplyAsync("Primer seller creado: " + miNombreDiscord);
            }
            catch (Exception e)
            {   
                await ReplyAsync("Hubo un error al inciar el proyecto: " + e.Message);
            }
        }
    }
}