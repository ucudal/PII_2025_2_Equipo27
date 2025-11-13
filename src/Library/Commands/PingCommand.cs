using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Library;

// using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands
{

    /// <summary>
    /// Esta clase implementa el comando 'ping' del bot.
    /// Este comando retorna 'pong'.
    /// </summary>
// ReSharper disable once UnusedType.Global
    public class PingCommand : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Implementa el comando 'ping'.
        /// </summary>
        [Command("ping")]
        [Summary(
            "Devuelve 'pong'.")]
        // ReSharper disable once UnusedMember.Global
        public async Task ExecuteAsync()
        {
            await ReplyAsync("pong");
        }

        // [Command("newclient")]
        // public async Task ExecuteAsync(
        //     [Remainder] [Summary("Se crea un nuevo cliente")]
        //     string clientname, string clientlastname, string email, string phone, string gender, string birthdate)
        // {
        //     if 
        //         AdminFacade.Instance.CreateClient()
        // }
        //string name, string lastName, string email, string phone, Client.GenderType gender, string birthDate, Seller seller
    }
}
