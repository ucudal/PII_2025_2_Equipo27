using System.Threading.Tasks;
using Discord.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class SumCommand : ModuleBase<SocketCommandContext>
    {
        [Command("sum")]
        [Summary("Devuelve la suma de los dos números ingresados.")]
        public async Task SumTwoNumbersAsync(string input)
        {
            string[] parameters = input.Split(",");
            int num1; int num2; int result;
            
            if (!(parameters.Length >= 1 && int.TryParse(parameters[0], out num1))) num1 = 0;
            
            if (!(parameters.Length >= 2 && int.TryParse(parameters[1], out num2))) num2 = 0;

            result = num1 + num2;
            
            await ReplyAsync(result.ToString());
        }
    }
}