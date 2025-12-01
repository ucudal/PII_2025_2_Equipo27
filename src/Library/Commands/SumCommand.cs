using System.Threading.Tasks;
using Discord.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class SumCommand : ModuleBase<SocketCommandContext>
    {
        [Command("sum")]
        [Summary("Devuelve la suma de los dos números ingresados.")]
        public async Task SumTwoNumbersAsync(
            [Remainder]
            [Summary("Suma hasta diez números ingresados por el usuario")]
            string input)
        {
            string[] parameters = input.Split(",");
            int num1; int num2; int num3; int num4; int num5;
            int num6; int num7; int num8; int num9; int num10; 
            int result;
            if (parameters.Length > 10)
            {
                await ReplyAsync("No puede ingresar más de diez números.");
            }
            if (!(parameters.Length >= 1 && int.TryParse(parameters[0], out num1))) num1 = 0;
            if (!(parameters.Length >= 2 && int.TryParse(parameters[1], out num2))) num2 = 0;
            if (!(parameters.Length >= 3 && int.TryParse(parameters[2], out num3))) num3 = 0;
            if (!(parameters.Length >= 4 && int.TryParse(parameters[3], out num4))) num4 = 0;
            if (!(parameters.Length >= 5 && int.TryParse(parameters[4], out num5))) num5 = 0;
            if (!(parameters.Length >= 6 && int.TryParse(parameters[5], out num6))) num6 = 0;
            if (!(parameters.Length >= 7 && int.TryParse(parameters[6], out num7))) num7 = 0;
            if (!(parameters.Length >= 8 && int.TryParse(parameters[7], out num8))) num8 = 0;
            if (!(parameters.Length >= 9 && int.TryParse(parameters[8], out num9))) num9 = 0;
            if (!(parameters.Length >= 10 && int.TryParse(parameters[9], out num10))) num10 = 0;
            
            result = num1 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9 + num10;
            
            await ReplyAsync(result.ToString());
        }
    }
}