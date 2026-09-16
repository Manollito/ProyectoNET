PersonaController controller = new PersonaController();

bool ejecutando = true;

while (ejecutando)
{
    PersonaView.MostrarMenu();

    if (int.TryParse(Console.ReadLine(), out int opcion))
    {
        switch (opcion)
        {
            case 1:
                controller.VerPersonas();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                break;

            case 2:
                controller.AgregarPersona();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                break;

            case 3:
                controller.EliminarPersona();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                break;

            case 4:
                controller.ModificarPersona();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                break;

            case 5:
                controller.BuscarPersona();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                break;

            case 6:
                ejecutando = false;
                break;

            default:
                Console.WriteLine("Opción inválida");
                break;
        }
    }
}