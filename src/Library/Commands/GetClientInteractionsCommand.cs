using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Library;
using Library.interactions;
using Program.Commands;

namespace Ucu.Poo.DiscordBot.Commands
{
    public class GetClientInteractionsCommand : BotModuleBase
    {
        [Command("getclientinteractions")]
        [Summary(("Retorna las interacciones de un cliente"))]

        public async Task GetClientInteractions(
            [Remainder]
            [Summary("Retorna todas las intercciones de un cliente")]
            string input)
        {
            string[] parameters = input.Split(",");
            string clientId;
            var result = new StringBuilder();
            if (parameters.Length < 1)
            {
                await ReplyAsync("Debe ingresar al menos 1 parámetro.\nEjemplo: !getclientinfotmation clientId");
                return;
            }

            clientId = parameters[0];
            Client client = facade.SearchClientById(clientId);
            if (client == null)
            {
                await ReplyAsync("No existe un client con el Id ingresado.");
                return;  
            }

            IReadOnlyList<Interaction> interactions = facade.GetClientInteractions(clientId);

            if (interactions.Count == 0)
            {
                await ReplyAsync("El cliente no tiene ninguna interacción.");
                return;
            }

            var allInteractionTypes = new Dictionary<string, List<Interaction>>
            {
                { "call", new List<Interaction>() },
                { "email", new List<Interaction>() },
                { "meeting", new List<Interaction>() },
                { "message", new List<Interaction>() }
            };
            
            foreach (var interaction in interactions)
            {
                if (interaction.GetType() == typeof(Call)) allInteractionTypes["call"].Add(interaction);
                else if (interaction.GetType() == typeof(Email)) allInteractionTypes["email"].Add(interaction);
                else if (interaction.GetType() == typeof(Meeting)) allInteractionTypes["meeting"].Add(interaction);
                else if (interaction.GetType() == typeof(Message)) allInteractionTypes["message"].Add(interaction);
            }

            if (parameters.Length == 2)
            {
                string filter = parameters[1].Trim().ToLower();
                if (!allInteractionTypes.ContainsKey(filter))
                {
                    await ReplyAsync("Tipo inválido. Tipos válidos: call, email, meeting, message");
                    return;
                }

                var list = allInteractionTypes[filter];

                if (list.Count == 0)
                {
                    await ReplyAsync($"El cliente no tiene interacciones del tipo '{filter}'.");
                    return;
                }
                
                foreach (var interaction in list)
                {
                    result.Append(
                        $"Tipo: {interaction.GetType().Name}\n" +
                        $"ID: {interaction.Id}\n" +
                        $"Fecha: {interaction.InteractionDate}\n" +
                        $"Contenido: {interaction.Content}\n" +
                        $"Notas: {interaction.Notes}\n" +
                        new string('-', 40) + "\n"
                    );
                }
                
                await ReplyAsync(result.ToString());
                return;
            }
            
            foreach (var type in allInteractionTypes)
            {
                if (type.Value.Count == 0) continue;

                result.Append($"{type.Key.ToUpper()}\n");

                foreach (var interaction in type.Value)
                {
                    result.Append(
                        $"ID: {interaction.Id}\n" +
                        $"Fecha: {interaction.InteractionDate}\n" +
                        $"Contenido: {interaction.Content}\n" +
                        $"Notas: {interaction.Notes}\n" +
                        new string('-', 40) + "\n"
                    );
                }
            }

            await ReplyAsync(result.ToString());
        }
    }
}