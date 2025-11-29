using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class GetClientsCommand : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Implementa el comando 'getclients' para ver todos los clientes.
        /// </summary>
        [Command("getclients")]
        [Summary("Muestra todos los clientes.")]
        public async Task GetClientsAsync()
        {
            var result = new StringBuilder();
            if (SellerFacade.Instance.GetClients().Count != 0)
            {
                foreach (var client in SellerFacade.Instance.GetClients())
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
    }
}