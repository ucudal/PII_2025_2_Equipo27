using System;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Program.Commands;
using System.Text;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class GetClientWithSalesBetweenParametersCommand : BotModuleBase
        {
            [Command("getclientswithsalesbetween")]
            [Summary("Permite ver los clientes con compras entre rango de montos")]
            public async Task GetClientWithSalesBetweenParameters(
                [Remainder] 
                [Summary("Permite ver los clientes con compras entre rango de montos")]
                string input)
            {
    
                try
                {
                    if (Auth("All") == false)
                    {
                        return;
                    }

                    string[] parameters = input.Split(",");
                    string minParameter; string maxParameter; 
                    if (parameters.Length != 2)
                    {
                        await ReplyAsync("Debe ingresar exactamente dos parámetros.\nEjemplo: !getclientswithsalesbetween 500,1000");
                        return;
                    }

                    minParameter = parameters[0].Trim();
                    maxParameter = parameters[1].Trim();
                    
                    var clients = facade.SearchClientsWithSalesBetweenParameters(minParameter, maxParameter);

                    var result = new StringBuilder();
                    foreach (var client in clients)
                    {
                        result.Append(
                            $"ID del cliente: {client.Id}\n" +
                            $"Nombre: {client.Name}\n" +
                            $"Apellido: {client.LastName}\n" +
                            $"Mail: {client.Email}\n" +
                            $"Teléfono: {client.Phone}\n" +
                            $"Género: {client.Gender}\n" +
                            $"Fecha de nacimiento: {client.BirthDate}\n" +
                            $"{new string('-', 40)}\n");
                    }
                    await ReplyAsync("Los clientes dentro de esos parametros son: \n" + result);
                }
                catch(Exception e)
                {
                    await ReplyAsync(e.Message);
                }
            }
        }
    } 
