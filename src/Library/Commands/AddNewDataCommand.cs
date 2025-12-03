using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class AddNewDataCommand : BotModuleBase
    {
        [Command("addnewdata")]
        [Summary("Comando para agregar datos a un cliente (Género y Fecha de nacimiento)")]

        public async Task AddNewData(
            [Remainder]
            [Summary("Agrega datos a un cliente indicado")]
            string input)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                string[] parameters = input.Split(",");
                string clientId;
                string typeOfData;
                string data;
                if (parameters.Length != 3)
                {
                    await ReplyAsync("Debe ingresar exactamente 3 parámetros.\nEjemplo: !addnewdata 1,gender,male");
                    return;
                }

                clientId = parameters[0].Trim();
                typeOfData = parameters[1].Trim();
                data = parameters[2].Trim();
                
            
                SellerFacade.Instance.AddData(clientId, typeOfData, data);
                await ReplyAsync("Datos agregados correctamente.");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync($"Error: {e.Message}");
            }
        }
    }
}