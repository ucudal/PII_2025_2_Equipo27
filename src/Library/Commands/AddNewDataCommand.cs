using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class AddNewDataCommand : ModuleBase<SocketCommandContext>
    {
        [Command("addnewdata")]
        [Summary("Comando para agregar datos a un cliente (Género y Fecha de nacimiento)")]

        public async Task AddNewData(string input)
        {
            string[] parameters = input.Split(",");
            string clientId;
            string typeOfData;
            string data;
            if (parameters.Length != 3)
            {
                await ReplyAsync("Debe ingresar exactamente 3 parámetros.\nEjemplo: !addnewdata 1,gender,male");
                return;
            }

            clientId = parameters[0];
            typeOfData = parameters[1];
            data = parameters[2];
                
            try
            {
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