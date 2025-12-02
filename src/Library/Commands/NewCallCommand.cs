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
        public async Task RegisterCallAsync([Remainder][Summary("Crea una nueva llameda con todos sus datos")] string input)
        {
            string[] parameters = input.Split(',');
            string clientId, content, sender, notes;

            if (parameters.Length != 4)
            {
                await ReplyAsync(
                    "Debe ingresar los parámetros necesarios.\n Ejemplo: !newcall 3, Hola, Sent, Nueva llamada");
                return;
            }

            clientId = parameters[0].Trim();
            content = parameters[1];
            sender = parameters[2].Trim();
            notes = parameters[3];
            
            try
            {
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