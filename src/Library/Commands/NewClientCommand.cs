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
        public async Task NewClient(string name, string lastName, string email, string phone,string sellerId)
        {
            try
            {
                var client = facade.CreateClient(name, lastName, email, phone, sellerId);
                if (client != null)
                {
                    await ReplyAsync("client creado correctamente: " + client.Name + " con el Id: " + client.Id);
                }
                else
                {
                    await ReplyAsync("No se pudo crear el user" );
                }
            }
            catch (Exception e)
            {
                await ReplyAsync("Hubo un error al crear el client: " + e.Message);
            }
           
        }
        
    }
}