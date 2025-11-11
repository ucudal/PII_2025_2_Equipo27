using System;
using Library;

class Program
{
    static void Main()
    {
        // Crear instancia de Admin y AdminFacade
        Admin admin = new Admin("AdminPrincipal");
        AdminFacade adminFacade = AdminFacade.Instance;

        // Crear Sellers
        adminFacade.CreateSeller("sellerA");
        adminFacade.CreateSeller("sellerB");

        // Buscar sellers
        Seller sellerA = adminFacade.admin.SearchSeller("sellerA");
        Seller sellerB = adminFacade.admin.SearchSeller("sellerB");

        // Crear clientes asignados a sellerA
        adminFacade.CreateClient("Pepe", "Gomez", "pepe@email.com", "099123456", Client.GenderType.Male, "1980-03-15", sellerA);
        adminFacade.CreateClient("Maria", "Perez", "maria@email.com", "099456789", Client.GenderType.Female, "1992-07-01", sellerA);

        // Listar clientes en el sistema (MainFacade / AdminFacade)
        Console.WriteLine("Clientes actuales:");
        foreach (var c in adminFacade.GetClients())
            Console.WriteLine($"{c.Name} {c.LastName} - {c.Email}");

        // Probar métodos exclusivos de AdminFacade
        adminFacade.SuspendSeller("sellerB"); // Suspende sellerB
        adminFacade.ActiveSeller("sellerB");  // Activa sellerB

        // Crear instancia de SellerFacade y asignar cliente de sellerA a sellerB
        SellerFacade sellerFacade = SellerFacade.Instance;
        Client clienteParaAsignar = adminFacade.GetClients()[0]; // Tomamos el primer cliente de sellerA
        Console.WriteLine(sellerFacade.AssignClient("sellerA", "sellerB", clienteParaAsignar));

        // Prueba de registro de interacción
        adminFacade.RegisterCall("Llamada intro", "Primer contacto", clienteParaAsignar);

        // Mostrar historial de interacciones del cliente
        Console.WriteLine("--- Interacciones del cliente ---");
        foreach (var i in clienteParaAsignar.Interactions)
            Console.WriteLine(i.GetType().Name + ": " + i.Content);

        // Prueba de eliminación de cliente
        adminFacade.DeleteClient(clienteParaAsignar.Id);
        Console.WriteLine("Clientes luego de eliminar:");
        foreach (var c in adminFacade.GetClients())
            Console.WriteLine($"{c.Name} {c.LastName} - {c.Email}");

        // Probar búsquedas avanzadas
        var encontrados = adminFacade.SearchClient(RepoClients.TypeOfData.Email,"maria@email.com");
        Console.WriteLine("--- Búsqueda por email ---");
        foreach (var c in encontrados)
            Console.WriteLine($"{c.Name} {c.LastName}");
    }
}
