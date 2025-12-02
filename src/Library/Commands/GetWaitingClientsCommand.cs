using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class GetWaitingClientsCommand : BotModuleBase
    {
        [Command("getwaitingclients")]
        [Summary("Permite al user ver los clientes esperando una respuesta.")]
        public async Task GetWaitingClients()
        {
            var result = new StringBuilder();
            if (facade.WaitingClients().Count != 0)
            {
                foreach (Client client in facade.WaitingClients())
                {
                    result.Append(
                        $"{client.Name}, Id: {client.Id}\n"
                    );
                }
            }

            await ReplyAsync("Los clientes esperando respuesta son: \n" + result);
        }
    }
}