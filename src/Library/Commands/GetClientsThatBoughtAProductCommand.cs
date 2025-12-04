using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class GetClientsThatBoughtAProductCommand: BotModuleBase
    {
        [Command("getclientsthatbought")]
        [Summary("Permite saber todos los clientes que compraron un producto")]
        public async Task GetClientsThatBought(string product)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }

                List<Client> clientsThatBought = facade.ClientsThatBoughtAProduct(product);
                var result = new StringBuilder();
                if (clientsThatBought.Count != 0)
                {
                    foreach (var client in clientsThatBought)
                    {
                        result.Append(
                            $"ID del cliente: {client.Id}\n" +
                            $"Nombre: {client.Name}\n" +
                            $"{new string('-', 40)}\n");
                    }

                    await ReplyAsync($"Los clientes que compraron el producto o servicio '{product}' son:\n"+result.ToString());
                }
                else
                {
                    await ReplyAsync($"No hay clientes que hayan comprado el producto o servicio '{product}'");
                }
            }
            catch (ArgumentException e)
            {
                await ReplyAsync(e.Message);
            }
        }
    }
}