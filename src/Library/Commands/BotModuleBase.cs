using System;
using Discord.Commands;
using Library;
using System.Linq;

namespace Program.Commands
{
    /// <summary>
    /// Clase base abstracta que agrupa la funcionalidad y dependencias comunes para todos los módulos de comandos del bot.
    /// </summary>
    public abstract class BotModuleBase : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Provee acceso a las fachadas que contienen la lógica de negocio del sistema.
        /// Aplicación de los patrones y principios:
        /// - Singleton: AdminFacade y SellerFacade se acceden mediante su instancia única (.Instance) para asegurar la consistencia del estado global.
        /// - Facade: Estas propiedades actúan como puertas de enlace simplificadas hacia los subsistemas complejos de la librería, ocultando la complejidad a los comandos.
        /// </summary>
        protected readonly AdminFacade admin = AdminFacade.Instance;
        protected readonly SellerFacade seller = SellerFacade.Instance;
        protected readonly MainFacade facade = new MainFacade();

        /// <summary>/// Extrae el ID del usuario registrado en el sistema que coincide con el usuario de Discord que ejecuta el comando.
        /// Aplicación de los patrones y principios:
        /// - SRP: La responsabilidad única de este método es resolver la identidad: traducir el contexto de Discord (Username) a un identificador del dominio (User ID).
        /// </summary>
        /// <returns>ID del usuario en el sistema o null si no existe.</returns>
        protected string GetMyId()
        {
            var user = admin.GetUsers()
                .FirstOrDefault(u => u.UserName == Context.User.Username.ToLower());
            return user?.Id.ToString(); 
        }

        protected bool Auth(string rol)
        {
            string discordUserName = Context.User.Username.ToLower();
            
            var usuario = admin.GetUsers().FirstOrDefault(u => u.UserName == discordUserName);
            

            if (usuario == null )
            {
                ReplyAsync("No estás registrado en el sistema. Puedes iniciar con !initadmin o !initseller.");
                return false;
            }

            var userRol = usuario.GetType().Name;
            if ( rol == "All")
            {
                return true;
            }

            if (rol == userRol)
            {
                return true;
            }
            
            ReplyAsync($"⛔ Acceso denegado: Este comando requiere rol de: " + rol + ". Tu rol es " + userRol);
            return false;
        }
    }
}