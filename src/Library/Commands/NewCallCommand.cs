using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewCallCommand : ModuleBase<SocketCommandContext>
    {
        [Command("newcall")]
        [Summary("Registra una llamada para un cliente.")]
        public async Task RegisterCallAsync([Summary("Se crea una nueva llamada")] string content, string notes,
            string stringClientId, [Remainder] string stringDate)
        {
            
        }
    }
}