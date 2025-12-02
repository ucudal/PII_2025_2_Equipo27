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
        public async Task RegisterMessageAsync([Remainder]
            [Summary("Crea un cliente con todos sus datos")]
            string input)
        {
            string[] parameters = input.Split(",");
            string clientId;
            string content;
            string sender;
            string channel;
            string notes;
            if (parameters.Length != 5)
            {
                await ReplyAsync(
                    "Debe ingresar los parámetros necesarios.\n Ejemplo: !newmessage 2, Hola, Sent, Whatsapp, llamada al vendedor por whatsapp");
                return;
            }
            clientId = parameters[0].Trim();
            content = parameters[1];
            sender = parameters[2].Trim();
            channel = parameters[3];
            notes = parameters[4];
            
            try
            {
                facade.RegisterMessage(content,notes,sender,channel,clientId);
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