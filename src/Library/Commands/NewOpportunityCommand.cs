using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewOpportunityCommand : ModuleBase<SocketCommandContext>
    {
        [Command("newopportunity")]
        [Summary("Comando para registrar una oportunidad)")]

        public async Task NewOpportunity(
            [Remainder] 
            [Summary("Crea un una oportuidad asignada a un cliente dado")]
            string input)
        {
            string[] parameters = input.Split(",");
            if (parameters.Length != 4)
            {
                await ReplyAsync("Debe ingresar exactamente cuatro parámetros.\n" +
                                 "Ejemplo: !registeropportunity product, price, state, clientId");
                return;
            }
            string product = parameters[0]; string price = parameters[1]; 
            string state = parameters[2]; string clientId = parameters[3];

            try
            {
                SellerFacade.Instance.CreateOpportunity(product, price, state, clientId);
                await ReplyAsync("Opportunidad creada correctamente.");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync($"Error: {e.Message}");
            }
        }
    }
}