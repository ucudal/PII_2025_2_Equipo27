using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewMessageCommand : ModuleBase<SocketCommandContext>
    {
        [Command("newmessage")]
        [Summary("Registra un mensage para un cliente.")]
        public async Task RegisterMessageAsync(string clientId, string content, string sender, string channel,[Remainder] string notes)
        {
            try
            {
                AdminFacade.Instance.RegisterMessage(content,notes,sender,channel,clientId);
                await ReplyAsync("Nuevo mensaje registrado");
                await ReplyAsync($"Contenido: {content}\nNotas: {notes}\nCanal: {channel}\nFecha: {DateTime.Now}");
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