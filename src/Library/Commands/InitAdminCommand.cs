using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class InitAdminCommand: BotModuleBase
    {
        [Command("initadmin")]
        [Summary("Inicia el crm creando el primer user admin a nombre del usuario.")]
        public async Task CreateFirstAdmin()
        {
            try
            {   
                string miNombreDiscord = Context.User.Username;
                admin.CreateAdmin(miNombreDiscord);
                await ReplyAsync("Primer admin creado: " + miNombreDiscord);
            }
            catch (Exception e)
            {   
                await ReplyAsync("Hubo un error al inciar el proyecto: " + e.Message);
            }
        }
    }
}