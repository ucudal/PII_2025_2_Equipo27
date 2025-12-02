using System;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class SearchClientCommand : BotModuleBase
    {
        [Command("searchclient")]
        [Summary("Permite encontrar un cliente.")]
        public async Task SearchClient(string dataSearched, string text)
        {
            try
            {
                var clients = facade.SearchClient(dataSearched, text);
                var result = new StringBuilder();
                if (facade.SearchClient(dataSearched, text) != null)
                {
                    foreach (var client in clients)
                    {
                        result.Append(
                            $"ID del cliente: {client.Id}\n" +
                            $"Nombre: {client.Name}\n" +
                            $"Apellido: {client.LastName}\n" +
                            $"Mail: {client.Email}\n" +
                            $"Teléfono: {client.Phone}\n" +
                            $"Género: {client.Gender}\n" +
                            $"Fecha de nacimiento: {client.BirthDate}\n" +
                            $"{new string('-', 40)}\n");
                    }

                    await ReplyAsync(result.ToString());
                }
                else
                {
                    await ReplyAsync("No tienes ningún cliente");
                }
            }
            catch (Exception e)
            {
                await ReplyAsync("Hubo un error al encontrar el client: " + e.Message);
            }
        }
    }
}