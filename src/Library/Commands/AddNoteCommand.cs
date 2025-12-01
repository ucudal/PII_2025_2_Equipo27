using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class AddNoteCommand : ModuleBase<SocketCommandContext>
    {
        [Command("addnote")]
        [Summary("Añade una nueva nota a una interacción de un cliente.")]
        public async Task AddNoteAsync(string interactionId,[Remainder] string note, string clientId)
        {
            try
            {
                AdminFacade.Instance.AddNotes(interactionId, note, clientId);
                await ReplyAsync("La nota se ha agregado correctamente");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync(e.Message);
            }
        }
    }
}