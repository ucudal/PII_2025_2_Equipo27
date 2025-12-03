using System;
using System.Threading.Tasks;
using Discord.Commands;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class ChangeOpportunityStateCommand : BotModuleBase
    {
        [Command("changeopportunitystate")]
        [Summary("Permite cambiar el estado de una oportunidad")]
        public async Task changeopportunitystate(
            [Remainder] [Summary("Cambia el estado de una oportunidad")] string input)
        {
            if (Auth("All") == false)
            {
                return;
            }
            string[] parameters = input.Split(",");
            string opportunityId;
            string clientId;
            string newState;
            if (parameters.Length != 3)
            {
                await ReplyAsync(
                    "Debe ingresar los parámetros necesarios.\n Ejemplo: !changeopportunitystate 1,3,Close");
                return;
            }
            opportunityId = parameters[0];
            clientId = parameters[1];
            newState = parameters[2];
            try
            {
                facade.ChangeOpportunityState(opportunityId,clientId,newState);
                await ReplyAsync($"El estado de la oportunidad se ha cambiado a '{newState}'");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync(e.Message);
                throw;
            }
        }
    }
}