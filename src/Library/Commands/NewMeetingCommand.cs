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
        public async Task RegisterMeetingAsync([Remainder][Summary("Crea una nueva reunion con todos sus datos")] string input)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                string[] parameters = input.Split(',');
                string clientId, content, location, type, date, notes;
                if (parameters.Length != 6)
                {
                    await ReplyAsync("Debe ingresar los parámetros necesarios.\n Ejemplo: !newmeeting 2, Hola, Maldonado, Programmed, 15/12/2025, Nos reunimos ese dia de noche");
                    return;
                }

                clientId = parameters[0].Trim();
                content = parameters[1];
                location = parameters[2]; 
                type = parameters[3].Trim(); 
                date = parameters[4].Trim();
                notes = parameters[5];
            
            
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