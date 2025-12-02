using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewEmailCommand : ModuleBase<SocketCommandContext>
    {
        [Command("newemail")]
        [Summary("Registra un correo para un cliente.")]
        public async Task RegisterEmailAsync([Remainder][Summary("Crea un Email con todos sus datos")] string input )
        {
            string[] parameters = input.Split(',');
            
            string clientId, content, sender, notes;
           
            if (parameters.Length != 4)
            {
                await ReplyAsync(
                    "Debe ingresar los parámetros necesarios.\n Ejemplo: !newemail 1, Hola, Sent, mando un nuevo email");
                return;
            }

            clientId = parameters[0].Trim();
            content = parameters[1];
            sender = parameters[2].Trim();
            notes = parameters[3];
            
            try
            {
                AdminFacade.Instance.RegisterEmail(content, sender, notes, clientId);
                await ReplyAsync("Nuevo Email registrado");
                await ReplyAsync($"Contenido: {content}\nNotas: {notes}\nFecha: {DateTime.Now}");
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