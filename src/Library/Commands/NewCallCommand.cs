using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Library.interactions;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewCallCommand : ModuleBase<SocketCommandContext>
    {
        [Command("newcall")]
        [Summary("Registra una llamada para un cliente.")]
        public async Task RegisterCallAsync( string clientId, string content,[Remainder]  string notes)
        {
            try
            {
                AdminFacade.Instance.RegisterCall(content,notes,clientId);
                await ReplyAsync("Nueva llamada registrada.");
                await ReplyAsync($"Contenido: {content}\nNota: {notes}");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync(e.Message);
            } 
            catch (InvalidOperationException e)
            {
                await ReplyAsync(e.Message);
            }
        }
    }
}