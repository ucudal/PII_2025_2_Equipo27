using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class GetInactiveClientsCommand : BotModuleBase
    {
        [Command("getinactiveclients")]
        [Summary("Permite al user ver los clientes inactivos en un período de tiempo.")]
        public async Task GetInactiveClients()
        {
            var result = new StringBuilder();
            if (facade.InactiveClients().Count != 0)
            {
                foreach (Client client in facade.InactiveClients())
                {
                    result.Append(
                        $"{client.Name} \n"
                    );
                }
            }

            await ReplyAsync("Los clientes inactivos son: \n" + result);


        }
    }
}