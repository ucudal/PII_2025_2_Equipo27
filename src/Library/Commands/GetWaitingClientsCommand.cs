using System;
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
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }

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
            catch (Exception e)
            {   
                await ReplyAsync("Hubo un error al llamar la lista de espera: " + e.Message);
                
            }
        }
    }
}