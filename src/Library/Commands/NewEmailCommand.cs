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
        public async Task RegisterEmailAsync(string clientId, string content,[Remainder] string notes, string sender)
        {
            try
            {
                AdminFacade.Instance.RegisterEmail(content, sender, notes, clientId);
                await ReplyAsync("Nuevo Email registrado");
                await ReplyAsync($"Contenido: {content}\nNotas: {notes}\n");
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