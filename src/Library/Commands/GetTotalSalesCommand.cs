using System;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class GetTotalSalesCommand : BotModuleBase
    {
        [Command("gettotalsales")]
        [Summary("Permite ver el total de ventas")]
        public async Task GetTotalSales()
        {

            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                var result = new StringBuilder();
                if (seller.ClosedOpportunities.Count != 0)
                {
                    foreach (Opportunity opportunity in seller.ClosedOpportunities)
                    {
                        result.Append(
                            $"Id de la oportunidad: {opportunity.Id}\n" +
                            $"Cliente asignado: {opportunity.Client.Name} con Id: {opportunity.Client.Id}\n" +
                            $"Producto: {opportunity.Product}\n" +
                            $"Precio: {opportunity.Price}\n" +
                            $"Fecha: {opportunity.Date.ToString()}\n" +
                            $"Vendedor asignado: {opportunity.Client.AsignedSeller.UserName}\n" +
                            $"{new string('-', 40)}\n");
                    }

                    await ReplyAsync(result.ToString());
                }
                else
                {
                    await ReplyAsync("No tienes ninguna venta");
                }
            }
            catch(Exception e)
            {
                await ReplyAsync(e.Message);
            }
        }
    }
}