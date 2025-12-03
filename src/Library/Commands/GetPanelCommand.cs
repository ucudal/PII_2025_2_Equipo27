using System.Threading.Tasks;
using Discord.Commands;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class GetPanelCommand : BotModuleBase
    {
        [Command("getpanel")]
        [Summary("permite ver un panel con clientes e interacciones")]
        public async Task GetPanel()
        {
            if (Auth("All") == false)
            {
                return;
            }
            await ReplyAsync(facade.GetPanel());
        }
    }
}