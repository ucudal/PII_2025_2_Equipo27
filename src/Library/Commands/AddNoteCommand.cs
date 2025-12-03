using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class AddNoteCommand : BotModuleBase
    {
        [Command("addnote")]
        [Summary("Añade una nueva nota a una interacción de un cliente.")]
        public async Task AddNoteAsync(string clientId, string interactionId,[Remainder] string note)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                facade.AddNotes(interactionId, note, clientId);
                await ReplyAsync("La nota se ha agregado correctamente");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync(e.Message);
            }
            catch (KeyNotFoundException e)
            {
                await ReplyAsync(e.Message);
            }
        }
    }
}