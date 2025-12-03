using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class NewAdminCommand : BotModuleBase
    {


        [Command("newadmin")]
        [Summary("Permite al admin crear un nuevo Admin.")]
        public async Task CreateNewAdmin(string name)
        {
            try
            {
                if (Auth("Admin") == false)
                {
                    return;
                }
                var newAdmin = admin.CreateAdmin(name);
                await ReplyAsync("Nuevo Admin creado: " + newAdmin.UserName + ", con el id: " + newAdmin.Id);
            }
            catch (Exception e)
            {
                await ReplyAsync("Hubo un error al crear el nuevo administrador: " + e.Message);
            }
        }
    }
}