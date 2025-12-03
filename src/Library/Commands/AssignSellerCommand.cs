using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class AssignSellerCommand : BotModuleBase
    {
        [Command("assignseller")]
        [Summary("Permite a un vendedor asignarle un cliente a otro vendedor")]
        public async Task AssignSeller([Remainder] [Summary("Asigna un vendedor a otro")] string input)
        {
            if (Auth("Seller") == false)
            {
                return;
            }
            string[] parameters = input.Split(",");
            string seller1Id;
            string seller2Id;
            string clientId;
            if (parameters.Length != 3)
                if (Auth("Seller") == false)
                {
                    return;
                }
            {
                await ReplyAsync(
                    "Debe ingresar los parámetros necesarios.\n Ejemplo: !assignseller 1, 2, 4");
                return;
            }

            seller1Id = parameters[0];
            seller2Id = parameters[1];
            clientId = parameters[2];
            try
            {
                Seller seller1 =admin.SearchUser<Seller>(seller1Id);
                Seller seller2 =admin.SearchUser<Seller>(seller2Id);
                Client client = facade.SearchClientById(clientId);
                seller.AssignClient(seller1Id, seller2Id, clientId);
                await ReplyAsync($"Se ha cambiado el vendedor asignado a {client.Name}, antes era {seller1.UserName} y ahora es {seller2.UserName}");
            }
            catch (Exception e)
            {
                await ReplyAsync(e.Message);
                throw;
            }

        }
    }
}