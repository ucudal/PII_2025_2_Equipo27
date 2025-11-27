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

        // [Command("newclient")]
        // [Summary("Crear un nuevo cliente y devuelve un mensaje indicando si se creeó correctamente o no.")]
        // public async Task CreateNewClientAsync(string input)
        // {
        //     string[] parameters = input.Split(",");
        //     string name; string lastName; string email; string phone;
        //     if (parameters.Length >= 1)
        //     {
        //         name = parameters[0];
        //     }
        //     if (parameters.Length >= 2)
        //     {
        //         name = parameters[1];
        //     }
        //     if (parameters.Length >= 3)
        //     {
        //         name = parameters[2];
        //     }
        //     if (parameters.Length >= 4)
        //     {
        //         name = parameters[3];
        //     }
        //     Seller seller = new Seller("Marito");
        //     Client client = SellerFacade.Instance.CreateClient(name, lastName, email, phone, seller);
        //     if (SellerFacade.Instance.GetClients().Contains(client))
        //     {
        //         await ReplyAsync("Cliente creado correctamente.");
        //     }
        //     else
        //     {
        //         await ReplyAsync("Client no creado.");
        //     }
        // }

        // [Command("newclient")]
        // [Summary("Crear un nuevo cliente y devuelve un mensaje indicando si se creeó correctamente o no.")]
        // public async Task CreateNewClientAsync(string name, string lastName, string email, string phone, string gender, string birthDate)
        // {
        //     Seller seller = new Seller("Marito");
        //     Client client = SellerFacade.Instance.CreateClient(name, lastName, email, phone, gender, birthDate, seller);
        //     if (SellerFacade.Instance.GetClients().Contains(client))
        //     {
        //         await ReplyAsync("Cliente creado correctamente.");
        //     }
        //     else
        //     {
        //         await ReplyAsync("Client no creado.");
        //     }
        // }
    }
}