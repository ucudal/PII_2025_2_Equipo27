using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewClientCommand : BotModuleBase
    {
        /// <summary>
        /// Implementa el comando 'newclient'.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        

        [Command("newclient")]
        [Summary("Crear un nuevo cliente y devuelve un mensaje indicando si se creeó correctamente o no.")]

        public async Task CreateNewClientAsync(
        [Remainder]
        [Summary("Crea un cliente con todos sus datos")]
        string input)
        {
            string[] parameters = input.Split(",");
            string name;
            string lastName;
            string email;
            string phone;
            string sellerId;
            if (parameters.Length != 5)
            {
                await ReplyAsync(
                    "Debe ingresar los parámetros necesarios.\n Ejemplo: !newclient Marcelo, Rodriguez, email@example, 099123123, SellerId");
                return;
            }

            name = parameters[0];
            lastName = parameters[1];
            email = parameters[2];
            phone = parameters[3];
            sellerId = parameters[4];

            try
            {
                Client client = facade.CreateClient(name, lastName, email, phone, sellerId);
                await ReplyAsync($"Cliente creado correctamente. {name} con id: {client.Id} ");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync($"Error: {e.Message}");
            }
        }
    }
}