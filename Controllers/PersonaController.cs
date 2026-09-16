using System.Text.Json;

public class PersonaController
{
    public PersonaController()
    {
        CargarPersonas();
    }
    private List<Persona> personas = new List<Persona>();
    private PersonaRepository repository = new PersonaRepository();

    public void AgregarPersona()
    {
        string? nombre = ObtenerNombre();

        if (nombre == null)
        {
            return;
        }

        int? edad = ObtenerEdad();

        if (edad == null)
        {
            return;
        }

        string? correo = ObtenerCorreo();

        if (correo == null)
        {
            return;
        }

        string? telefono = ObtenerTelefono();

        if (telefono == null)
        {
            return;
        }
        
        int nuevoId = personas.Count > 0
        ? personas.Max(persona => persona.Id) + 1
        : 1;

        personas.Add(new Persona(nuevoId, nombre, edad.Value, correo, telefono));
        
        GuardarPersonas();

        PersonaView.MostrarMensaje("Persona agregada");
    }
    public void VerPersonas() 
    { 
        if (personas.Count == 0) 
        { 
            PersonaView.MostrarMensaje("No hay personas registradas."); 
            return; 
        } 
        
        foreach (Persona persona in personas)
        {
            PersonaView.MostrarPersona(persona);
        }
    }

    public void EliminarPersona()
    {
        int? id = ObtenerId();

        if (id == null)
        {
            return;
        }

        Persona? personaEncontrada = BuscarPorId(id.Value);

        if (personaEncontrada != null)
        {
            personas.Remove(personaEncontrada);

            GuardarPersonas();

            PersonaView.MostrarMensaje("Persona eliminada.");
        }
        else
        {
            PersonaView.MostrarMensaje("Persona no encontrada.");
        }
    }

    public void ModificarPersona()
    {
        int? id = ObtenerId();

        if (id == null)
        {
            return;
        }

        Persona? personaEncontrada = BuscarPorId(id.Value);

        if (personaEncontrada == null)
        {
            PersonaView.MostrarMensaje("Persona no encontrada.");
            return;
        }

        PersonaView.MostrarMensaje($"Persona encontrada: {personaEncontrada.Nombre}");
        PersonaView.MostrarMenuModificacion();

        string? opcion = PersonaView.PedirOpcion();

        switch (opcion)
        {
            case "1":
                string? nuevoNombre = ObtenerNombre();

                if (nuevoNombre == null)
                {
                    return;
                }
                
                personaEncontrada.Nombre = nuevoNombre;
                GuardarPersonas();
                
                PersonaView.MostrarMensaje("Nombre modificado correctamente."); 
                break;

            case "2":
                int? nuevaEdad = ObtenerEdad();

                if (nuevaEdad == null)
                {
                    return;
                }
                
                personaEncontrada.Edad = nuevaEdad.Value;
                GuardarPersonas();
                                
                PersonaView.MostrarMensaje("Edad modificada correctamente."); 
                break;

            case "3":
                string? nuevoCorreo = ObtenerCorreo();

                if (nuevoCorreo == null)
                {
                    return;
                }
                
                personaEncontrada.Correo = nuevoCorreo;
                GuardarPersonas();
                                
                PersonaView.MostrarMensaje("Correo modificado correctamente."); 
                break;

            case "4":
                string? nuevoTelefono = ObtenerTelefono();

                if (nuevoTelefono == null)
                {
                    return;
                }

                personaEncontrada.Telefono = nuevoTelefono;
                GuardarPersonas();
                
                PersonaView.MostrarMensaje("Teléfono modificado correctamente."); 
                break;

            case "5":
                PersonaView.MostrarMensaje("Operación cancelada.");
                return;

            default:
                PersonaView.MostrarMensaje("Opción no válida.");
                break;
        }

        GuardarPersonas(); 
    }

    public void BuscarPersona() 
    { 
        PersonaView.MostrarMenuBusqueda();

        string? opcion = PersonaView.PedirOpcion();

        switch (opcion)
        {
            case "1":
                int? id = ObtenerId();

                if (id == null)
                {
                    return;
                }

                Persona? personaPorId = BuscarPorId(id.Value);

                if (personaPorId == null)
                {
                    PersonaView.MostrarMensaje("Persona no encontrada.");
                    return;
                }

                PersonaView.MostrarMensaje("Persona encontrada:");
                PersonaView.MostrarPersona(personaPorId);
                return;

            case "2":
                string? nombre = PersonaView.PedirNombre();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    PersonaView.MostrarMensaje("Nombre inválido.");
                    return;
                }

                Persona? personaPorNombre = BuscarPorNombre(nombre);

                if (personaPorNombre == null)
                {
                    PersonaView.MostrarMensaje("Persona no encontrada.");
                    return;
                }

                PersonaView.MostrarMensaje("Persona encontrada:");
                PersonaView.MostrarPersona(personaPorNombre);
                return;

            default:
                PersonaView.MostrarMensaje("Opción no válida.");
                return;
        }
    }

    private Persona? BuscarPorNombre(string nombre)
    {
        nombre = nombre.Trim();

        return personas.FirstOrDefault(
            persona => string.Equals(
                persona.Nombre?.Trim(),
                nombre,
                StringComparison.OrdinalIgnoreCase
            )
        );
    }

    private Persona? BuscarPorId(int id)
    {
        return personas.FirstOrDefault(
            persona => persona.Id == id
        );
    }
    private void GuardarPersonas()
    {
        try
        {
            repository.Guardar(personas);
        }
        catch (IOException ex)
        {
            PersonaView.MostrarMensaje(
                $"Error al guardar el archivo: {ex.Message}"
            );
        }
    }
    private void CargarPersonas()
    {
        try
        {
            personas = repository.Cargar();
        }
        catch (JsonException ex)
        {
            PersonaView.MostrarMensaje(
                $"El archivo JSON no tiene un formato válido: {ex.Message}"
            );
        }
        catch (IOException ex)
        {
            PersonaView.MostrarMensaje(
                $"Error al leer el archivo: {ex.Message}"
            );
        }
    }

    private int? ObtenerId()
    {
        string? idTexto = PersonaView.PedirId();

        if (!int.TryParse(idTexto, out int id))
        {
            PersonaView.MostrarMensaje("El ID debe ser un número.");
            return null;
        }

        return id;
    }

    private int? ObtenerEdad()
    {
        string? edadTexto = PersonaView.PedirEdad();

        if (!int.TryParse(edadTexto, out int edad))
        {
            PersonaView.MostrarMensaje("La edad debe ser un número.");
            return null;
        }

        if (!Validaciones.ValidarEdad(edad))
        {
            PersonaView.MostrarMensaje("La edad debe estar entre 0 y 120.");
            return null;
        }

        return edad;
    }

    private string? ObtenerNombre()
    {
        string? nombre = PersonaView.PedirNombre();

        if (!Validaciones.ValidarNombre(nombre))
        {
            PersonaView.MostrarMensaje("El nombre no es válido.");
            return null;
        }

        return nombre;
    }

    private string? ObtenerCorreo()
    {
        string? correo = PersonaView.PedirCorreo();

        if (!Validaciones.ValidarCorreo(correo))
        {
            PersonaView.MostrarMensaje("El correo no es válido.");
            return null;
        }

        return correo;
    }

    private string? ObtenerTelefono()
    {
        string? telefono = PersonaView.PedirTelefono();

        if (!Validaciones.ValidarTelefono(telefono))
        {
            PersonaView.MostrarMensaje("El teléfono no es válido.");
            return null;
        }

        return telefono;
    }
}