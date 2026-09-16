public static class PersonaView
{
    public static void MostrarMenu()
    {
        Console.WriteLine("Menú");
        Console.WriteLine("1. Ver personas");
        Console.WriteLine("2. Añadir persona");
        Console.WriteLine("3. Eliminar persona");
        Console.WriteLine("4. Modificar persona");
        Console.WriteLine("5. Buscar persona");
        Console.Write("Elige una opción: ");
    }

    public static void MostrarMensaje(string mensaje)
    {
        Console.WriteLine(mensaje);
    }

    public static string? PedirNombre()
    {
        Console.Write("Nombre: ");
        return Console.ReadLine();
    }

    public static string? PedirEdad()
    {
        Console.Write("Edad: ");
        return Console.ReadLine();
    }

    public static string? PedirCorreo()
    {
        Console.Write("Correo: ");
        return Console.ReadLine();
    }

    public static string? PedirTelefono()
    {
        Console.Write("Teléfono: ");
        return Console.ReadLine();
    }
    public static string? PedirOpcion()
    {
        Console.Write("Opción: ");
        return Console.ReadLine();
    }

    public static string? PedirId()
    {
        Console.Write("ID: ");
        return Console.ReadLine();
    }
    public static void MostrarMenuModificacion()
    {
        Console.WriteLine("¿Qué desea modificar?");
        Console.WriteLine("1. Nombre");
        Console.WriteLine("2. Edad");
        Console.WriteLine("3. Correo");
        Console.WriteLine("4. Teléfono");
        Console.WriteLine("5. Cancelar");
    }

    public static void MostrarPersona(Persona persona)
    {
        Console.WriteLine($"ID: {persona.Id}");
        Console.WriteLine($"Nombre: {persona.Nombre}");
        Console.WriteLine($"Edad: {persona.Edad}");
        Console.WriteLine($"Correo: {persona.Correo}");
        Console.WriteLine($"Teléfono: {persona.Telefono}");
        Console.WriteLine("-------------------------");
    }

    public static void MostrarMenuBusqueda()
    {
        Console.WriteLine("¿Cómo desea buscar?");
        Console.WriteLine("1. Buscar por ID");
        Console.WriteLine("2. Buscar por nombre");
    }
}