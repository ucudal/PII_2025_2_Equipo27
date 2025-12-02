using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class SwitchClientInactivityCommand : BotModuleBase
    {
        [Command("switchclientinactivity")]
        [Summary("Permite alternar entre cliente inactivo y activo.")]
        public async Task SwitchClientInactivity(
            [Remainder] [Summary("Permite alternar entre cliente inactivo y activo")] string clientid)
        {
            try
            {
                string state = "";
                facade.SwitchClientActivity(clientid);
                if (facade.SearchClientById(clientid).Inactive)
                {
                    state = "Inactivo";
                }
                else
                {
                    state = "Activo";
                }
                await ReplyAsync($"El estado de actividad del cliente se cambió a {state}");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync("Hubo un error al cambiar el estado de actividad del cliente: " + e.Message);

            }
        }
    }
}