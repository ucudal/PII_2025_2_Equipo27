using System;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class GetClientsCommand : BotModuleBase
    {
        /// <summary>
        /// Implementa el comando 'getclients' para ver todos los clientes.
        /// </summary>
        [Command("getclients")]
        [Summary("Muestra todos los clientes.")]
        public async Task GetClientsAsync()
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                var clients = facade.GetClients();
                var result = new StringBuilder();
                if (clients.Count != 0)
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
                await ReplyAsync("Hubo un error al encontrar los clientes: " + e.Message);
            }
        }
    }
}