using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class ChangeUserTypeCommand : BotModuleBase
    {
        [Command("ChangeMyUserType")]
        public async Task ChangeUserType()
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }

                string miNombreDiscord = Context.User.Username;
                var usuario = admin.GetUsers().FirstOrDefault(u => u.UserName == miNombreDiscord);
                var myRol = usuario.GetType().Name;
                var myId = GetMyId();
                if (myRol == "Admin")
                {
                    admin.DeleteUser(myId);
                    admin.CreateSeller(miNombreDiscord);
                    await ReplyAsync("Ahora eres Seller con id : " + GetMyId());
                    return;
                }
                if (myRol == "Seller")
                {
                    admin.DeleteUser(myId);
                    admin.CreateAdmin(miNombreDiscord);
                    await ReplyAsync("Ahora eres Admin con id : " + GetMyId());
                }
                else
                {
                    throw new Exception("No se pudo cambiar de tipo de usuario. Tu rol es " + myRol + " con id : " + GetMyId());
                }
            }
            catch (Exception e)
            {
                await ReplyAsync("Hubo un error al cambiar tipo de usuario: " + e.Message);

            }
        }
    }
}