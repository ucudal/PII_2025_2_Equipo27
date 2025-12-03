using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewMeetingCommand : BotModuleBase
    {
        [Command("newmeeting")]
        [Summary("Registra una reunion para un cliente.")]
        public async Task RegisterMeetingAsync(string clientId, string content, string location, string type,string date,[Remainder] string notes)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
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