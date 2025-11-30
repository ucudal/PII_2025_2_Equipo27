using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewClientCommand : ModuleBase<SocketCommandContext>
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
        public async Task CreateNewClientAsync(string input)
        {
            string[] parameters = input.Split(",");
            string name;
            string lastName;
            string email;
            string phone;
            string sellerName;
            if (parameters.Length != 5)
            {
                await ReplyAsync(
                    "Debe ingresar los parámetros necesarios. \n Ejemplo: !newclient Marcelo, Rodriguez, email@example, 099123123, SellerName");
                return;
            }

            name = parameters[0];
            lastName = parameters[1];
            email = parameters[2];
            phone = parameters[3];
            sellerName = parameters[4];
            AdminFacade.Instance.CreateSeller("Marito");

            try
            {
                SellerFacade.Instance.CreateClient(name, lastName, email, phone, sellerName);
                await ReplyAsync("Cliente creado correctamente.");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync($"Error: {e.Message}");
            }
        }
    }
}