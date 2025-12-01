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
        
        private readonly SellerFacade _facade = SellerFacade.Instance;

        [Command("newclient")]
        [Summary("Crear un nuevo cliente y devuelve un mensaje indicando si se creeó correctamente o no.")]
        public async Task NewClient(string name, string lastName, string email, string phone,string sellerId)
        {   
            var myId = GetMyId();
            var client = seller.CreateClient(name, lastName, email, phone, sellerId);
            if (client != null)
            {
                await ReplyAsync("User creado correctamente" );
            }
            else
            {
                await ReplyAsync("No se pudo crear el user" );
            }
        }
        
    }
}