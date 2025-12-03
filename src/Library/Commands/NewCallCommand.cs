using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Library.interactions;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewCallCommand : BotModuleBase
    {
        [Command("newcall")]
        [Summary("Registra una llamada para un cliente.")]
        public async Task RegisterCallAsync(string clientId, string content, string sender, [Remainder]  string notes)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                AdminFacade.Instance.RegisterCall(content,sender, notes,clientId);
                await ReplyAsync("Nueva llamada registrada.");
                await ReplyAsync($"Contenido: {content}\nNota: {notes}\nFecha: {DateTime.Now}");
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