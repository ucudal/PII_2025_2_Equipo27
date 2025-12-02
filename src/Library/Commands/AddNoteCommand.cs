using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class AddNoteCommand : ModuleBase<SocketCommandContext>
    {
        [Command("addnote")]
        [Summary("Añade una nueva nota a una interacción de un cliente.")]
        public async Task AddNoteAsync([Remainder][Summary("Se agrega la nueva nota a la interaccion seleccionada")] string input)
        {
            string[] parameters = input.Split(',');
            string clientId, interactionId, notes;

            if (parameters.Length != 3)
            {
                await ReplyAsync(
                    "Debe ingresar los parámetros necesarios.\n Ejemplo: !addnote 2, 1, Agrego esta nota");
                return;
            }

            clientId = parameters[0].Trim();
            interactionId = parameters[1].Trim();
            notes = parameters[2];
            
            try
            {
                AdminFacade.Instance.AddNotes(interactionId, notes, clientId);
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