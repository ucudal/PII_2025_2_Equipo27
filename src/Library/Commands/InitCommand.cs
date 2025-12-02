using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class InitCommand: BotModuleBase
    {
        

        [Command("init")]
        [Summary("Inicia el crm creando el primer user admin a nombre del usuario.")]
        public async Task CreateFirstAdmin()
        {
            string miNombreDiscord = Context.User.Username;
            admin.CreateAdmin(miNombreDiscord);
            await ReplyAsync("Primer admin creado: " + miNombreDiscord);
        }
    }
}