using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class WhoCommand : BotModuleBase
    {
        [Command("who")]
        public async Task WhoAsync()
        {
            string miNombreDiscord = Context.User.Username;
            var listaUsuarios = admin.GetUsers();
            string nombresUsuarios = string.Join(", ", listaUsuarios.Select(u => u.UserName));
            await ReplyAsync("Tu nombre es: " + miNombreDiscord +", con el ID: " + GetMyId() + ". Los usuarios existentes son: " + nombresUsuarios);
        }
    }
}