using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Library.interactions;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class ObtenerClientesMontoMayorComando : BotModuleBase
    {
        [Command("obtenerclientesmontomayor")]
        [Summary("Muestra todos los clientes con el monto mayor.")]
        public async Task ObtenerClientesMontoMayor([Remainder] [Summary("Retorma todos los clientes con el monto mayor al ingresado")] string input)
        {
            try
            {
                if (Auth("All") == false)
                {
                    return;
                }
                
                string[] parameters = input.Split(",");
                string monto;
                var result = new StringBuilder();
                if (parameters.Length < 1)
                {
                    await ReplyAsync("Debe ingresar al menos 1 parámetro.\nEjemplo: !obtenerclientesmontomayor 50,");
                    return;
                }

                monto = parameters[0];

                if (facade.ClientesOportunidadesMayores(monto).Count != 0)
                {
                    foreach (Client client in facade.ClientesOportunidadesMayores(monto))
                    {
                        result.Append($"{client.Name}\n Monto: {client.MontoTotal()}\n\n");
                    }
                }

                await ReplyAsync($"Los clientes con un monto mayor a {monto} son: \n{result}");
            }
            catch (ArgumentException e)
            {
                await ReplyAsync(e.Message);
            }
        }
    }
}