using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class GetClientsWithHigherSellsCommand : BotModuleBase
    {
        [Command("getclientswithhighersels")]
        [Summary("Retorna el nombre de los clientes con ventas mayores/iguales al monto ingresado.")]

        public async Task GetClientsWithHigherSells(
            [Remainder]
            [Summary("Retorna el nombre de los clientes")]
            string input)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }

                string[] parameters = input.Split(",");
                
                if (parameters.Length != 1)
                {
                    await ReplyAsync("Debe ingresar exactamente 1 parámetro.\nEjemplo: !getclientswithhighersels 100");
                    return;
                }
                string amount = parameters[0];
                List<Client> clients = seller.GetClientsHigherThanSell(amount);
                if (clients.Count == 0)
                {
                    await ReplyAsync("No se encontró ningún cliente con una venta mayor al monto ingresado.");
                    return;
                }

                StringBuilder result = new StringBuilder();
                result.Append("Clientes encontrados:");
                foreach (var client in clients)
                {
                    result.Append($"- {client.Name}\n");
                }

                await ReplyAsync(result.ToString());
            }
            catch (ArgumentException e)
            {
                await ReplyAsync($"Error: {e.Message}");
            }
            
        }
    }
}