using System;
using Library;
// using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Services;

namespace Ucu.Poo.DiscordBot.Program
{
    /// <summary>
    /// Un programa que implementa un bot de Discord.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada al programa.
        /// </summary>
        private static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                DemoFacade(args);
            }
            else
            {
                DemoBot();
            }
        }

        private static void DemoFacade(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine(AdminFacade.Instance.Admin.UserName);
            }
        }

        private static void DemoBot()
        {
            BotLoader.LoadAsync().GetAwaiter().GetResult();
        }
    }
}

