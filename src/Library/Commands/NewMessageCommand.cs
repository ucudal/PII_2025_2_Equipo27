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
        public async Task RegisterMessageAsync(string clientId, string content, string notes, string sender, string channel)
        {
            try
            {
                AdminFacade.Instance.RegisterMessage(content,notes,sender,channel,clientId);
                await ReplyAsync("Nuevo mensaje registrado");
                await ReplyAsync($"Contenido: {content}\nNotas: {notes}\nCanal: {channel}");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync(e.Message);
            }
            
        }
    }
}