using System;
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

        [Command("sum")]
        [Summary("Devuelve la suma de los dós numeros ingresados.")]
        public async Task SumTwoNumbersAsync(int num1, int num2)
        { 
            string result = (num1 + num2).ToString();
            await ReplyAsync(result);
        }
        // public async Task SumTwoNumbersAsync(string stringNum1, string stringNum2)
        // {
        //     int num1;
        //     int num2;
        //     int sum;
        //     int.TryParse(stringNum1, out num1);
        //     int.TryParse(stringNum2, out num2);
        //     sum = num1 + num2;
        //     string result = sum.ToString();
        //     await ReplyAsync(result);
        // }
        

        // [Command("newclient")]
        // public async Task ExecuteAsync(
        //     [Remainder] [Summary("Se crea un nuevo cliente")]
        //     string clientname, string clientlastname, string email, string phone, string gender, string birthdate)
        // {
        //     if 
        //         AdminFacade.Instance.CreateClient()
        // }
        //string name, string lastName, string email, string phone, Client.GenderType gender, string birthDate, Seller seller

        [Command("newcall")]
        [Summary("Registra una llamada para un cliente.")]
        public async Task RegisterCallAsync([Summary("Se crea una nueva llamada")] string content, string notes,
            string stringClientId, [Remainder] string stringDate)
        {
            int clientId;
            if (!int.TryParse(stringClientId, out clientId))
            {
                await ReplyAsync("El Id debe ser un numero");
                return;
            }

            Client client = AdminFacade.Instance.SearchClientById(clientId);

            if (client == null)
            {
                await ReplyAsync($"El usuario con la Id {clientId} no exite");
                return;
            }

            DateTime date;
            if (!DateTime.TryParse(stringDate, out date))
            {
                await ReplyAsync("Fecha invalida, debes usar el formato AAAA-MM-DD");
                return;
            }

            AdminFacade.Instance.RegisterCall(content, notes, client, date);

            await ReplyAsync("Nueva llamada Registrada:");
            await ReplyAsync($"Contenido: {content}\nNota: {notes}\nFecha: {date}");
        }
    }
}
