using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewMeetingCommand : ModuleBase<SocketCommandContext>
    {
        [Command("newmeeting")]
        [Summary("Registra una reunion para un cliente.")]
        public async Task RegisterMeetingAsync(string clientId, string content, string notes, string location, string type,[Remainder] string date)
        {
            try
            {
                AdminFacade.Instance.RegisterMeeting(content,notes,location,type,clientId,date);
                await ReplyAsync("Nueva reunión registrada");
                await ReplyAsync(
                    $"Contenido: {content}\nNotas: {notes}\nLocalización: {location}\nTipo: {type}\nFecha: {date}");
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