using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewMessageCommand : BotModuleBase
    {
        [Command("newmessage")]
        [Summary("Registra un mensage para un cliente.")]
        public async Task RegisterMessageAsync(string clientId, string content, string sender, string channel,[Remainder] string notes)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                AdminFacade.Instance.RegisterMessage(content,notes,sender,channel,clientId);
                await ReplyAsync("Nuevo mensaje registrado del cliente: " + facade.SearchClientById(clientId).Name + ": ");
                await ReplyAsync($"Contenido: {content}\nNotas: {notes}\nCanal: {channel}\nFecha: {DateTime.Now}");
            }
            catch (Exception e)
            {
                await ReplyAsync("Error al crear nueva " + e.Message);
            }
        }
    }
}