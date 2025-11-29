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
            // int clientId;
            // if (!int.TryParse(stringClientId, out clientId))
            // {
            //     await ReplyAsync("El Id debe ser un numero");
            //     return;
            // }
            //
            // Client client = AdminFacade.Instance.SearchClientById(clientId);
            //
            // if (client == null)
            // {
            //     await ReplyAsync($"El usuario con la Id {clientId} no exite");
            //     return;
            // }
            //
            // DateTime date;
            // if (!DateTime.TryParse(stringDate, out date))
            // {
            //     await ReplyAsync("Fecha invalida, debes usar el formato AAAA-MM-DD");
            //     return;
            // }
            //
            // AdminFacade.Instance.RegisterCall(content, notes, client, date);
            //
            // await ReplyAsync("Nueva llamada Registrada:");
            // await ReplyAsync($"Contenido: {content}\nNota: {notes}\nFecha: {date}");
        }
    }
}